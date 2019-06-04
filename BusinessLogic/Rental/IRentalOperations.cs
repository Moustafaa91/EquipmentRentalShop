using BusinessLogic.BusinessObjects;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Rental
{
    public interface IRentalOperations
    {
        List<Equipment> GetAllEquipments();
        double CalculateTotalPrice(Order order);
        double CalculateLoyaltyPoints(Order order);
        Task<StringBuilder> GenerateInvoiceFileText(Order order);
    }
}
