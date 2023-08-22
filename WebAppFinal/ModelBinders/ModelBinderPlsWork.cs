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
        public static List<School> Schools { get; set; } = new();
        public static List<Food> Foods { get; set; } = new();
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
            }
        }
        public Kisi BindModel0(ModelBindingContext bindingContext)
        {
            string Name = bindingContext.HttpContext.Request.Form["Name"].ToString();
            string Surname = bindingContext.HttpContext.Request.Form["Surname"].ToString();
            int Age = Convert.ToInt32(bindingContext.HttpContext.Request.Form["Age"].ToString());

            return new Kisi(Name, Surname, Age);
        }

        public School BindModel1(ModelBindingContext bindingContext)
        {
            string SchoolName = bindingContext.HttpContext.Request.Form["SchoolName"].ToString();
            string SchoolCity = bindingContext.HttpContext.Request.Form["SchoolCity"].ToString();
            string SchoolDistrict = bindingContext.HttpContext.Request.Form["SchoolDistrict"].ToString();
            int SchoolScore = Convert.ToInt32(bindingContext.HttpContext.Request.Form["SchoolScore"].ToString());
            School school = new(SchoolName, SchoolCity, SchoolDistrict, SchoolScore);
         
            Schools.Add(school);
            
            return school;
        
        }

         

        public Food BindModel2(ModelBindingContext bindingContext)
        {       
            string FoodName = bindingContext.HttpContext.Request.Form["FoodName"].ToString();
            string FoodType = bindingContext.HttpContext.Request.Form["FoodType"].ToString();
            int FoodCost = Convert.ToInt32(bindingContext.HttpContext.Request.Form["FoodCost"].ToString());
            Food food = new(FoodName, FoodType, FoodCost);
            
            Foods.Add(food);
            
            return food;

        }
    }
}