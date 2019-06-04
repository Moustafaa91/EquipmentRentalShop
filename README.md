# EquipmentRentalShop

This repository for Online construction equipment rental MVC prove-of-concept application.

## Getting Started

### Prerequisites

To start build the project make sure of the following:
* .Net framework 4.5 installed
* Unity package for applying DI
  - it should be installed in project, and in case it's not you can simply install it with the following command in Package Manager Console at visual studio ```Install-Package Unity.Mvc3``` to project [EquipmentsRental]
* log4net package for Logging
  - it should be installed in project, and in case it's not you can simply install it with the following command in Package Manager Console at visual studio ```Install-Package log4net``` to projects [EquipmentsRental, Utilities]

## How to use
Simply download the project and run it in Visual Studio, all packages needed are included and after the run, you will see single page and you will be able to: 
* List all equipment.
* Add equipment item with amount of rental days to the cart. (you cannot add the same item twice).
* Generate invoice which will download a text file with details of your order.

## Solution Details and Design
* This solution follows two-tier architecture, front-end which built as MVC application and back-end which is a console application.
* The site is multi-language (English and Arabic).
* All unit tests passed.

### BusinessLogic
This application performs all Business Logic operations needed, and it's separated into different folder each one contains single operation.
* ```BusinessObjects``` All object needed while performing business functions, this different than Model, as these objects belong only to business functions.
* ```Enums``` All Enums used while performing business functions
* ```LoyaltyPoints``` contains one static class to perform operations of calculating loyalty points
* ```PriceCalculations``` contains classes needed to perform operations of calculating loyalty points, in this folder I preferred to use 
[Strategy Design Pattern](https://en.wikipedia.org/wiki/Strategy_pattern). There are several patterns to do this but I preferred this one as it's more readable and easiest to maintain in the future.
* ```Rental``` contains class which will be used by the controller to perform operations.

### EquipmentsRental
For the purpose of this demo and for simplicity, I used only two views to do all operations:
* ```Index.cshtml``` to do all operations of list equipment, add to cart and generate invoice
* ```EquipmentDetails.cshtml``` to view details of a single equipment item

and for controllers ```HomeController.cs``` contains all controller methods needed to perform functions: 
* ```Index()``` Which return to home view
* ```ShowEquipmentDetails(int id)```Return View with details of selected equipment id
* ```BuyEquipments(List<string> purchasedItems)``` Send the order to BusinessLogic application to generate the invoice and then download it
* ```ChangeLanguage(string lang)``` Change site language


## Technologies used
* MVC .Net framework C#
* MSTest .Net framework
* Dependency Injection
* Javascript and Jquery
* Bootstrap

## Future work
* Add magic touch for UI enhancements.
* Change communication between backend and frontend to be Message-based architecture.
* Fix some known issues when switching between languages, e.g. rtl & ltr issues.

## Author

* **Moustafa Attia** - *Software Engineer .Net/C#* - [Moustafa Attia](https://github.com/MoustafaAttia)

## Acknowledgments
* For download function in javascript, [I used this stackoverflow question](https://stackoverflow.com/questions/3665115/how-to-create-a-file-in-memory-for-user-to-download-but-not-through-server)
* For language configurations, [I used this article](https://www.c-sharpcorner.com/article/how-to-create-multiple-languages-in-asp-net-mvc-4-5-framework/)
