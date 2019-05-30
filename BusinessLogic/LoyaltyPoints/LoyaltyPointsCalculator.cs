using BusinessLogic.BusinessObjects;

namespace BusinessLogic.LoyaltyPoints
{
    public static class LoyaltyPointsCalculator
    {
        public static int GetLoyaltyPoints(Order order)
        {
            int loyaltyPoints = 0;
            if (order == null) return loyaltyPoints;
            if (order.OrderedEquipments == null) return loyaltyPoints;
            if (order.OrderedEquipments.Count == 0) return loyaltyPoints;
            foreach (Equipment item in order.OrderedEquipments)
            {
                if (item.Type == Enums.EquipmentTypes.Heavy)
                {
                    loyaltyPoints += 2;
                }
                else
                {
                    loyaltyPoints++;
                }
            }

            return loyaltyPoints;

        }
    }
}
