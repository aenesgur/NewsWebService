using System.Collections.Generic;
using System.Web.Http;
using WebService.ClassLibrary;

namespace WebService.AspNet.Mvc.Controllers
{
    public class DataController : ApiController
    {
        SqlHelper sqlHelper = new SqlHelper();

        public List<Entities> GetBigPara()
        {
            var select = "select";
            var where = "WHERE Category = " + ((int)CategoryType.BigPara).ToString();
            return sqlHelper.SelectEntity(select,where);
        }

        public List<Entities> GetMahmure()
        {
            var select = "select";
            var where = "WHERE Category = " + ((int)CategoryType.Mahmure).ToString();
            return sqlHelper.SelectEntity(select,where);
        }

        public List<Entities> GetEmlak()
        {
            var select = "select";
            var where = "WHERE Category = " + ((int)CategoryType.Emlak).ToString();
            return sqlHelper.SelectEntity(select,where);
        }

        public List<Entities> GetHome() {
            var select = "select top 8";
            var where = "WHERE OrderOfAdding = 1 Or OrderOfAdding = 2 Or OrderOfAdding = 3 ORDER BY CreatingDate DESC";
            return sqlHelper.SelectEntity(select,where);
        }
    }
}
