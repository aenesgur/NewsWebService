using System.Web.Mvc;
using WebService.ClassLibrary;

namespace WebService.AspNet.Mvc.Controllers
{
    public class SearchController : Controller
    {
        SqlHelper sqlHelper = new SqlHelper();
        public ActionResult Index(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return View(query);
            }
            var select = "select";
            var where = $"WHERE Title LIKE '%{query}%' or Spot LIKE '%{query}%'";
            var list = sqlHelper.SelectEntity(select, where);

            return View(list);
        }
    }
}