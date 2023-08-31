using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using DotNetCoreBoilerplate.Areas.Identity.Services;

namespace DotNetCoreBoilerplate.TagHelpers
{
    [HtmlTargetElement("secure-content")]
    public class SecureContentTagHelper : TagHelper
    {
        private readonly IUserSessionService _userSessionService;

        public SecureContentTagHelper(IUserSessionService userSessionService)
        {
            _userSessionService = userSessionService;
        }

        [HtmlAttributeName("asp-area")]
        public string Area { get; set; }

        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }

        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }

        [ViewContext, HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            if (ViewContext.HttpContext.Session.Keys.ToList().Count() < 1)
            {
                return;
            }

            //var accessList = JsonConvert.DeserializeObject<IEnumerable<MvcControllerInfoArea>>(_userSessionService);
            var accessList = _userSessionService.GetRoleObject();
            if (Area == "")
            {
                Area = null;
            }
            var areadetails = accessList.FirstOrDefault(x => x?.AreaName == Area);
            var areadetailsc = areadetails?.Controller.FirstOrDefault(x => x?.Id == Controller);
            var areadetails1 = areadetailsc?.Actions.FirstOrDefault(x => x.Name == Action);

            if (areadetails1 != null)
            {
                return;
            }
            output.SuppressOutput();
        }
    }
}