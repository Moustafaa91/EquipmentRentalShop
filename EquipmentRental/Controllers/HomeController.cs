using System.Collections.Generic;
using System.Web.Mvc;

namespace EquipmentRental.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new List<SelectListItem>();
            model.Add(new SelectListItem() { Text = "1", Value = "1" });
            model.Add(new SelectListItem() { Text = "2", Value = "2" });
            model.Add(new SelectListItem() { Text = "3", Value = "3" });
            return View("EquipmentsList", model);
        }
    }
}
