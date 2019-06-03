using BusinessLogic.BusinessObjects;
using BusinessLogic.LoyaltyPoints;
using BusinessLogic.PriceCalculations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Rental
{

    public class RentalOperations : IRentalOperations
    {
        #region Decalre Variables
        private const string CurrencySymbol = "€";
        #endregion
        public List<Equipment> GetAllEquipments()
        {
            List<Equipment> equipments = new List<Equipment>();
            equipments = GetMockEquipmentsData();

            return equipments;
        }

        public double CalculateTotalPrice(Order order)
        {
            double price = 0;
            if (order == null) return price;
            if (order.OrderedEquipments == null) return price;
            if (order.OrderedEquipments.Count == 0) return price;
            foreach (Equipment item in order.OrderedEquipments)
            {
                double itemPrice = PriceCalculator.CalculateEquipmentPrice(item);
                price += itemPrice;
            }
            return price;
        }

        public double CalculateLoyaltyPoints(Order order)
        {
            double loyaltyPoints = 0;

            loyaltyPoints = LoyaltyPointsCalculator.GetLoyaltyPoints(order);

            return loyaltyPoints;
        }

        public StringBuilder GenerateInvoiceFileText(Order order)
        {
            StringBuilder invoiceText = new StringBuilder();
            if (order == null || order.OrderedEquipments == null || order.OrderedEquipments.Count == 0)
            {
                return invoiceText;
            }
            double totalPrice = this.CalculateTotalPrice(order);
            double loyaltyPoint = this.CalculateLoyaltyPoints(order);

            invoiceText.AppendLine("Invoice for order contains " + order.OrderedEquipments.Count.ToString() + " item(s), Invoice Date: " + DateTime.Now.ToShortDateString());
            invoiceText.AppendLine();
            invoiceText.AppendLine("Equipment item(s) :");
            int itemNumber = 0;
            foreach (var item in order.OrderedEquipments)
            {
                double itemPrice = PriceCalculator.CalculateEquipmentPrice(item);
                invoiceText.AppendLine("Item no." + itemNumber++.ToString() + ": " + item.Name + " with price: " + itemPrice.ToString() + CurrencySymbol);
            }

            invoiceText.AppendLine();
            invoiceText.AppendLine("Summary:");
            invoiceText.AppendLine("Total price of the invoice: " + totalPrice + CurrencySymbol);
            invoiceText.AppendLine("You Gain: " + loyaltyPoint + " Loyalty point(s)");

            return invoiceText;
        }

        private List<Equipment> GetMockEquipmentsData()
        {
            return new List<Equipment>()
            {
                new Equipment()
                {
                    EquipmentId =  1,
                    Name = "Caterpillar bulldozer",
                    Type = Enums.EquipmentTypes.Heavy,
                    Description = "Description of Caterpillar bulldozer"
                },
                new Equipment()
                {
                    EquipmentId = 2,
                    Name = "KamAZ truck",
                    Type = Enums.EquipmentTypes.Regular,
                    Description = "Description of KamAZ truck"
                },
                new Equipment()
                {
                    EquipmentId = 3,
                    Name = "Komatsu crane",
                    Type = Enums.EquipmentTypes.Heavy,
                    Description = "Description of Komatsu crane"
                },
                new Equipment()
                {
                     EquipmentId = 4,
                     Name = "Volvo steamroller",
                     Type = Enums.EquipmentTypes.Regular,
                     Description = "Description of Volvo steamroller"
                },
                new Equipment()
                {
                    EquipmentId = 5,
                    Name = "Bosch jackhammer",
                    Type = Enums.EquipmentTypes.Specialized,
                    Description = "Description of Bosch jackhammer"
                }
            };
        }

    }
}