namespace DiyDxp.Web.Services
{
    public interface ISupportTickettingService
    {
        Task CreateTicket(string? name, string emailAddress, string message);
    }
}
