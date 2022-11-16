using DiyDxp.Web.Services;
using System.Linq;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace DiyDxp.Web.Composing
{
public class UpdateCountriesComponent : IComponent
{
    private readonly ICrmService _crmService;
    private readonly IContentService _contentService;

    public UpdateCountriesComponent(ICrmService crmService, IContentService contentService)
    {
        _crmService = crmService;
        _contentService = contentService;
    }

public void Initialize()
{
    //Don't block startup!
    Task.Run(async () =>
    {
        try
        {
            var countries = await _crmService.GetCountries();
            var home = _contentService.GetRootContent()?.FirstOrDefault();
            if (home != null)
            {
                var oldCountries = home.GetValue("countries") as string;
                var newCountries = string.Join(Environment.NewLine, countries.Values);
                if (oldCountries != newCountries)
                {
                    home.SetValue("countries", newCountries);
                    _contentService.SaveAndPublish(home);
                }
            }
        }
        catch
        {
            // We don't care. But we should log it.
        }
    });
}

    public void Terminate() { }
}
}