using BusinessLogic.BusinessObjects;
using BusinessLogic.Enums;
using BusinessLogic.PriceCalculations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EquipmentRental.Tests
{
    [TestClass]
    public class PriceTests
    {
        [TestMethod]
        public void CalculateEquipmentPrice_InvalidNullEquipment_ReturnZero()
        {
            // Arrange
            Equipment equipment = null;
            double expectedResult = 0;

            // Act
            double actualResult = PriceCalculator.CalculateEquipmentPrice(equipment);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void CalculateEquipmentPrice_InvalidZeroRentDays_ReturnZero()
        {
            // Arrange
            Equipment equipment = new Equipment();
            equipment.RentDays = 0;
            double expectedResult = 0;

            // Act
            double actualResult = PriceCalculator.CalculateEquipmentPrice(equipment);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void CalculateEquipmentPrice_WithHeavy_ReturnAsExpected()
        {
            // Arrange
            Equipment equipment = new Equipment();
            equipment.RentDays = 10;
            equipment.Type = EquipmentTypes.Heavy;
            double expectedResult = 700;

            // Act
            double actualResult = PriceCalculator.CalculateEquipmentPrice(equipment);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void CalculateEquipmentPrice_WithRegular_ReturnAsExpected()
        {
            // Arrange
            Equipment equipment = new Equipment();
            equipment.RentDays = 10;
            equipment.Type = EquipmentTypes.Regular;
            double expectedResult = 540;

            // Act
            double actualResult = PriceCalculator.CalculateEquipmentPrice(equipment);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void CalculateEquipmentPrice_WithSpecialized_ReturnAsExpected()
        {
            // Arrange
            Equipment equipment = new Equipment();
            equipment.RentDays = 10;
            equipment.Type = EquipmentTypes.Specialized;
            double expectedResult = 460;

            // Act
            double actualResult = PriceCalculator.CalculateEquipmentPrice(equipment);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void CalculateEquipmentPrice_WithRegularLessThanTwo_ReturnAsExpected()
        {
            // Arrange
            Equipment equipment = new Equipment();
            equipment.RentDays = 1;
            equipment.Type = EquipmentTypes.Regular;
            double expectedResult = 160;

            // Act
            double actualResult = PriceCalculator.CalculateEquipmentPrice(equipment);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void CalculateEquipmentPrice_WithSpecializedLessThanThree_ReturnAsExpected()
        {
            // Arrange
            Equipment equipment = new Equipment();
            equipment.RentDays = 2;
            equipment.Type = EquipmentTypes.Specialized;
            double expectedResult = 120;

            // Act
            double actualResult = PriceCalculator.CalculateEquipmentPrice(equipment);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
