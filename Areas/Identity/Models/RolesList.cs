using NuGet.Packaging;
using System.Collections.Generic;
using System.Linq;
using DotNetCoreBoilerplate.Areas.Identity.Services;


namespace DotNetCoreBoilerplate.Areas.Identity.Models
{
    public class RolesList : IRolesList
    {
        Dictionary<string, string> Roles;
        public IList<RoleClaimsCache> ClaimsList;
        public RolesList()
        {
            ClaimsList = new List<RoleClaimsCache>();
            Roles = new Dictionary<string, string>();
        }
        public void AddValue(string Key, string Values)
        {
            if (!Roles.ContainsKey(Key))
            {
                Roles.Add(Key, Values);
            }
            else
            {
                Roles[Key] = Values;
            }
        }

        public string GetValue(string Key)
        {
            if (Roles.ContainsKey(Key))
            {
                return Roles.Where(x => x.Key == Key).FirstOrDefault().Value;
            }
            return "No values found";
        }

        public void AddObject(string Key, List<MvcControllerInfoArea> Values)
        {
            if (Key !=null)
            {
                RoleClaimsCache roleClaimsCache = new RoleClaimsCache();
                roleClaimsCache.Key = Key;
                roleClaimsCache.MvcControllerInfoArea = Values;
                ClaimsList.Add(roleClaimsCache);
            }
        }

        public IList<MvcControllerInfoArea> GetObject(string Key)
        {
            if (Key != null)
            {
                return ClaimsList.FirstOrDefault(x => x.Key == Key).MvcControllerInfoArea;
            }
            return null;
        }
    }
}