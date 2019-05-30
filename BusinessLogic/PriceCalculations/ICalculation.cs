using BusinessLogic.BusinessObjects;

namespace BusinessLogic.PriceCalculations
{
    public interface ICalculation
    {
        double CalculatePrice(Equipment equipment);
    }
}
