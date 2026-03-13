using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace OptimizelyDemo.Common.Models.Media
{
    [ContentType(DisplayName = "Generic File", GUID = "990F6AA9-1662-4C67-B08F-E9C579177A14", Description = "Used for generic file types like pdf, zip, etc.")]
    public class GenericFile : MediaData
    {
    }
}
