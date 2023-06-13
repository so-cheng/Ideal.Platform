using Ideal.Ideal.Model;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using Ideal.Platform.Service;
using Microsoft.AspNetCore.Mvc;

namespace Ideal.Platform.Controllers
{
    public class RoleMenuController : Controller
    {
        #region 增删改
        /// <summary>
        /// 新增角色菜单
        /// </summary>
        /// <param name="listModel"></param>
        /// <returns></returns>
        public JsonResult InserRoleMenu(List<Ideal_RoleMenuModel> listModel)
        {
            Ideal_RoleMenuService ideal_RoleMenuService = new Ideal_RoleMenuService();

            ReturnSummary returnSummary = ideal_RoleMenuService.InsertRoleMenu(listModel);

            return Json(returnSummary);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 根据RoleID查询角色菜单
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public JsonResult GetRoleMenuListByRoleID(string RoleID)
        {
            Ideal_RoleMenuService ideal_RoleMenuService = new Ideal_RoleMenuService();

            ReturnSummary returnSummary = ideal_RoleMenuService.GetRoleMenuListByRoleID(RoleID);

            return Json(returnSummary);
        }
        #endregion
    }
}
