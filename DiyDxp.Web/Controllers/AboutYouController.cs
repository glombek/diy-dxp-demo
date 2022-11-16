using DiyDxp.Web.Models.ViewModel;
using DiyDxp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using StackExchange.Profiling.Internal;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;

namespace DiyDxp.Web.Controllers
{
    public class AboutYouController : RenderController
    {
        private readonly IFirstNameInfoService _firstNameInfoService;
        private readonly IVariationContextAccessor _variationContextAccessor;
        private readonly ServiceContext _serviceContext;
        public AboutYouController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, IFirstNameInfoService firstNameInfoService, IVariationContextAccessor variationContextAccessor, ServiceContext serviceContext) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _firstNameInfoService = firstNameInfoService;
            _variationContextAccessor = variationContextAccessor;
            _serviceContext = serviceContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? name)
        {
            var model = CurrentPage != null ? new AboutYouViewModel(
                            CurrentPage,
                            new PublishedValueFallback(_serviceContext, _variationContextAccessor)
                            ) : null;

            if (model != null && name != null)
            {
                model.PersonName = name;
                model.Age = await _firstNameInfoService.GuessAge(name);
                model.Gender = await _firstNameInfoService.GuessGender(name);
                model.Nationality = await _firstNameInfoService.GuessNationality(name);
            }

            // We ought to cache this result

            return CurrentTemplate(model);
        }
    }
}
