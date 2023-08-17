namespace WebAppFinal.Models
{
    public class Kisi
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int? Age { get; set; }
        public List<School> Schools { get; set; }
        public List<Food> Foods { get; set; }
    
    public Kisi()
        {
            this.Name = string.Empty;
            this.Surname = string.Empty;
            this.Age = 0;
            this.Schools = new List<School>();
            this.Foods = new List<Food>();
        }
    
    }
}
