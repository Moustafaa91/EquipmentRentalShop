using EquipmentsRental.Enums;
using System.ComponentModel.DataAnnotations;
using Utilities.Resources;

namespace EquipmentsRental.Models
{
    public class EquipmentModel
    {
        [Display(Name = "EquipmentId", ResourceType = typeof(Resource))]
        public int EquipmentId { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resource))]
        public string Name { get; set; }

        [Display(Name = "Type", ResourceType = typeof(Resource))]
        public EquipmentTypes Type { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resource))]
        public string Description { get; set; }

        [Display(Name = "RentDays", ResourceType = typeof(Resource))]
        public int RentDays { get; set; }
        public EquipmentModel()
        {
            this.RentDays = 0;
            this.EquipmentId = 0;
        }
    }
}