using BusinessLogic.BusinessObjects;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Rental
{
    public interface IRentalOperations
    {
        List<Equipment> GetAllEquipments();
        double CalculateTotalPrice(Order order);
        double CalculateLoyaltyPoints(Order order);
        StringBuilder GenerateInvoiceFileText(Order order);
    }
}
