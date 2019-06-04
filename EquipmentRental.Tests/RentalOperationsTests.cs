using BusinessLogic.BusinessObjects;
using BusinessLogic.Enums;
using BusinessLogic.Rental;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Tests
{
    [TestClass]
    public class RentalOperationsTests
    {
        private RentalOperations rentalOperations;

        public RentalOperationsTests()
        {
            this.rentalOperations = new RentalOperations();
        }

        #region CalculateTotalPrice Test Methods
        [TestMethod]
        public void CalculateTotalPrice_InvalidNullParameter_ReturnZero()
        {
            // Arrange
            Order order = null;
            double expectedResult = 0;

            // Act
            double actualResult = this.rentalOperations.CalculateTotalPrice(order);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void CalculateTotalPrice_InvalidNullEquipmentsParameter_ReturnZero()
        {
            // Arrange
            Order order = new Order();
            order.OrderedEquipments = null;
            double expectedResult = 0;

            // Act
            double actualResult = this.rentalOperations.CalculateTotalPrice(order);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void CalculateTotalPrice_InvalidEmptyEquipmentsParameter_ReturnZero()
        {
            // Arrange
            Order order = new Order();
            order.OrderedEquipments = new List<Equipment>();
            double expectedResult = 0;

            // Act
            double actualResult = this.rentalOperations.CalculateTotalPrice(order);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void CalculateTotalPrice_WithDifferentEquipmentTypes_ReturnAsExpected()
        {
            // Arrange
            Order order = new Order();
            order.OrderedEquipments = new List<Equipment>();
            order.OrderedEquipments.Add(MockEquipmentItem(type: EquipmentTypes.Heavy, rentDays: 10));
            order.OrderedEquipments.Add(MockEquipmentItem(type: EquipmentTypes.Regular, rentDays: 10));
            order.OrderedEquipments.Add(MockEquipmentItem(type: EquipmentTypes.Specialized, rentDays: 10));
            double expectedResult = 1700;

            // Act
            double actualResult = this.rentalOperations.CalculateTotalPrice(order);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }
        #endregion

        #region CalculateLoyaltyPoints Test Methods
        [TestMethod]
        public void CalculateLoyaltyPoints_InvalidNullParameter_ReturnZero()
        {
            // Arrange
            Order order = null;
            double expectedResult = 0;

            // Act
            double actualResult = this.rentalOperations.CalculateLoyaltyPoints(order);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void CalculateLoyaltyPoints_InvalidNullEquipmentsParameter_ReturnZero()
        {
            // Arrange
            Order order = new Order();
            order.OrderedEquipments = null;
            double expectedResult = 0;

            // Act
            double actualResult = this.rentalOperations.CalculateLoyaltyPoints(order);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void CalculateLoyaltyPoints_InvalidEmptyEquipmentsParameter_ReturnZero()
        {
            // Arrange
            Order order = new Order();
            order.OrderedEquipments = new List<Equipment>();
            double expectedResult = 0;

            // Act
            double actualResult = this.rentalOperations.CalculateLoyaltyPoints(order);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void CalculateLoyaltyPoints_WithDifferentEquipmentTypes_ReturnAsExpected()
        {
            // Arrange
            Order order = new Order();
            order.OrderedEquipments = new List<Equipment>();
            order.OrderedEquipments.Add(MockEquipmentItem(type: EquipmentTypes.Heavy, rentDays: 10));
            order.OrderedEquipments.Add(MockEquipmentItem(type: EquipmentTypes.Regular, rentDays: 10));
            order.OrderedEquipments.Add(MockEquipmentItem(type: EquipmentTypes.Specialized, rentDays: 10));
            double expectedResult = 4;

            // Act
            double actualResult = this.rentalOperations.CalculateLoyaltyPoints(order);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }
        #endregion

        #region GenerateInvoiceFileText Test Methods
        [TestMethod]
        public void GenerateInvoiceFileText_InvalidNullParameter_ReturnEmptyString()
        {
            // Arrange
            Order order = null;
            int expectedResult = 0;

            // Act
            Task<StringBuilder> result = this.rentalOperations.GenerateInvoiceFileText(order);
            int actualResult = result.Result.Length;

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void GenerateInvoiceFileText_InvalidNullEquipmentsParameter_ReturnEmptyString()
        {
            // Arrange
            Order order = new Order();
            order.OrderedEquipments = null;
            double expectedResult = 0;

            // Act
            Task<StringBuilder> result = this.rentalOperations.GenerateInvoiceFileText(order);
            int actualResult = result.Result.Length;

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void GenerateInvoiceFileText_InvalidEmptyEquipmentsParameter_ReturnEmptyString()
        {
            // Arrange
            Order order = new Order();
            order.OrderedEquipments = new List<Equipment>();
            double expectedResult = 0;

            // Act
            Task<StringBuilder> result = this.rentalOperations.GenerateInvoiceFileText(order);
            int actualResult = result.Result.Length;

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void GenerateInvoiceFileText_WithCorrect_ReturnAsExpected()
        {
            // Arrange
            Order order = new Order();
            order.OrderedEquipments = new List<Equipment>();
            order.OrderedEquipments.Add(MockEquipmentItem(type: EquipmentTypes.Heavy, rentDays: 10));
            order.OrderedEquipments.Add(MockEquipmentItem(type: EquipmentTypes.Regular, rentDays: 10));
            order.OrderedEquipments.Add(MockEquipmentItem(type: EquipmentTypes.Specialized, rentDays: 10));

            // Act
            Task<StringBuilder> result = this.rentalOperations.GenerateInvoiceFileText(order);
            StringBuilder actualResult = result.Result;

            // Assert
            Assert.IsNotNull(actualResult);
            Assert.IsInstanceOfType(actualResult, typeof(StringBuilder));
        }
        #endregion

        private Equipment MockEquipmentItem(EquipmentTypes type, int rentDays)
        {
            return new Equipment()
            {
                Type = type,
                RentDays = rentDays
            };
        }
    }
}
