using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace OptimizelyDemo.Common.Models.Pages
{
    [ContentType(DisplayName = "Site", GUID = "eec34d74-36b0-43cd-869c-25c27613877e")]
    public class SitePage : PageData
    {
        [UIHint(UIHint.Image)]
        [Display(
             Name = "Header Logo",
             GroupName = SystemTabNames.Content,
             Order = 1)]
        public virtual ContentReference? HeaderLogo { get; set; }

        [UIHint(UIHint.Image)]
        [Display(
            Name = "Footer Logo",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual ContentReference? FooterLogo { get; set; }


        [Display(
            Name = "Logo Link",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual LinkItem? LogoCta { get; set; }


    }
}