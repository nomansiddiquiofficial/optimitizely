using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using OptimizelyDemo.Common.Models.Media;
using System.ComponentModel.DataAnnotations;

namespace OptimizelyDemo.Common.Models.Blocks
{
    [ContentType(DisplayName = "Hero Banner", GUID = "6cb36f2d-a57c-496f-8d12-0ec9de317b3f", GroupName = SystemTabNames.Content)]
    public class HeroBanner : BlockData
    {
        [Display(Name = "Heading", GroupName = SystemTabNames.Content, Order = 1)]
        public virtual string? Heading { get; set; }


        [Display(Name = "Description", GroupName = SystemTabNames.Content, Order = 2)]
        public virtual string? Description { get; set; }


        [UIHint(UIHint.Image)]

        [Display(Name = "Image", GroupName = SystemTabNames.Content, Order = 3)]
        public virtual ContentReference? Image { get; set; }


        [Display(Name = "Cta3", GroupName = SystemTabNames.Content, Order = 4)]
        public virtual LinkItem? Cta3 { get; set; }

        [Display(Name = "Items", GroupName = SystemTabNames.Content, Order = 5)]
        public virtual HeadingWithDescriptionBlockList? Items{ get; set; }

        //public virtual LinkItemCollection? Ctas { get; set; }

    }

}
