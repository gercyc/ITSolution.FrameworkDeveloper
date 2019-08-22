using System.Web;
using System.Web.Mvc;

namespace ITSolution.Framework.Web.Administrator
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
