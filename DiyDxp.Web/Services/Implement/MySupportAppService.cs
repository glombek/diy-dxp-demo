using DiyDxp.Web.Models.Configuration;
using DiyDxp.Web.Models.Requests;
using Microsoft.Extensions.Options;

namespace DiyDxp.Web.Services.Implement;

public class MySupportAppService : ISupportTickettingService
{
    private readonly HttpClient _httpClient;
    private readonly IOptions<MySupportAppConfig> _mySupportAppConfig;
    public MySupportAppService(HttpClient httpClient, IOptions<MySupportAppConfig> mySupportAppConfig)
    {
        _httpClient = httpClient;
        _mySupportAppConfig = mySupportAppConfig;

        if (_mySupportAppConfig.Value.BaseUrl != null)
        {
            httpClient.BaseAddress = new Uri(_mySupportAppConfig.Value.BaseUrl);
        }
    }

    public async Task CreateTicket(string? name, string emailAddress, string message)
    {
        var res = await _httpClient.PostAsJsonAsync("Create", new SupportTicketRequest() { Name = name, EmailAddress = emailAddress, Message = message });

        if (!res.IsSuccessStatusCode)
        {
            throw new Exception("Failed to create ticket." + Environment.NewLine + await res.Content.ReadAsStringAsync());
        }
    }
}

