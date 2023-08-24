using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;

namespace WebAppFinal.Models
{
    [ModelBinder(BinderType = typeof(ModelBinders.ModelBinderPlsWork))]
    public class Kisi
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int? Age { get; set; }
        public List<School>? SchoolList { get; set; } = new List<School>();
        public List<Food>? FoodList { get; set; } = new List<Food>();
        public Kisi() { }

        public Kisi(string Name, string Surname, int Age, int Id)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
            this.Id = Id;
        }
        public Kisi(string Name, string Surname, int Age, List<School> SchoolList)
        {
            this.Name = Name;
            this.Surname= Surname;
            this.Age = Age;
            for (int i = 0; i < SchoolList.Count; i++)
            {
                School fakeSchool = new(SchoolList[i].SchoolId,SchoolList[i].SchoolName, SchoolList[i].SchoolCity, SchoolList[i].SchoolDistrict, SchoolList[i].SchoolScore);
                this.SchoolList.Add(fakeSchool);
            }
        }
        public Kisi(string Name, string Surname, int Age, List<School> SchoolList, List<Food> FoodList) 
        { 
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
            for (int i = 0; i < SchoolList.Count; i++) {
                School fakeSchool = new(SchoolList[i].SchoolId,SchoolList[i].SchoolName, SchoolList[i].SchoolCity, SchoolList[i].SchoolDistrict, SchoolList[i].SchoolScore);
                this.SchoolList.Add(fakeSchool);    
            }
            for (int i = 0; i <FoodList.Count; i++)
            {
                Food fakeFood = new(FoodList[i].FoodId,FoodList[i].FoodName, FoodList[i].FoodType, FoodList[i].FoodCost);
                this.FoodList.Add(fakeFood);
            }
        }
        
    }
}
