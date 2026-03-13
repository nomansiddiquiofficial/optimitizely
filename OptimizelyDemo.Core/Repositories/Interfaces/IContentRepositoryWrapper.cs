using EPiServer.Core;

namespace OptimizelyDemo.Core.Repositories.Interfaces
{
    public interface IContentRepositoryWrapper
    {
        T GetContent<T>(ContentReference contentLink) where T : IContentData;
        IEnumerable<T> GetChildren<T>(ContentReference contentLink) where T : IContentData;
    }
}
