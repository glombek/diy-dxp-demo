using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Dashboards;

namespace DiyDxp.Web.Dashboards;

[Weight(-10)]
public class MySupportAppDashboard : IDashboard
{
    public string Alias => "mySupportAppDashboard";

    public string[] Sections => new[]
    {
        Constants.Applications.Content
    };

    public string View => "/App_Plugins/mySupportAppDashboard/dashboard.html";

    public IAccessRule[] AccessRules => Array.Empty<IAccessRule>();

}
