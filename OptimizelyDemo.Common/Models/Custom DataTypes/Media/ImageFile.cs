using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace OptimizelyDemo.Common.Models
{
    [ContentType(DisplayName = "Image File", GUID = "20644E0D-6663-4241-9494-01E35C83441A", Description = "Used for image files like jpg, png, etc.")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png,svg")]
    public class ImageFile : ImageData
    {
        [Display(Name = "Alt text", GroupName = "Content", Order = 10)]
        public virtual string? AltText { get; set; }
    }
}
