using EPiServer.Core;
using OptimizelyDemo.Common.Models.Pages;
using System.Collections.Generic;

namespace OptimizelyDemo.Core.Repositories.Interfaces
{
    public interface IGetSiteContent
    {
        SitePage GetSiteData();
    }
}
