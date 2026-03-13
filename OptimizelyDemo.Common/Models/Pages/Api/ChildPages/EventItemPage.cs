using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace OptimizelyDemo.Common.Models.Pages
{
    [ContentType(DisplayName = "Event Item Page", GUID = "ecc34d78-36b0-43cd-860c-25e27613877e")]
    [AvailableContentTypes(
    Availability = Availability.Specific,
    Include = new[] { typeof(EventItemPage) }
    )]
    public class EventItemPage : PageData
    {
        [Display(
            Name = "Heading",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string? Heading { get; set; }

        [UIHint(UIHint.Textarea)]
        [Display(
            Name = "Description",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual string? Description { get; set; }


        [UIHint(UIHint.Image)]

        [Display(Name = "Thumbanil Image", GroupName = SystemTabNames.Content, Order = 3)]
        public virtual ContentReference? ThumbnailImage { get; set; }


    }
}