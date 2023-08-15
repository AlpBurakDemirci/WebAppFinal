namespace WebAppFinal.Models
{
    public class Kisi
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public List<School> Schools { get; set; }
        public List<Food> Foods { get; set; }
    }
}
