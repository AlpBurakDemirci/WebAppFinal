using System.ComponentModel;
using System.Linq.Expressions;
using System.Security;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppFinal.Models;

namespace WebAppFinal.ModelBinders
{
    public class ModelBinderPlsWork : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            switch (bindingContext.HttpContext.Request.Form["ghostCounter"])
            {  
                case "0":
                    bindingContext.Result = ModelBindingResult.Success(BindModel0(bindingContext));
                    break;
                case "1":
                    bindingContext.Result = ModelBindingResult.Success(BindModel1(bindingContext));
                    break;
                case "2":
                    bindingContext.Result = ModelBindingResult.Success(BindModel2(bindingContext));
                    break;
                case "3":
                    bindingContext.Result = ModelBindingResult.Success(BindModel3(bindingContext));
                    break;
            }
        }
        public Kisi BindModel0(ModelBindingContext bindingContext)
        {
            string Name = bindingContext.HttpContext.Request.Form["Name"].ToString();
            string Surname = bindingContext.HttpContext.Request.Form["Surname"].ToString();
            int Age = Convert.ToInt32(bindingContext.HttpContext.Request.Form["Age"].ToString());
            int Id = Convert.ToInt32(bindingContext.HttpContext.Request.Form["Id"].ToString());
            return new Kisi(Id, Name, Surname, Age);
        }

        public School BindModel1(ModelBindingContext bindingContext)
        {
            int SchoolId = Convert.ToInt32(bindingContext.HttpContext.Request.Form["SchoolId"].ToString());
            string SchoolName = bindingContext.HttpContext.Request.Form["SchoolName"].ToString();
            string SchoolCity = bindingContext.HttpContext.Request.Form["SchoolCity"].ToString();
            string SchoolDistrict = bindingContext.HttpContext.Request.Form["SchoolDistrict"].ToString();
            int SchoolScore = Convert.ToInt32(bindingContext.HttpContext.Request.Form["SchoolScore"].ToString());
            int WhoWentTo = Convert.ToInt32(bindingContext.HttpContext.Request.Form["WhoWentTo"].ToString());
            School school = new(SchoolId,SchoolName, SchoolCity, SchoolDistrict, SchoolScore, WhoWentTo);
            
            return school;
        
        }

         

        public Food BindModel2(ModelBindingContext bindingContext)
        {
            int FoodId = Convert.ToInt32(bindingContext.HttpContext.Request.Form["FoodId"].ToString());
            string FoodName = bindingContext.HttpContext.Request.Form["FoodName"].ToString();
            string FoodType = bindingContext.HttpContext.Request.Form["FoodType"].ToString();
            int FoodCost = Convert.ToInt32(bindingContext.HttpContext.Request.Form["FoodCost"].ToString());
            int WhoLovesIt = Convert.ToInt32(bindingContext.HttpContext.Request.Form["WhoLovesIt"].ToString());
            Food food = new(FoodId,FoodName, FoodType, FoodCost, WhoLovesIt);
           
            return food;

        }
        public Kisi BindModel3(ModelBindingContext bindingContext)
        {
            int Id = Convert.ToInt32(bindingContext.HttpContext.Request.Form["Id"].ToString());
            string Name = bindingContext.HttpContext.Request.Form["Name"].ToString();
            string Surname = bindingContext.HttpContext.Request.Form["Surname"].ToString();
            int Age = Convert.ToInt32(bindingContext.HttpContext.Request.Form["Age"].ToString());

            List<School> schools = new();
            List<Food> foods = new();
            var Db = new DataBaseDEMO();
            
            foreach (School school in Db.Okullar.Where(s => s.KisiId == Id))
            {
                int SchoolId = school.SchoolId;
                string SchoolName = bindingContext.HttpContext.Request.Form[$"{school.SchoolId}.SchoolName"].ToString();
                string SchoolCity = bindingContext.HttpContext.Request.Form[$"{school.SchoolId}.SchoolCity"].ToString();
                string SchoolDistrict = bindingContext.HttpContext.Request.Form[$"{school.SchoolId}.SchoolDistrict"].ToString();
                string fakeSchoolScore = bindingContext.HttpContext.Request.Form[$"{school.SchoolId}.SchoolScore"].ToString();//böyle yaptım çünkü int SchoolScore = Convert.ToInt32(bindingContext.HttpContext.Request.Form[$"{school.SchoolId}.SchoolScore"].ToString());  ÇALIŞMIYOR
                int SchoolScore = Convert.ToInt32(fakeSchoolScore);
                int KisiId = school.KisiId;
                School fakeSchool = new(SchoolId, SchoolName, SchoolCity, SchoolDistrict, SchoolScore, KisiId);
                schools.Add(fakeSchool);
            }
            
            
            foreach (Food food in Db.Yiyecekler.Where(f => f.KisiId == Id))
            {
                int FoodId = food.FoodId;
                string FoodName = bindingContext.HttpContext.Request.Form[$"{food.FoodId}.FoodName"].ToString();
                string FoodType = bindingContext.HttpContext.Request.Form[$"{food.FoodId}.FoodType"].ToString();
                string fakeFoodCost = bindingContext.HttpContext.Request.Form[$"{food.FoodId}.FoodCost"].ToString();//schoolscore ile aynı :(
                int FoodCost = Convert.ToInt32(fakeFoodCost);
                int KisiId = food.KisiId;
                Food fakeFood = new(FoodId, FoodName, FoodType, FoodCost, KisiId);
                foods.Add(fakeFood);
            }

            return new Kisi(Id, Name, Surname, Age, schools, foods);

        }
    }
}