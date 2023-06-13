using Ideal.Ideal.Model;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using Ideal.Platform.Service;
using Microsoft.AspNetCore.Mvc;

namespace Ideal.Platform.Controllers
{
    public class RoleController : Controller
    {
        #region 增删改
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult InsertRole(Ideal_RoleModel model)
        {

            Ideal_RoleService ideal_RoleService = new Ideal_RoleService();
            ReturnSummary returnSummary = ideal_RoleService.InsertRole(model);
            return Json(returnSummary);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult UpdateRole(Ideal_RoleModel model)
        {

            Ideal_RoleService ideal_RoleService = new Ideal_RoleService();
            ReturnSummary returnSummary = ideal_RoleService.UpdateRole(model);
            return Json(returnSummary);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public JsonResult DeleteRole(string RoleID)
        {

            Ideal_RoleService ideal_RoleService = new Ideal_RoleService();
            ReturnSummary returnSummary = ideal_RoleService.DeleteRole(RoleID);
            return Json(returnSummary);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public JsonResult GetRoleDetailByID(string RoleID)
        {
            Ideal_RoleService ideal_RoleService = new Ideal_RoleService();
            ReturnSummary returnSummary = ideal_RoleService.GetRoleDetailByID(RoleID);
            return Json(returnSummary);
        }
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult GetRoleList(RoleQuery query)
        {
            Ideal_RoleService ideal_RoleService = new Ideal_RoleService();
            ReturnSummary returnSummary = ideal_RoleService.GetRoleList(query);
            return Json(returnSummary);
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult GetRoleAllList(RoleQuery query)
        {
            Ideal_RoleService ideal_RoleService = new Ideal_RoleService();
            ReturnSummary returnSummary = ideal_RoleService.GetRoleAllList(query);
            return Json(returnSummary);
        }
        #endregion
    }
}
