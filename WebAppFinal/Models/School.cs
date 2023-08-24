namespace WebAppFinal.Models
{
    public class School
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolCity { get; set; }
        public string SchoolDistrict { get; set; }
        public int SchoolScore { get; set; }

        public School(int SchoolId,string SchoolName, string SchoolCity, string SchoolDistrict, int SchoolScore)
        {
            this.SchoolId = SchoolId;
            this.SchoolName = SchoolName;
            this.SchoolCity = SchoolCity;
            this.SchoolDistrict = SchoolDistrict;
            this.SchoolScore = SchoolScore;

        }
    }
}
