using DiyDxp.Web.Services;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace DiyDxp.Web.Notifications
{
    public class GuessMemberDetailsMemberSavingNotification : INotificationHandler<MemberSavingNotification>
    {
        private readonly IFirstNameInfoService _firstNameInfoService;

        public GuessMemberDetailsMemberSavingNotification(IFirstNameInfoService firstNameInfoService)
        {
            _firstNameInfoService = firstNameInfoService;
        }

        public void Handle(MemberSavingNotification notification)
        {
            foreach (var member in notification.SavedEntities)
            {
                var firstName = member.Name?.Split(' ').FirstOrDefault();

                if (!string.IsNullOrWhiteSpace(firstName))
                {
                    // This is a terrible idea, but it's just a demo
                    if (member.GetValue<int?>("age") == null)
                    {
                        member.SetValue("age", _firstNameInfoService.GuessAge(firstName).Result);
                    }

                    // We _really_ ought not to be doing this
                    if (string.IsNullOrWhiteSpace(member.GetValue<string>("gender")))
                    {
                        member.SetValue("gender", _firstNameInfoService.GuessGender(firstName).Result.Item1);
                    }
                }
            }
        }
    }
}
