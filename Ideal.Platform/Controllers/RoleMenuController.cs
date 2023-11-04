using Ideal.Ideal.Model;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using Ideal.Platform.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public JsonResult InserRoleMenu(string  listModel)
        {
            Ideal_RoleMenuService ideal_RoleMenuService = new Ideal_RoleMenuService();
            List<Ideal_RoleMenuModel> listModels = JsonConvert.DeserializeObject<List<Ideal_RoleMenuModel>>(listModel);
            ReturnSummary returnSummary = ideal_RoleMenuService.InsertRoleMenu(listModels);

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

        public JsonResult GerUserRomeMenu(string roleID)
        {
            Ideal_RoleMenuService ideal_RoleMenuService = new Ideal_RoleMenuService();

            ReturnSummary returnSummary = ideal_RoleMenuService.GerUserRomeMenu(roleID);

            return Json(returnSummary);
        }
        
        #endregion
    }
}
