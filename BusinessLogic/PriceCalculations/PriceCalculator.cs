using BusinessLogic.BusinessObjects;

namespace BusinessLogic.PriceCalculations
{
    public static class PriceCalculator
    {
        private static ICalculation calculation;
        

        public static double CalculatePrice(Equipment equipment)
        {
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
