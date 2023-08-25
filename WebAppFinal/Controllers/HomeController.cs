using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using WebAppFinal.Models;

namespace WebAppFinal.Controllers
{   
    public class HomeController : Controller
    {   
        private readonly ILogger<HomeController> _logger;

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
            var Db = new DataBaseDEMO();
            return View(Db.Kisiler.Count() + 1);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult CreateKisi([ModelBinder(typeof(ModelBinders.ModelBinderPlsWork))] Kisi kisi)
        {
            var Db = new DataBaseDEMO();
            Db.Add(kisi);
            Db.SaveChanges();
            return RedirectToAction("SchoolView");
        }

        [HttpGet]
        public IActionResult SchoolView()
        {
            var Db = new DataBaseDEMO();
            Tuple<int, int> tuple = new(Db.Okullar.Count() + 1, Db.Kisiler.Count());
            return View(tuple);
        
        }

        [HttpPost]

        public IActionResult SchoolView([ModelBinder(typeof(ModelBinders.ModelBinderPlsWork))] School school)
        {
            var Db = new DataBaseDEMO();
            Db.Add(school);
            Db.SaveChanges();
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

            var Db = new DataBaseDEMO();
            Tuple<int, int> tuple = new(Db.Yiyecekler.Count() + 1, Db.Kisiler.Count());
            return View(tuple);

        }

        [HttpPost]
        public IActionResult FoodView([ModelBinder(typeof(ModelBinders.ModelBinderPlsWork))] Food food)
        {
            var Db = new DataBaseDEMO();
            Db.Add(food);
            Db.SaveChanges();
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
            return View();

        }

        [HttpPost]
        public IActionResult ShowKisiList(int kisiIndex)
        {
            return RedirectToAction("EditKisi",new { kisiIndex }) ;

        }

        [HttpGet]
        public IActionResult EditKisi(int kisiIndex)
        {

            return View(kisiIndex);

        }

        [HttpPost]
        public IActionResult EditKisi([ModelBinder(typeof(ModelBinders.ModelBinderPlsWork))] Kisi kisi)
        {
            var Db = new DataBaseDEMO();
            {
                Db.Kisiler.Entry(Db.Kisiler.First(k => k.Id == kisi.Id)).CurrentValues.SetValues(kisi);
                foreach (var school in kisi.SchoolList){

                    Db.Okullar.Entry(Db.Okullar.First(s => s.SchoolId == school.SchoolId)).CurrentValues.SetValues(school);
                }
                foreach (var food in kisi.FoodList){

                    Db.Yiyecekler.Entry(Db.Yiyecekler.First(f => f.FoodId == food.FoodId)).CurrentValues.SetValues(food);
                }
                Db.SaveChanges();
                return RedirectToAction("ShowKisiList");
            }
        }
    }
}
