using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

using System.ComponentModel.DataAnnotations;

namespace OptimizelyDemo.Common.Models.Blocks
{
    [ContentType(DisplayName = "Heading With Description - BlockList", GUID = "628c1b2f-7ef7-43fd-a5e1-477add3eb61c", GroupName = SystemTabNames.Content)]
    public class HeadingWithDescriptionBlockList : BlockData
    {
        [Display(Name = "Items", GroupName = SystemTabNames.Content, Order = 1)]
        public virtual ContentArea? Items { get; set; }

    }

}
