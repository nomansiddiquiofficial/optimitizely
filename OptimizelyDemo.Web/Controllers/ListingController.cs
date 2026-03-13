using OptimizelyDemo.Common.Helpers;
using OptimizelyDemo.Common.Models.Api.Request;
using OptimizelyDemo.Common.Models.Api.Response;
using OptimizelyDemo.Core.Repositories.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Net;
using System.Text.RegularExpressions;
using Serilog;

namespace OptimizelyDemo.Web.Controllers
{
    public class ListingController : Controller
    {
        private readonly IRazorViewEngine _razorViewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly ListingRepository _repository;


        public ListingController(IRazorViewEngine razorViewEngine, ITempDataProvider tempDataProvider, ListingRepository repository)
        {
            _razorViewEngine = razorViewEngine;
            _tempDataProvider = tempDataProvider;
            _repository = repository;
        }

        [HttpPost("/api/search")]
        public async Task<IActionResult> Search([FromBody] SearchBody request)
        {
            using (new FunctionTracer())
            {
                try
                {
                    if (!ModelState.IsValid || request == null)
                    {
                        return BadRequest(ApiResponse.ExpectationFailed("Invalid Model State"));
                    }
                    if (string.IsNullOrEmpty(request.Culture))
                        request.Culture = Constants.Cms.Languages.Default;

                    HttpContext.Items[Constants.Cms.CurrentLanguage] = request.Culture;
                    
                    var response = _repository.GetSearchData(request);
                    if (response != null)
                    {
                        string contentType = request?.ContentType;
                        var viewpath = string.Empty;

                        if (contentType == Constants.Cms.ContentTypes.MediaCentres)
                        {
                            string componentViewName = "newsroomListingItems.cshtml";
                            viewpath = Constants.Cms.ComponentViewLocation + componentViewName;
                        }

                        if (viewpath != null && viewpath.Trim().Length > 0)

                        {
                            string renderedView = string.Empty;
                            var recordsList = response.Records as IEnumerable<object>;

                            if (recordsList != null)
                            {
                                renderedView = await RenderViewToStringAsync(viewpath, response);

                            }

                            return Ok(new
                            {
                                statusCode = HttpStatusCode.OK,

                                HasPrevPage = response.HasPrevPage,
                                HasNextPage = response.HasNextPage,
                                PrevPageNo = response.PrevPageNo,
                                NextPageNo = response.NextPageNo,
                                TotalResults = response.TotalResults,
                                TotalPages = response.TotalPages,
                                HtmlContent = renderedView,
                            });
                        }
                        else
                        {
                            return BadRequest(ApiResponse.BadRequest("No View to Bind."));
                        }
                    }

                    return Ok(ApiResponse.NotFound("No search data found."));
                }
                catch (Exception ex)
                {
                    Log.Error(ex, ex.Message);
                    return BadRequest(ApiResponse.ExpectationFailed(ex.Message));
                }
            }
        }

        private async Task<string> RenderViewToStringAsync(string viewName, object model)
        {
            var actionContext = new ActionContext(HttpContext, RouteData, ControllerContext.ActionDescriptor);
            var viewResult = _razorViewEngine.GetView(null, viewName, false);

            if (!viewResult.Success)
            {
                throw new FileNotFoundException($"View '{viewName}' not found.");
            }

            using (var sw = new StringWriter())
            {
                var viewContext = new ViewContext(
                actionContext,
                viewResult.View,
                    new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary()) { Model = model },
                    new TempDataDictionary(HttpContext, _tempDataProvider),
                    sw,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);

                string result = sw.ToString();
                // Remove all newline characters
                result = result.Replace("\r\n", "").Replace("\n", "");

                // Optionally, also remove excess whitespace between elements
                result = Regex.Replace(result, @"\s+", " ", RegexOptions.None, TimeSpan.FromMilliseconds(100)); // Collapse any remaining whitespace to a single space
                result = result.Trim(); // Trim leading and trailing whitespace
                return result;
            }
        }
    }
}


