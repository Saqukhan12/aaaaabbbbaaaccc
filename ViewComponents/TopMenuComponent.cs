namespace DotNetCoreBoilerplate.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;


    public class TopMenuComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string filter)
        {
            return this.View();
        }
    }
}