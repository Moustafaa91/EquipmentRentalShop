using BusinessLogic.BusinessObjects;
using BusinessLogic.LoyaltyPoints;
using BusinessLogic.PriceCalculations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utilities.Resources;

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

        public async Task<StringBuilder> GenerateInvoiceFileText(Order order)
        {
            StringBuilder invoiceText = new StringBuilder();
            if (order == null || order.OrderedEquipments == null || order.OrderedEquipments.Count == 0)
            {
                return invoiceText;
            }
            double totalPrice = this.CalculateTotalPrice(order);
            double loyaltyPoint = this.CalculateLoyaltyPoints(order);

            invoiceText.AppendLine(string.Format(Resource.InvoiceHeader , order.OrderedEquipments.Count.ToString(), DateTime.Now.ToShortDateString()));
            invoiceText.AppendLine();
            invoiceText.AppendLine(Resource.InvoiceEquipmentItems);
            int itemNumber = 1;
            foreach (var item in order.OrderedEquipments)
            {
                double itemPrice = PriceCalculator.CalculateEquipmentPrice(item);
                invoiceText.AppendLine(string.Format(Resource.InvoiceItemNoAndPrice, itemNumber++.ToString() , item.Name , itemPrice.ToString() , CurrencySymbol));
            }

            invoiceText.AppendLine();
            invoiceText.AppendLine(Resource.Summary); 
            invoiceText.AppendLine(string.Format(Resource.InvoiceTotalPrice, totalPrice, CurrencySymbol));
            invoiceText.AppendLine(string.Format(Resource.InvoiceTotalLoyaltyPoints, loyaltyPoint));

            return invoiceText;
        }

        private List<Equipment> GetMockEquipmentsData()
        {
            return new List<Equipment>()
            {
                new Equipment()
                {
                    EquipmentId =  1,
                    Name = Resource.CaterpillarBulldozerName,
                    Type = Enums.EquipmentTypes.Heavy,
                    Description = Resource.CaterpillarBulldozerDescription
                },
                new Equipment()
                {
                    EquipmentId = 2,
                    Name = Resource.KamAZTruckName,
                    Type = Enums.EquipmentTypes.Regular,
                    Description = Resource.KamAZTruckDescription
                },
                new Equipment()
                {
                    EquipmentId = 3,
                    Name = Resource.KomatsuCraneName,
                    Type = Enums.EquipmentTypes.Heavy,
                    Description = Resource.KomatsuCraneDescription
                },
                new Equipment()
                {
                     EquipmentId = 4,
                     Name = Resource.VolvoSteamrollerName,
                     Type = Enums.EquipmentTypes.Regular,
                     Description = Resource.VolvoSteamrollerDescription
                },
                new Equipment()
                {
                    EquipmentId = 5,
                    Name = Resource.BoschJackhammerName,
                    Type = Enums.EquipmentTypes.Specialized,
                    Description = Resource.BoschJackhammerDescription
                }
            };
        }

    }
}