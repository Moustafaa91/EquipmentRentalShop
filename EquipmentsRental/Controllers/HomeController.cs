using BusinessLogic.BusinessObjects;
using BusinessLogic.Rental;
using EquipmentsRental.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Utilities.Log;

namespace EquipmentsRental.Controllers
{
    public class HomeController : Controller
    {
        #region Declare Variables
        private IRentalOperations rentalOperations;
        private ILogger logger;
        private Order order;
        private HomeModel model;
        #endregion

        #region Constructor
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
        #endregion

        #region Controller Methods
        public async Task<ActionResult> Index()
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
        public async Task<ActionResult> ShowEquipmentDetails(int id)
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
        public async Task<ActionResult> BuyEquipments(List<string> purchasedItems)
        {
            logger.Info("HomeController BuyEquipments controller start");
            if (purchasedItems == null || purchasedItems.Count == 0)
            {
                logger.Warn("HomeController BuyEquipments controller parameter (purchasedItems) is null or empty");
                return View("Index", model);
            }

            string fileName = "Invoice_" + DateTime.Now.ToShortDateString() + ".txt";
            this.order = new Order();

            foreach (var item in purchasedItems)
            {
                string equipmentName = item.Split(';')[0];
                int daysRental = Convert.ToInt32(item.Split(';')[1]);
                var orderedEquipment = this.model.EquipmentsList.Find(x => x.Name == equipmentName);
                orderedEquipment.RentDays = daysRental;
                this.order.OrderedEquipments.Add(ConvertModelToBusinessObject(orderedEquipment));
            }

            StringBuilder invoiceText = await this.rentalOperations.GenerateInvoiceFileText(this.order);

            logger.Info("HomeController BuyEquipments controller end");
            return Json(new { filename = fileName, filecontent = invoiceText.ToString() });
        }
        #endregion

        #region Helper Methods
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
        #endregion

    }
}