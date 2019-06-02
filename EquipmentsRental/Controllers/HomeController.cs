using EquipmentsRental.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using BusinessLogic.Rental;
using System;
using System.IO;
using EquipmentsRental.Utilities;

namespace EquipmentsRental.Controllers
{
    public class HomeController : Controller
    {
        #region Declare Variables
        private IRentalOperations rentalOperations;
        HomeModel model;
        #endregion

        public HomeController(IRentalOperations _rentalOperations)
        {
            try
            {
                Log.Info("HomeController constructor start");
                this.rentalOperations = _rentalOperations;
                this.model = new HomeModel();
                this.model.EquipmentsList = new List<EquipmentModel>();
                var result = this.rentalOperations.GetAllEquipments();
                foreach (var item in result)
                {

                    model.EquipmentsList.Add(new EquipmentModel()
                    {
                        Description = item.Description,
                        EquipmentId = item.EquipmentId,
                        Name = item.Name,
                        RentDays = item.RentDays,
                        Type = (int)item.Type == 1 ? Enums.EquipmentTypes.Heavy : (int)item.Type == 2 ? Enums.EquipmentTypes.Regular : Enums.EquipmentTypes.Specialized
                    });
                }
                Log.Info("HomeController constructor end");
            }
            catch (Exception ex)
            {
                Log.Error("Error in HomeController constructor", ex);
            }
            
        }
        public ActionResult Index()
        {
            Log.Info("HomeController Index method start");
            model.DetailsObject = model.EquipmentsList[0];

            Log.Info("HomeController Index method end");
            return View("Index", model);
        }

        [HttpGet]
        [Route("ShowEquipmentDetails/{id}")]
        public ActionResult ShowEquipmentDetails(int id)
        {
            Log.Info("HomeController ShowEquipmentDetails method start");
            model.DetailsObject = model.EquipmentsList.Find(x => x.EquipmentId == id);

            Log.Info("HomeController ShowEquipmentDetails method end");
            return PartialView("../Equipments/EquipmentDetails", model.DetailsObject);
            
        }

        [HttpPost]
        [Route("BuyEquipments/{purchasedItems}")]
        public ActionResult BuyEquipments(List<string> purchasedItems)
        {
            Log.Info("HomeController BuyEquipments method start");

            Log.Info("HomeController BuyEquipments method end");
            return PartialView("../Equipments/EquipmentDetails", model.DetailsObject);

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

        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,
                                                                         viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View,
                                             ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}