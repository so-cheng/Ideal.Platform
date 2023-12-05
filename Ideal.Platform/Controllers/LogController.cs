using Ideal.Ideal.Model;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using Ideal.Platform.Service;
using Microsoft.AspNetCore.Mvc;

namespace Ideal.Platform.Controllers
{
    public class LogController : Controller
    {
        /// <summary>
        /// 查询日志分页
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult GetLogList(LogQuery query)
        {
            Ideal_LogService ideal_LogService = new Ideal_LogService();
            ReturnSummary returnSummary = ideal_LogService.GetLogList(query);
            return Json(returnSummary);
        }
    }
}
