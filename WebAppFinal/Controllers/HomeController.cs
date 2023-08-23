﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppFinal.Models;

namespace WebAppFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static List<Kisi> kisis = new();
        public static List<School> SchoolList = new();
        public static List<Food> FoodList = new();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            SchoolList.Clear();
            FoodList.Clear();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult CreateKisi([ModelBinder(typeof(ModelBinders.ModelBinderPlsWork))] Kisi kisi)
        {
            kisis.Add(kisi);
            return RedirectToAction("SchoolView");
        }

        [HttpGet]
        public IActionResult SchoolView()
        {

            return View();
        
        }

        [HttpPost]

        public IActionResult SchoolView([ModelBinder(typeof(ModelBinders.ModelBinderPlsWork))] School school)
        {

            SchoolList.Add(school);
            return RedirectToAction("OtherSchool");

        }

        [HttpGet]
        public IActionResult OtherSchool()
        {

            return View();
        
        }

        [HttpPost]
        public IActionResult OtherSchool(Boolean YesNo)
        {
            if (YesNo){

                return RedirectToAction("SchoolView");
            
            }
            
            else { 
            
                return RedirectToAction("FoodView"); 
            
            }
        }


        [HttpGet]
        public IActionResult FoodView()
        {

            return View();

        }

        [HttpPost]
        public IActionResult FoodView([ModelBinder(typeof(ModelBinders.ModelBinderPlsWork))] Food food)
        {
            FoodList.Add(food);
            return RedirectToAction("OtherFood");

        }
        [HttpGet]
        public IActionResult OtherFood()
        {

            return View();

        }

        [HttpPost]
        public IActionResult OtherFood(Boolean YesNo)
        {
            if (YesNo)
            {

                return RedirectToAction("FoodView");

            }

            else
            {

                return RedirectToAction("ShowKisiList");

            }
        }
        [HttpGet]

        public IActionResult ShowKisiList()
        {
            int kisiId = kisis.Count() - 1;
            foreach (School school in SchoolList) {
                kisis[kisiId].SchoolList.Add(school);                   
            }
            foreach (Food food in FoodList)
            {
                kisis[kisiId].FoodList.Add(food);
            }
            return View(kisis);

        }
    }
}
