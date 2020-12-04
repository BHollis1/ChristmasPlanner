# ChristmasPlanner ASP.NET MVC
> Christmas Planner is an app designed to make the holiday season less stressful by keeping track of gift buying and card sending for you! 
## Table of contents
* [General info](#general-info)
* [Screenshots](#screenshots)
* [Technologies](#technologies)
* [Setup](#setup)
* [Features](#features)
* [Status](#status)
* [Inspiration](#inspiration)
* [Contact](#contact)

## General info
My husband and I have 8 children. Needless to say, we start wrapping gifts at least a month or two before Christmas to ensure we are complete by the time Christmas rolls around (and, that we're not stressed out of our minds). However, wrapping gifts early means that by the time it's Christmas, I have fogotten what I've bought for each child AND how many gifts for each child. This app allows me to keep track by simply entering the names of everyone I need to buy a gift for OR send a card to. Then, as I buy gifts, I can enter the gift I bought OR simply check off that I have bought that person a gift OR sent that person a card.


## Screenshots
![](https://github.com/BHollis1/ChristmasPlanner/blob/master/ChristmasPlanner.WebMVC/Content/Images/2020-12-04.png)
![](https://github.com/BHollis1/ChristmasPlanner/blob/master/ChristmasPlanner.WebMVC/Content/Images/2020-12-04%20(1).png)
![](https://github.com/BHollis1/ChristmasPlanner/blob/master/ChristmasPlanner.WebMVC/Content/Images/2020-12-04%20(2).png)

## Technologies
* Visual Studio 2019


## Setup
![](https://christmasplanner.azurewebsites.net)

## Code Examples
public ActionResult Create()
        {
            var db = new PersonService();
            ViewBag.PersonID = new SelectList(db.GetPerson().OrderBy(e => e.FullName), "PersonID", "FullName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(GiftCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGiftService();

            if (service.CreateGift(model))
            {
                TempData["SaveResult"] = "Gift was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "New Gift could not be created.");

            return View(model);
        }

## Features
* Dropdown list of names
* Added buttons to make navigation easier for the user


To-do list:
* Add birthday feature
* Add more options on each page

## Status
This project is the final project to graduate from bootcamp. So, it is complete from a school perspective as it meets the requirements. However, I will continue to update and add new features (ie, birthdays). 

## Inspiration
My children were the inspiration. :)

## Contact
Created by [@bhollis1](https://github.com/BHollis1) - feel free to contact me!
