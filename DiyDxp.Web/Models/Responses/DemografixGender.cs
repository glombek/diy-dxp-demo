namespace DiyDxp.Web.Models.Responses
{
    public class DemografixGender
    {
        public int Count { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Probability { get; set; }
    }
}
