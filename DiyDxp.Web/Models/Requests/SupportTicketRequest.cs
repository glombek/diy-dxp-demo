using System.ComponentModel.DataAnnotations;

namespace DiyDxp.Web.Models.Requests
{
    public class SupportTicketRequest
    {
        public string? Name { get; set; }

        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        public string Message { get; set; } = string.Empty;

    }
}
