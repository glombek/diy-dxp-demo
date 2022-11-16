using DiyDxp.Web.Models.Responses;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http;

namespace DiyDxp.Web.Services.Implement
{
    public class DemografixService : IFirstNameInfoService
    {
        private readonly HttpClient _client;

        public DemografixService(HttpClient client)
        {
            _client = client;
        }
        
        public async Task<int> GuessAge(string firstName)
        {
            var res = await _client.GetFromJsonAsync<DemografixAge>(QueryHelpers.AddQueryString("https://api.agify.io/", "name", firstName));
            return res?.Age ?? -1;
        }

        public async Task<(string, double)> GuessGender(string firstName)
        {
            var res = await _client.GetFromJsonAsync<DemografixGender>(QueryHelpers.AddQueryString("https://api.genderize.io/", "name", firstName));
            return (res?.Gender ?? "unknown", res?.Probability ?? -1);
        }

        public async Task<IDictionary<string, double>> GuessNationality(string firstName)
        {
            var res = await _client.GetFromJsonAsync<DemografixCountries>(QueryHelpers.AddQueryString("https://api.nationalize.io/", "name", firstName));
            return res?.Country.ToDictionary(x => x.CountryCode, x => x.Probability) ?? new Dictionary<string, double>();
        }
    }
}
