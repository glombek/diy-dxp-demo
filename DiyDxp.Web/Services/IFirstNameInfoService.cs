namespace DiyDxp.Web.Services
{
    public interface IFirstNameInfoService
    {
        Task<int> GuessAge(string firstName);
        Task<(string Gender, double Probability)> GuessGender(string firstName);
        Task<IDictionary<string, double>> GuessNationality(string firstName);
    }
}
