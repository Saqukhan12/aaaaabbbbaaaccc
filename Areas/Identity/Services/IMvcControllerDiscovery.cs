using System.Collections.Generic;
using DotNetCoreBoilerplate.Identity.ViewModels;

namespace DotNetCoreBoilerplate.Areas.Identity.Services
{
    public interface IMvcControllerDiscovery
    {
        IEnumerable<MvcControllerInfo> GetControllers();
    }

    public interface IRolesList
    {
        void AddValue(string Key, string Values);
        string GetValue(string Key);  
        void AddObject(string Key, List<MvcControllerInfoArea> Values);
        IList<MvcControllerInfoArea> GetObject(string Key);
    }
}