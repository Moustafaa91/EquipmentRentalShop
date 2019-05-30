using BusinessLogic.BusinessObjects;
using BusinessLogic.Enums;

namespace BusinessLogic.PriceCalculations
{
    public class SpecializedPriceCalculation : ICalculation
    {
        public double CalculatePrice(Equipment equipment)
        {
            double price = 0;
            
            if (equipment.RentDays <= 3)
            {
                price += ((double)RentalFees.Premium * equipment.RentDays);
            }
            else
            {
                price += ((double)RentalFees.Premium * 3);
                equipment.RentDays -= 3;
                price += ((double)RentalFees.Regular * equipment.RentDays);
            }
            return price;
        }
    }
}
