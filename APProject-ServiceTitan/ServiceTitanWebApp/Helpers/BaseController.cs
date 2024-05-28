using Microsoft.AspNetCore.Mvc;

namespace ServiceTitanWebApp.Helpers
{
    public class BaseController : Controller
    {
        public string GetSourceRoute()
        {
            var sourceRoute = this.ControllerContext.RouteData.Values;
            string source = "WebApp: " + sourceRoute["controller"] + ":" + sourceRoute["action"];
            return source;
        }
    }
}
