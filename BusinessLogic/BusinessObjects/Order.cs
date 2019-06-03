using System.Collections.Generic;

namespace BusinessLogic.BusinessObjects
{
    public class Order
    {
        public List<Equipment> OrderedEquipments { get; set; }

        public Order()
        {
            this.OrderedEquipments = new List<Equipment>();
        }
    }
}
