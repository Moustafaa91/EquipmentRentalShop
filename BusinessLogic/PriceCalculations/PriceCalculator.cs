using BusinessLogic.BusinessObjects;

namespace BusinessLogic.PriceCalculations
{
    public static class PriceCalculator
    {
        private static ICalculation calculation;
        

        public static double CalculateEquipmentPrice(Equipment equipment)
        {
            if (equipment == null) return 0;
            if (equipment.RentDays <= 0) return 0;
            switch (equipment.Type)
            {
                case Enums.EquipmentTypes.Heavy:
                    calculation = new HeavyPriceCalculation();
                    break;
                case Enums.EquipmentTypes.Regular:
                    calculation = new RegularPriceCalculation();
                    break;
                case Enums.EquipmentTypes.Specialized:
                    calculation = new SpecializedPriceCalculation();
                    break;
            } 
            return calculation.CalculatePrice(equipment);
        }
    }
}
