using BusinessLogic.BusinessObjects;
using BusinessLogic.Enums;

namespace BusinessLogic.PriceCalculations
{
    public class HeavyPriceCalculation : ICalculation
    {
        public double CalculatePrice(Equipment equipment)
        {
            double price = 0;
            price = (double)RentalFees.OneTime + ((double)RentalFees.Premium * equipment.RentDays);
            return price;
        }
    }
}
