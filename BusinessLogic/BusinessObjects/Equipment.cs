using BusinessLogic.Enums;

namespace BusinessLogic.BusinessObjects
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public EquipmentTypes Type { get; set; }
        public string Description { get; set; }
        public int RentDays { get; set; }
        public Equipment()
        {
            this.RentDays = 0;
            this.EquipmentId = 0;
        }
    }
}
