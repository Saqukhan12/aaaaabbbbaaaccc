
namespace DotNetCoreBoilerplate.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using System;


    public class PageHeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string filter)
        {
            Tuple<string, string> message;

            if (this.ViewBag.PageHeader == null) message = Tuple.Create(string.Empty, string.Empty);
            else message = this.ViewBag.PageHeader as Tuple<string, string>;
            return this.View(message);
        }
    }
}