using BusinessLogic.BusinessObjects;
using BusinessLogic.Enums;
using BusinessLogic.LoyaltyPoints;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EquipmentRental.Tests
{
    [TestClass]
    public class LoyaltyPointsTests
    {
        [TestMethod]
        public void GetLoyaltyPoints_InvalidNullParameter_ReturnZero()
        {
            // Arrange
            Order order = null;
            double expectedResult = 0;

            // Act
            double actualResult = LoyaltyPointsCalculator.GetLoyaltyPoints(order);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void GetLoyaltyPoints_InvalidNullEquipmentsParameter_ReturnZero()
        {
            // Arrange
            Order order = new Order() {OrderedEquipments = null };
            double expectedResult = 0;

            // Act
            double actualResult = LoyaltyPointsCalculator.GetLoyaltyPoints(order);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void GetLoyaltyPoints_InvalidEmptyEquipmentsParameter_ReturnZero()
        {
            // Arrange
            Order order = new Order() { OrderedEquipments = new List<Equipment>() };
            double expectedResult = 0;

            // Act
            double actualResult = LoyaltyPointsCalculator.GetLoyaltyPoints(order);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void GetLoyaltyPoints_WithOneHeavy_ReturnAsExpected()
        {
            // Arrange
            Order order = new Order() { OrderedEquipments = new List<Equipment>() };
            order.OrderedEquipments.Add(new Equipment() { Type = EquipmentTypes.Heavy });
            double expectedResult = 2;

            // Act
            double actualResult = LoyaltyPointsCalculator.GetLoyaltyPoints(order);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void GetLoyaltyPoints_WithMultipleHeavy_ReturnAsExpected()
        {
            // Arrange
            Order order = new Order() { OrderedEquipments = new List<Equipment>() };
            order.OrderedEquipments.Add(new Equipment() { Type = EquipmentTypes.Heavy });
            order.OrderedEquipments.Add(new Equipment() { Type = EquipmentTypes.Heavy });
            order.OrderedEquipments.Add(new Equipment() { Type = EquipmentTypes.Heavy });
            double expectedResult = 6;

            // Act
            double actualResult = LoyaltyPointsCalculator.GetLoyaltyPoints(order);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void GetLoyaltyPoints_WithMultipleTypes_ReturnAsExpected()
        {
            // Arrange
            Order order = new Order() { OrderedEquipments = new List<Equipment>() };
            order.OrderedEquipments.Add(new Equipment() { Type = EquipmentTypes.Heavy });
            order.OrderedEquipments.Add(new Equipment() { Type = EquipmentTypes.Regular });
            order.OrderedEquipments.Add(new Equipment() { Type = EquipmentTypes.Specialized });
            double expectedResult = 4;

            // Act
            double actualResult = LoyaltyPointsCalculator.GetLoyaltyPoints(order);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
