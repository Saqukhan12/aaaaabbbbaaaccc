namespace DotNetCoreBoilerplate.ViewComponents
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class HeaderViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _HTTPContextAccessor;
        public HeaderViewComponent(IHttpContextAccessor HTTPContextAccessor)
        {
            _HTTPContextAccessor = HTTPContextAccessor;
        }

        public IViewComponentResult Invoke()
        {

            if (HttpContext.Session.Keys.Count() < 1)
            {
                _HTTPContextAccessor.HttpContext.Response.Redirect("../Identity/Login");
            }
            return View();
        }
    }
}