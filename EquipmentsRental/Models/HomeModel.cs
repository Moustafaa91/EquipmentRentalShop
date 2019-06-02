using System.Collections.Generic;
using System.Web.Mvc;

namespace EquipmentsRental.Models
{
    public class HomeModel
    {
        
        public List<EquipmentModel> EquipmentsList { get; set; }
        public EquipmentModel DetailsObject { get; set; }
        public int SelectedEquipment { get; set; }
    }
}