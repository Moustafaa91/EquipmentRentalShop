using BusinessLogic.BusinessObjects;
using BusinessLogic.LoyaltyPoints;
using BusinessLogic.PriceCalculations;
using System.Collections.Generic;
using System.IO;

namespace BusinessLogic.Equipments
{

    public class EquipmentOperations
    {

        public List<Equipment> GetAllEquipments()
        {
            List<Equipment> equipments = new List<Equipment>();
            equipments = GetMockEquipmentsData();

            return equipments;
        }

        public double CalculatePrice(Order order)
        {
            double price = 0;
            if (order == null) return price;
            if (order.OrderedEquipments == null) return price;
            if (order.OrderedEquipments.Count == 0) return price;
            foreach (Equipment item in order.OrderedEquipments)
            {
                price += PriceCalculator.CalculatePrice(item);
            }
            return price;
        }

        public double CalculateLoyaltyPoints(Order order)
        {
            double loyaltyPoints = 0;

            loyaltyPoints = LoyaltyPointsCalculator.GetLoyaltyPoints(order);

            return loyaltyPoints;
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