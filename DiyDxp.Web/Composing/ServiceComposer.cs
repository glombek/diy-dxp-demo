using DiyDxp.Web.Models.Configuration;
using DiyDxp.Web.Services;
using DiyDxp.Web.Services.Implement;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Services;

namespace DiyDxp.Web.Composing
{
    public class ServiceComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddSingleton<ICrmService, DummyCrmService>();
            builder.Services.AddHttpClient<IFirstNameInfoService, DemografixService>();
            builder.Services.AddHttpClient<ISupportTickettingService, MySupportAppService>();
            builder.Services.AddOptions<MySupportAppConfig>().Bind(builder.Config.GetSection("DiyDxp:MySupportApp"));
        }
    }
}
