using System.Web;
using System.Web.Mvc;

namespace LTWeb08_Tuan08
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
