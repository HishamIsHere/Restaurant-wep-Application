using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using WebAppTemplate.Models;

namespace RestaurantWebApp22092026.Models
{
    public class TransactionNewsLetter : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public DateTime SendingDate { get; set; } = DateTime.Now;
    }
}
