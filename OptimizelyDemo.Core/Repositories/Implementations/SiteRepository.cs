using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using OptimizelyDemo.Common.Helpers;
using OptimizelyDemo.Common.Models.Pages;
using OptimizelyDemo.Core.Repositories.Interfaces;

namespace OptimizelyDemo.Core.Repositories.Implementations
{
    [ServiceConfiguration(typeof(IGetSiteContent))]
    public class GetSiteContent : IGetSiteContent
    {
        private readonly IContentLoader _contentLoader;
        public GetSiteContent(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }
        public SitePage GetSiteData()
        {
            using (new FunctionTracer())
            {
                try
                {
                    var root = ContentReference.RootPage;

                    var sitePage = _contentLoader
                        .GetChildren<SitePage>(root)
                        .FirstOrDefault();

                    return sitePage;
                }
                catch(Exception)
                {
                    throw;
                }
            }
        }

    }
}