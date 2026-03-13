using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace OptimizelyDemo.Common.Models.Pages
{
    [ContentType(DisplayName = "Base Page", GUID = "eec34d74-36b0-43ed-869c-25b27613877e")]
    public class BasePage : PageData
    {
        [Display(Name = "Components", GroupName = SystemTabNames.Content, Order = 1)]
        public virtual ContentArea? Components { get; set; }
    }
    
}
