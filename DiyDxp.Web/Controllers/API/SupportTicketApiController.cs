using DiyDxp.Web.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common.Controllers;

namespace DiyDxp.Web.Controllers.API;

public class SupportTicketApiController : UmbracoApiController // In Umbraco 9+ this only provides routing, no service access.
{
    // We gain access to services by injecting them
    private readonly IContentService _contentService;
    private readonly IContentTypeService _contentTypeService;
    public SupportTicketApiController(IContentService contentService, IContentTypeService contentTypeService)
    {
        _contentService = contentService;
        _contentTypeService = contentTypeService;
    }

[HttpPost]
public IActionResult Create(SupportTicketRequest ticket)
{
    if(!ModelState.IsValid)
        return BadRequest(ModelState);

    var ticketContainerType = _contentTypeService.Get("supportTicketContainer");
    if(ticketContainerType == null)
        return StatusCode(StatusCodes.Status500InternalServerError);

    var ticketContainer = _contentService.GetPagedOfTypes(new[] { ticketContainerType.Id }, 0, 1, out _, null).FirstOrDefault();
    if (ticketContainer == null)
        return StatusCode(StatusCodes.Status500InternalServerError);

    var content = _contentService.Create("Support Ticket", ticketContainer.Id, "supportTicket");
    content.Name = $"{ticket.Name ?? ticket.EmailAddress} ({ticket.EmailAddress}) - {DateTime.UtcNow:s} - {content.Key}";
    content.SetValue("personName", ticket.Name);
    content.SetValue("personEmail", ticket.EmailAddress);
    content.SetValue("message", ticket.Message);
    _contentService.SaveAndPublish(content);

    return Ok();
}
}

