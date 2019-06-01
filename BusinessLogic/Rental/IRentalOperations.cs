using BusinessLogic.BusinessObjects;
using System.Collections.Generic;

namespace BusinessLogic.Rental
{
    public interface IRentalOperations
    {
        List<Equipment> GetAllEquipments();
        double CalculatePrice(Order order);
        double CalculateLoyaltyPoints(Order order);
    }
}
