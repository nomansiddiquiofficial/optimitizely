using System;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptimizelyDemo.Common.Helpers;
using OptimizelyDemo.Common.Models.Pages;
using Serilog;

namespace OptimizelyDemo.Web.Controllers
{
    public class BasePageController : PageController<BasePage>
    {
        public IActionResult Index(BasePage currentPage)
        {
            using (new FunctionTracer())
            {
                try
                {
                    return View(Constants.PageViewLocation, currentPage);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, ex.Message);
                    throw; 
                }
            }
        }
    }
}
