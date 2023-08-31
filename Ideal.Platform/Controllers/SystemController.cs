using Ideal.Ideal.Model;
using Ideal.Platform.Model.Query;
using Ideal.Platform.Model;
using Ideal.Platform.Service;
using Microsoft.AspNetCore.Mvc;

namespace Ideal.Platform.Controllers
{
    public class SystemController : Controller
    {
        #region 增删改
        /// <summary>
        /// 新增系统
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult InsertSystem(Ideal_SystemModel model)
        {
            Ideal_SystemService ideal_SystemService = new Ideal_SystemService();
            ReturnSummary returnSummary = ideal_SystemService.InsertSystem(model);
            return Json(returnSummary);
        }
        /// <summary>
        /// 修改系统
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult UpdateSystem(Ideal_SystemModel model)
        {
            Ideal_SystemService ideal_SystemService = new Ideal_SystemService();
            ReturnSummary returnSummary = ideal_SystemService.UpdateSystem(model);
            return Json(returnSummary);
        }
        /// <summary>
        /// 删除系统
        /// </summary>
        /// <param name="SystemID"></param>
        /// <returns></returns>
        public JsonResult DeleteSystem(string SystemID)
        {
            Ideal_SystemService ideal_SystemService = new Ideal_SystemService();
            ReturnSummary returnSummary = ideal_SystemService.DeleteSystem(SystemID);
            return Json(returnSummary);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询系统详情
        /// </summary>
        /// <param name="SystemID"></param>
        /// <returns></returns>
        public JsonResult GetSystemDetailByID(string SystemID)
        {
            Ideal_SystemService ideal_SystemService = new Ideal_SystemService();
            ReturnSummary ReturnSummary = ideal_SystemService.GetSystemDetailByID(SystemID);
            return Json(ReturnSummary);
        }
        /// <summary>
        /// 查询系统分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult GetSystemList(SystemQuery query)
        {
            Ideal_SystemService ideal_SystemService = new Ideal_SystemService();
            ReturnSummary returnSummary = ideal_SystemService.GetSystemList(query);
            return Json(returnSummary);
        }
        /// <summary>
        /// 查询所有系统
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult GetSystemAllList(SystemQuery query)
        {
            Ideal_SystemService ideal_SystemService = new Ideal_SystemService();
            ReturnSummary returnSummary = ideal_SystemService.GetSystemAllList(query);
            return Json(returnSummary);
        }
        #endregion
    }
}
