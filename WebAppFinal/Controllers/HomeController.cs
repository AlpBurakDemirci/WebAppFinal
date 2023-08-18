using System;
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
        public static List<Kisi> kisis = new List<Kisi>();
        public List<School> schools = new List<School>();
        public List<Food> foods = new List<Food>();
        //food ve school u test sonrası staticledim , bunu test etmedim daha
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
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult ShowKisiList(string inputName, string inputSurname, int inputAge, string foodData, string schoolData)
        {
            Kisi kisi = new Kisi();
            kisis.Add(kisi);
            while (!string.IsNullOrEmpty(foodData))
            {
                int semicolonIndex = foodData.IndexOf(';');
                Food fd = new Food();
                
                    fd.Name = foodData.Substring(0, semicolonIndex);
                    foodData = foodData.Substring(semicolonIndex + 1);
                    semicolonIndex = foodData.IndexOf(';');
                
                    fd.Type = foodData.Substring(0, semicolonIndex);
                    foodData = foodData.Substring(semicolonIndex + 1);
                    semicolonIndex = foodData.IndexOf(';');
                
                    fd.Cost = int.Parse(foodData.Substring(0, semicolonIndex));
                    foodData = foodData.Substring(semicolonIndex + 1);
                    
                    kisis.Last<Kisi>().Foods.Add(fd);
            }
            while (!string.IsNullOrEmpty(schoolData))
                {
                    School sc = new School();
                    int semicolonIndex = schoolData.IndexOf(';');

                    sc.Name = schoolData.Substring(0, semicolonIndex);
                    schoolData = schoolData.Substring(semicolonIndex + 1);
                    semicolonIndex = schoolData.IndexOf(';');

                    sc.City = schoolData.Substring(0, semicolonIndex);
                    schoolData = schoolData.Substring(semicolonIndex + 1);
                    semicolonIndex = schoolData.IndexOf(';');

                    sc.District = schoolData.Substring(0, semicolonIndex);
                    schoolData = schoolData.Substring(semicolonIndex + 1);
                    semicolonIndex = schoolData.IndexOf(';');

                    sc.Score = int.Parse(schoolData.Substring(0, semicolonIndex));
                    schoolData = schoolData.Substring(semicolonIndex + 1);
                    
                    kisis.Last<Kisi>().Schools.Add(sc);
                }
                kisis.Last<Kisi>().Name = inputName;
                kisis.Last<Kisi>().Surname = inputSurname;
                kisis.Last<Kisi>().Age = inputAge;
                return View(kisis);

            }


        }
}



// 1 kişi per 1 school/food tam çalışıyor
// 1 kişi per 2 school/food 1.school/food u unutuyor
// 2 kişi per 1 school/food tam çalışıyor
// 2 kişi per 2 school/food 1.school/food u unutuyor