using EPiServer;
using EPiServer.Core;
using OptimizelyDemo.Core.Repositories.Interfaces;
using System.Collections.Generic;

namespace OptimizelyDemo.Core.Repositories.Implementations
{
    public class ContentRepositoryWrapper : IContentRepositoryWrapper
    {
        private readonly IContentRepository _contentRepository;

        public ContentRepositoryWrapper(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public T GetContent<T>(ContentReference contentLink) where T : IContentData
        {
            return _contentRepository.Get<T>(contentLink);
        }

        public IEnumerable<T> GetChildren<T>(ContentReference contentLink) where T : IContentData
        {
            return _contentRepository.GetChildren<T>(contentLink);
        }
    }
}