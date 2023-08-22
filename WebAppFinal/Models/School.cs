namespace WebAppFinal.Models
{
    public class School
    {
        public string SchoolName { get; set; }
        public string SchoolCity { get; set; }
        public string SchoolDistrict { get; set; }
        public int SchoolScore { get; set; }

        public School(string SchoolName, string SchoolCity, string SchoolDistrict, int SchoolScore)
        {
            this.SchoolName = SchoolName;
            this.SchoolCity = SchoolCity;
            this.SchoolDistrict = SchoolDistrict;
            this.SchoolScore = SchoolScore;

        }
    }
}
