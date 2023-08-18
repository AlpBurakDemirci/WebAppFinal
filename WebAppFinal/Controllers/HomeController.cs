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
        public IActionResult ShowKisiList(string inputName, string inputSurname, int inputAge,string futs,string skul)
        {
            Kisi kisi = new Kisi();
            kisis.Add(kisi);
            while (!string.IsNullOrEmpty(futs))
            {
                int semicolonIndex = futs.IndexOf(';');
                Food fd = new Food();
                
                    fd.Name = futs.Substring(0, semicolonIndex);
                    futs = futs.Substring(semicolonIndex + 1);
                    semicolonIndex = futs.IndexOf(';');
                
                    fd.Type = futs.Substring(0, semicolonIndex);
                    futs = futs.Substring(semicolonIndex + 1);
                    semicolonIndex = futs.IndexOf(';');
                
                    fd.Cost = int.Parse(futs.Substring(0, semicolonIndex));
                    futs = futs.Substring(semicolonIndex + 1);
                    
                    kisis.Last<Kisi>().Foods.Add(fd);
            }
            while (!string.IsNullOrEmpty(skul))
                {
                    School sc = new School();
                    int semicolonIndex = skul.IndexOf(';');

                    sc.Name = skul.Substring(0, semicolonIndex);
                    skul = skul.Substring(semicolonIndex + 1);
                    semicolonIndex = skul.IndexOf(';');

                    sc.City = skul.Substring(0, semicolonIndex);
                    skul = skul.Substring(semicolonIndex + 1);
                    semicolonIndex = skul.IndexOf(';');

                    sc.District = skul.Substring(0, semicolonIndex);
                    skul = skul.Substring(semicolonIndex + 1);
                    semicolonIndex = skul.IndexOf(';');

                    sc.Score = int.Parse(skul.Substring(0, semicolonIndex));
                    skul = skul.Substring(semicolonIndex + 1);
                    
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