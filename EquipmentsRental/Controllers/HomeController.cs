using EquipmentsRental.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using BusinessLogic.Rental;

namespace EquipmentsRental.Controllers
{
    public class HomeController : Controller
    {
        #region Declare Variables
        private IRentalOperations rentalOperations;
        #endregion

        public HomeController(IRentalOperations _rentalOperations)
        {
            this.rentalOperations = _rentalOperations;
        }
        public ActionResult Index()
        {
            HomeModel model = new HomeModel();
            model.EquipmentsList = new List<SelectListItem>();
            var result = this.rentalOperations.GetAllEquipments();
            foreach (var item in result)
            {
                model.EquipmentsList.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.EquipmentId.ToString()
                });
            }
            return View("Index",model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}