using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

using System.ComponentModel.DataAnnotations;

namespace OptimizelyDemo.Common.Models.Blocks
{
    [ContentType(DisplayName = "Heading With Description - BlockList Item", GUID = "615b7dcf-bd47-47f9-9855-35b926cff728", GroupName = SystemTabNames.Content)]
    public class HeadingWithDescriptionBlockListItem : BlockData
    {
        [Display(Name = "Heading", GroupName = SystemTabNames.Content, Order = 1)]
        public virtual string? Heading { get; set; }

        [Display(Name = "Description", GroupName = SystemTabNames.Content, Order = 2)]
        public virtual string? Description { get; set; }

    }

}
