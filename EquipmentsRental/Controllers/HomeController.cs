using EquipmentsRental.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using BusinessLogic.Rental;
using System;
using System.IO;
using Utilities.Log;
using BusinessLogic.BusinessObjects;
using System.Web;

namespace EquipmentsRental.Controllers
{
    public class HomeController : Controller
    {
        #region Declare Variables
        private IRentalOperations rentalOperations;
        private ILogger logger;
        private Order order;
        HomeModel model;
        #endregion

        public HomeController(IRentalOperations _rentalOperations, ILogger _logger)
        {
            try
            {
                this.rentalOperations = _rentalOperations;
                this.logger = _logger;
                logger.Info("HomeController constructor start");
                this.model = new HomeModel();
                this.model.EquipmentsList = new List<EquipmentModel>();
                var result = this.rentalOperations.GetAllEquipments();
                foreach (var item in result)
                {
                    model.EquipmentsList.Add(ConvertBusinessObjectToModel(item));
                }
                logger.Info("HomeController constructor end");
            }
            catch (Exception ex)
            {
                logger.Error("Error in HomeController constructor", ex);
            }
            
        }
        public ActionResult Index()
        {
            try
            {
                logger.Info("HomeController Index controller start");
                model.DetailsObject = model.EquipmentsList[0];

                logger.Info("HomeController Index controller end");
                return View("Index", model);
            }
            catch (Exception ex)
            {
                logger.Error("Error in HomeController Index controller", ex);
                return View("Index", model);
            }
        }

        [HttpGet]
        [Route("ShowEquipmentDetails/{id}")]
        public ActionResult ShowEquipmentDetails(int id)
        {
            try
            {
                logger.Info("HomeController ShowEquipmentDetails controller start");
                model.DetailsObject = model.EquipmentsList.Find(x => x.EquipmentId == id);

                logger.Info("HomeController ShowEquipmentDetails controller end");
                return PartialView("../Equipments/EquipmentDetails", model.DetailsObject);
            }
            catch (Exception ex)
            {
                logger.Error("Error in HomeController ShowEquipmentDetails controller", ex);
                return View("Index", model);
            }
        }

        [HttpPost]
        [Route("BuyEquipments/{purchasedItems}")]
        public ActionResult BuyEquipments(List<string> purchasedItems)
        {
            logger.Info("HomeController BuyEquipments method start");
            this.order = new Order();
            if (purchasedItems.Count == 0)
            {
                return View("Index", model);
            }

            foreach (var item in purchasedItems)
            {
                string equipmentName = item.Split(';')[0];
                int daysRental = Convert.ToInt32(item.Split(';')[1]);
                var orderedEquipment = this.model.EquipmentsList.Find(x => x.Name == equipmentName);
                orderedEquipment.RentDays = daysRental;
                this.order.OrderedEquipments.Add(ConvertModelToBusinessObject(orderedEquipment));
            }

            double price = this.rentalOperations.CalculatePrice(this.order);
            double loyaltyPoints = this.rentalOperations.CalculateLoyaltyPoints(this.order);



            string name = "output.txt";

            FileInfo info = new FileInfo(name);
            if (!info.Exists)
            {
                using (StreamWriter writer = info.CreateText())
                {
                    writer.WriteLine("Hello, I am a new text file");
                }
            }
            string contentType = MimeMapping.GetMimeMapping(info.Name);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = info.Name,
                Inline = true,
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());

            logger.Info("HomeController BuyEquipments method end");
            return File(info.OpenRead(), contentType);
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

        private EquipmentModel ConvertBusinessObjectToModel(Equipment equipment)
        {
            return new EquipmentModel()
            {
                Description = equipment.Description,
                EquipmentId = equipment.EquipmentId,
                Name = equipment.Name,
                RentDays = equipment.RentDays,
                Type = (int)equipment.Type == 1 ? Enums.EquipmentTypes.Heavy : (int)equipment.Type == 2 ? Enums.EquipmentTypes.Regular : Enums.EquipmentTypes.Specialized
            };
        }
        private Equipment ConvertModelToBusinessObject(EquipmentModel equipment)
        {
            return new Equipment()
            {
                Description = equipment.Description,
                EquipmentId = equipment.EquipmentId,
                Name = equipment.Name,
                RentDays = equipment.RentDays,
                Type = (int)equipment.Type == 1 ? BusinessLogic.Enums.EquipmentTypes.Heavy : (int)equipment.Type == 2 ? BusinessLogic.Enums.EquipmentTypes.Regular : BusinessLogic.Enums.EquipmentTypes.Specialized
            };
        }

    }
}