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
        public static int kisisLength = 0;
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
            kisisLength++;
            string Name = bindingContext.HttpContext.Request.Form["Name"].ToString();
            string Surname = bindingContext.HttpContext.Request.Form["Surname"].ToString();
            int Age = Convert.ToInt32(bindingContext.HttpContext.Request.Form["Age"].ToString());

            if (Convert.ToInt32(bindingContext.HttpContext.Request.Form["Id"].ToString()) == 0)
            {
                int Id = kisisLength - 1;
                return new Kisi(Id, Name, Surname, Age);
            }
            else
            {
                int Id = Convert.ToInt32(bindingContext.HttpContext.Request.Form["Id"].ToString());
                return new Kisi(Id, Name, Surname, Age);
            }
        }

        public School BindModel1(ModelBindingContext bindingContext)
        {
            int SchoolId = Convert.ToInt32(bindingContext.HttpContext.Request.Form["SchoolId"].ToString());
            string SchoolName = bindingContext.HttpContext.Request.Form["SchoolName"].ToString();
            string SchoolCity = bindingContext.HttpContext.Request.Form["SchoolCity"].ToString();
            string SchoolDistrict = bindingContext.HttpContext.Request.Form["SchoolDistrict"].ToString();
            int SchoolScore = Convert.ToInt32(bindingContext.HttpContext.Request.Form["SchoolScore"].ToString());
            School school = new(SchoolId,SchoolName, SchoolCity, SchoolDistrict, SchoolScore);
            
            return school;
        
        }

         

        public Food BindModel2(ModelBindingContext bindingContext)
        {
            int FoodId = Convert.ToInt32(bindingContext.HttpContext.Request.Form["FoodId"].ToString());
            string FoodName = bindingContext.HttpContext.Request.Form["FoodName"].ToString();
            string FoodType = bindingContext.HttpContext.Request.Form["FoodType"].ToString();
            int FoodCost = Convert.ToInt32(bindingContext.HttpContext.Request.Form["FoodCost"].ToString());
            Food food = new(FoodId,FoodName, FoodType, FoodCost);
           
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
            
            int schoolCount = Convert.ToInt32(bindingContext.HttpContext.Request.Form["schoolCount"].ToString());
            
            for (int i = 0; i < schoolCount; i++)
            {
                int SchoolId = Convert.ToInt32(bindingContext.HttpContext.Request.Form[$"{i}.SchoolId"].ToString());
                string SchoolName = bindingContext.HttpContext.Request.Form[$"{i}.SchoolName"].ToString();
                string SchoolCity = bindingContext.HttpContext.Request.Form[$"{i}.SchoolCity"].ToString();
                string SchoolDistrict = bindingContext.HttpContext.Request.Form[$"{i}.SchoolDistrict"].ToString();
                int SchoolScore = Convert.ToInt32(bindingContext.HttpContext.Request.Form[$"{i}.SchoolScore"].ToString());
                School school = new(SchoolId, SchoolName, SchoolCity, SchoolDistrict, SchoolScore);
                schools.Add(school);
            }
            
            int foodCount = Convert.ToInt32(bindingContext.HttpContext.Request.Form["foodCount"].ToString());
            
            for (int i = 0; i < foodCount; i++)
            {

                int FoodId = Convert.ToInt32(bindingContext.HttpContext.Request.Form[$"{i}.FoodId"].ToString());
                string FoodName = bindingContext.HttpContext.Request.Form[$"{i}.FoodName"].ToString();
                string FoodType = bindingContext.HttpContext.Request.Form[$"{i}.FoodType"].ToString();
                int FoodCost = Convert.ToInt32(bindingContext.HttpContext.Request.Form[$"{i}.FoodCost"].ToString());
                Food food = new(FoodId, FoodName, FoodType, FoodCost);
                foods.Add(food);
            }

            return new Kisi(Id,Name, Surname, Age, schools, foods);

        }
    }
}