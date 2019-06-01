using BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EquipmentRental.Models
{
    public class EquipmentModel
    {
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public EquipmentTypes Type { get; set; }
        public string Description { get; set; }
        public int RentDays { get; set; }
        public EquipmentModel()
        {
            this.RentDays = 0;
            this.EquipmentId = 0;
        }
    }
}