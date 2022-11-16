using DiyDxp.Web.Notifications;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Notifications;

namespace DiyDxp.Web.Composing
{
    public class NotifcationComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.AddNotificationHandler<MemberSavingNotification,
                GuessMemberDetailsMemberSavingNotification>();
        }
    }
}
