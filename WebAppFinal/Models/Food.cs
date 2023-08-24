namespace WebAppFinal.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodType { get; set; }
        public int FoodCost { get; set; }

        public Food(int FoodId,string FoodName, string FoodType, int FoodCost)
        {
            this.FoodId = FoodId;
            this.FoodName = FoodName;
            this.FoodType = FoodType;
            this.FoodCost = FoodCost;
        }
    }
}
