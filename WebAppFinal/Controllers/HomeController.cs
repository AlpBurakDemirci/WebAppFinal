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
        public IActionResult ShowKisiList(string inputName, string inputSurname, int inputAge, Food[] futs, School[] skul)
        {
            Kisi kisi = new Kisi();
            kisis.Add(kisi);
            for (int f = 0 ; f < futs.Length; f++)
            {
                Food fd = new Food();
                fd.Name = futs[f].Name;
                fd.Type = futs[f].Type;
                fd.Cost = futs[f].Cost;
                kisis.Last<Kisi>().Foods.Add(fd);
            }
            for (int s = 0 ; s < skul.Length; s++)
            {
                School sc = new School();
                sc.Name = skul[s].Name;
                sc.City = skul[s].City;
                sc.District = skul[s].District;
                sc.Score = skul[s].Score;
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