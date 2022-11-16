namespace DiyDxp.Web.Services.Implement
{
    public class DummyCrmService : ICrmService
    {
        public async Task<IDictionary<string, string>> GetCountries()
        {
            //In real life, this would make a call the the API of my CRM

            Thread.Sleep(30 * 1000);

            return new Dictionary<string, string>
            {
                { "gb", "United Kingdom" },
                { "dk", "Denmark" },
                { "us", "United States of America" }
            };
        }
    }
}
