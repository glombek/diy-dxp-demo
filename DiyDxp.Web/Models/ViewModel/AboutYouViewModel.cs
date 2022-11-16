using Umbraco.Cms.Core.Models.PublishedContent;

namespace DiyDxp.Web.Models.ViewModel
{
    public class AboutYouViewModel : PublishedContentWrapped
    {
        public AboutYouViewModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }

        public string? PersonName { get; set; }
        public int? Age { get; set; }
        public (string, double)? Gender { get; set; }
        public IDictionary<string, double>? Nationality { get; set; }
    }
}
