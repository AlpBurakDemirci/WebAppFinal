using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using WebAppFinal.Models;

namespace WebAppFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static List<Kisi> kisis = new List<Kisi>();
        public List<School> schools = new List<School>();
        public List<Food> foods = new List<Food>();

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
        public void CreateEverything(string name, string surname, int age, string schoolName, string schoolCity, string schoolDistrict, int schoolScore, string foodName, string foodType, int foodCost)
        {
            CreateKisi();
            AddToKisi(name, surname, age);
            CreateFood(foodName, foodType, foodCost);
            CreateSchool(schoolName, schoolCity, schoolDistrict, schoolScore);
        }

        [HttpPost]
        public void CreateKisi() 
        { 
        
            Kisi kisi = new Kisi();
            kisis.Add(kisi);

        }

        [HttpPost]
        public void AddToKisi(string name,string surname,int age)
        {
            kisis.Last<Kisi>().Name = name;
            kisis.Last<Kisi>().Surname = surname;
            kisis.Last<Kisi>().Age = age;
            kisis.Last<Kisi>().Schools = schools;
            kisis.Last<Kisi>().Foods = foods;
        }
        [HttpPost]
        public void CreateFood(string foodName, string foodType, int foodCost)
        {
            Food fd = new Food();
            fd.Name = foodName;
            fd.Type = foodType;
            fd.Cost = foodCost;
            foods.Add(fd);
        }

        [HttpPost]
        public void CreateSchool(string schoolName, string schoolCity, string schoolDistrict, int schoolScore)
        {
            School sc = new School();
            sc.Name = schoolName;
            sc.City = schoolCity;
            sc.District = schoolDistrict;
            sc.Score = schoolScore;
            schools.Add(sc);
        }
        public IActionResult ShowKisiList(string inputName, string inputSurname, int inputAge, string schoolName, string schoolCity, string schoolDistrict, int schoolScore, string foodName, string foodType, int foodCost)
        {
            CreateEverything(inputName, inputSurname, inputAge, schoolName, schoolCity, schoolDistrict, schoolScore, foodName, foodType, foodCost);
            return View(kisis);
        }

    }
}