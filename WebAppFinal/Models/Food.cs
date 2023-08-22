namespace WebAppFinal.Models
{
    public class Food
    {
        public string FoodName { get; set; }
        public string FoodType { get; set; }
        public int FoodCost { get; set; }

        public Food(string FoodName, string FoodType, int FoodCost)
        {
            this.FoodName = FoodName;
            this.FoodType = FoodType;
            this.FoodCost = FoodCost;
        }
    }
}
