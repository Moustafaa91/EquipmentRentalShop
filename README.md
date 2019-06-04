# EquipmentRentalShop

This repository for Online construction equipment rental MVC prove-of-concept application.

## Getting Started

### Prerequisites

To start build the project you  need to make sure you installed:
* Make sure that .Net framework 4.5 installed
* Unity package for applying DI
  - it should be installed in project, and in case it's not you can simply installed with the following command in Package Manager Console at visual studio ```Install-Package Unity.Mvc3``` to project [EquipmentsRental]
  * log4net package for Logging
  - it should be installed in project, and in case it's not you can simply installed with the following command in Package Manager Console at visual studio ```Install-Package log4net``` to projects [EquipmentsRental, Utilities]

## Solution Details and Design
This solutions follows two-ties architecture, fron-end which built as MVC application and back-end which is console application.

### HomeController
Controller layer calls the business logic layer, to return model object and assign it inside response object.
* ```AnswerQuestion(int questionNumber)``` return an ```AnswerResponse``` object which contains and answer for selected question.
* ```GetHolidays(int year, string countryCode)``` return ```PublicHolidayResponse``` which contains list of Holidays for selected country at selected year.
* ```GetHolidaysByYear(int year)``` return ```CountryPublicHolidayResponse``` which contains all holidays for all countries at selected year.
* Throttle to each controller assigned to be 5 seconds for each call

## Utilities
Any utilites classes or methods used in application, In this solution we have only folder for logger class. 


## Technologies used
* MVC .Net framework C#
* MSTest .Net framework
* Dependency Injection
* Javascript and Jquery
* Bootstrap

## Future work
* Add magic touch for UI enhancements
* Change communication between backend and frontend to be Message-based architecture

## Author

* **Moustafa Attia** - *Software Engineer .Net/C#* - [Moustafa Attia](https://github.com/MoustafaAttia)

## Acknowledgments

*
