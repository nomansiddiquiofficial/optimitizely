using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace OptimizelyDemo.Common.Models.Pages.Api.Request
{
    [ContentType(DisplayName = "Event Api Page", GUID = "ecc34d74-36b0-43cd-869c-25e27613877e")]
    public class EventApiPage : PageData
    {
        [Display(
            Name = "Heading",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string? Heading { get; set; }

        [Display(
             Name = "Page Size",
             GroupName = SystemTabNames.Content,
             Order = 2)]
        public virtual int? PageSize{ get; set; }

    }
}