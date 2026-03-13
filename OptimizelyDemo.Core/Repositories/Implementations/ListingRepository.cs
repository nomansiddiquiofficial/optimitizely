

using Microsoft.Extensions.Logging;
using OptimizelyDemo.Common.Helpers;
using OptimizelyDemo.Common.Models.Api.Request;
using OptimizelyDemo.Common.Models.Api.Response;


namespace OptimizelyDemo.Core.Repositories.Implementations
{
    public class ListingRepository 
    {
        public ListingRepository(ILogger<ListingRepository> logger)
        {
        }
        public SearchListing GetSearchData(SearchBody request)
        {

            using (new FunctionTracer())
            {
                int totalRecords = 0;
                SearchListing RetVal = null;
                try
                {
                    var contentType = request?.ContentType;
                    if (!string.IsNullOrEmpty(contentType))
                    {
                        var dataSources = Helpers.Common.GetDataSourceNode();
                        IQueryable<IPublishedContent>? query = null;

                        if (contentType == Constants.Cms.ContentTypes.MediaCentres)
                        {
                            var contentNode = dataSources?.Children().Where(c => c.ContentType.Alias == Constants.Cms.ContentTypes.MediaCentres && c.IsPublished() && c.HasCulture(request?.Culture)).FirstOrDefault();
                            query = contentNode?.Children()?.Where(c => c.IsPublished() && c.HasCulture(request?.Culture) && c.Cultures.ContainsKey(request?.Culture)).AsQueryable();
                        }

                        query = CMS.Core.Helpers.Common.ApplyFilters(request, query);

                        if (!string.IsNullOrWhiteSpace(request.SearchQuery))
                        {
                            query = query.Where(x =>
                                x.Value<string>(Constants.Cms.Fields.Heading) != null &&
                                x.Value<string>(Constants.Cms.Fields.Heading)
                                 .Contains(request.SearchQuery.Trim(), StringComparison.OrdinalIgnoreCase)
                            );
                        }

                        totalRecords = query.Count();

                        // Apply pagination if not skipped
                        if (!request.SkipPagination && request.PageSize.HasValue)
                        {
                            query = query.Skip(request.Skip).Take(request.PageSize.Value);
                        }

                        var filteredContent = query.ToList();

                        if (filteredContent != null && filteredContent.Any())
                        {
                            if (contentType == Constants.Cms.ContentTypes.MediaCentres)
                            {
                                List<MediaCentreItem> news = filteredContent.OfType<MediaCentreItem>().ToList();
                                RetVal = new SearchListing(news, totalRecords, request);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return RetVal;
            }

            return null;
        }
    }
}
