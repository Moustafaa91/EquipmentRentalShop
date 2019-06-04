using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Utilities.Resources;

namespace EquipmentsRental.Models
{
    public class HomeModel
    {
        [Display(Name = "EquipmentsList", ResourceType = typeof(Resource))]
        public List<EquipmentModel> EquipmentsList { get; set; }

        [Display(Name = "DetailsObject", ResourceType = typeof(Resource))]
        public EquipmentModel DetailsObject { get; set; }
    }
}