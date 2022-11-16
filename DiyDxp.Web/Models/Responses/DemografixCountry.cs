using System.Text.Json.Serialization;

namespace DiyDxp.Web.Models.Responses
{
    public class DemografixCountry
    {
        [JsonPropertyName("country_id")]
        public string CountryCode { get; set; } = string.Empty;
        public double Probability { get; set; }
    }
}
