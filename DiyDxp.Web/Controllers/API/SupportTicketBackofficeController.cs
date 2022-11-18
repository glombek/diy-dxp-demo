using DiyDxp.Web.Models.Requests;
using DiyDxp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Controllers;

namespace DiyDxp.Web.Controllers.API;

public class SupportTicketBackofficeController : UmbracoAuthorizedJsonController
{
    private readonly ISupportTickettingService _supportTickettingService;
    public SupportTicketBackofficeController(ISupportTickettingService supportTickettingService)
    {
        _supportTickettingService = supportTickettingService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(SupportTicketRequest model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await _supportTickettingService.CreateTicket(model.Name, model.EmailAddress, model.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

        return Ok();
    }
}

