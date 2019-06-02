# EquipmentRentalShop

This repository for Online construction equipment rental MVC prove-of-concept application.

## Getting Started

### Prerequisites

To start build the project you  need to make sure you installed:
* Make sure that .Net framework 4.5 installed
* Unity package for applying DI
** it should be installed in project, and in case it's not you can simply installed with the following command in Package Manager Console at visual studio ```Install-Package Unity.Mvc3```

## Solution Details and Design
This solution based on MVC design pattern, as Controller layer calls the business logic layer and retrieve object that contains service response and the model in case of success calling. 
And business logic layer calls the service and bind it's response into model objects, which should be used in view layer (currently there is no view layer, and model binded in response result object). 
### QuestionsController
Controller layer calls the business logic layer, to return model object and assign it inside response object.
* ```AnswerQuestion(int questionNumber)``` return an ```AnswerResponse``` object which contains and answer for selected question.
* ```GetHolidays(int year, string countryCode)``` return ```PublicHolidayResponse``` which contains list of Holidays for selected country at selected year.
* ```GetHolidaysByYear(int year)``` return ```CountryPublicHolidayResponse``` which contains all holidays for all countries at selected year.
* Throttle to each controller assigned to be 5 seconds for each call

### PublicHolidaysBL
Business logic layer calls the service layer directly in order to retrieve any data needed while applying any logic
* ```GetMaxHolidaysCountry(int year)``` returns the country which contains maximum number of holidays at selected year.
* ```GetMaxHolidaysMonthGlobally(int year)``` return maximum month contains globally holidays across all countries.
* ```GetMaxUniqueHolidaysCountry(int year)``` return maximum country that contains holidays that no other country had these holidays.
* ```GetCountryPublicHoliday(int year, string countryCode)``` return list of holidays for selected country at selected year.
* ```GetCountryPublicHolidayByYear(int year)``` return list of all holidays across all countries at selected year.

### PublicHolidaysService
Service layer that calls nager api directly and and return service response that contains response result binded to model object.
* ```GetPublicHolidays(int year, string countryCode)``` call nager api with ```year``` and ```countryCode``` to return holiday for selected parameters
* ```GetPublicHolidaysByYear(int year)``` call nager with with ```year``` and pass all countries codes and return list of countries with list of holidays for each one.

## Utilities
Any utilites class or methods used in application, for example: 
* ```Helper.GetCountriesCodes()``` return list of countries codes that any layer could use it.
* ```Helper.IsCountryCodeValid(string countryCode)``` return if this ```countryCode``` is valid to pass to service.

## Technologies used


* MSTest .Net framework
* Dependency Injection
* Jquery
* Bootstrap

## Future work
* Build friendly view layer with angular 2+ that uses these controllers to view holidays in calendar for selected country and year.
* Provide more business logic functions to list some insights, e.g. most and least countries in holidays, holidays by months in each country, common holidays between two countries and so on.

## Author

* **Moustafa Attia** - *Software Engineer .Net/C#* - [Moustafa Attia](https://github.com/MoustafaAttia)

## Acknowledgments

* [Request throttling in .NET Core MVC](https://www.johanbostrom.se/blog/request-throttling-in-net-core-mvc-and-api) used in ThrottleAttribute.cs
