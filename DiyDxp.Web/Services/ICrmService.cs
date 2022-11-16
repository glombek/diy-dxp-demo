namespace DiyDxp.Web.Services
{
    public interface ICrmService
    {
        Task<IDictionary<string, string>> GetCountries();
    }
}
