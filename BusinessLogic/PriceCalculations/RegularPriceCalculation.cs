using BusinessLogic.BusinessObjects;
using BusinessLogic.Enums;

namespace BusinessLogic.PriceCalculations
{
    public class RegularPriceCalculation : ICalculation
    {
        public double CalculatePrice(Equipment equipment)
        {
            double price = 0;
            price = (double)RentalFees.OneTime;
            if (equipment.RentDays <= 2)
            {
                price += ((double)RentalFees.Premium * equipment.RentDays);
            }
            else
            {
                price += ((double)RentalFees.Premium * 2);
                equipment.RentDays -= 2;
                price += ((double)RentalFees.Regular * equipment.RentDays);
            }
            return price;
        }
    }
}
