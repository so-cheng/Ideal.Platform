using Ideal.Ideal.Model;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using Ideal.Platform.Service;
using Microsoft.AspNetCore.Mvc;
using SqlServer.Models;
using System.Diagnostics;

namespace Ideal.Platform.Controllers
{
    public class MenuController : Controller
    {
        #region 增删改
        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult InsertMenu(Ideal_MenuModel model)
        {

            Ideal_MenuService ideal_CompanyService = new Ideal_MenuService();
            ReturnSummary returnSummary = ideal_CompanyService.InsertMenu(model);
            return Json(returnSummary);
        }
        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult UpdateMenu(Ideal_MenuModel model)
        {
            Ideal_MenuService ideal_CompanyService = new Ideal_MenuService();
            ReturnSummary returnSummary = ideal_CompanyService.UpdateMenu(model);
            return Json(returnSummary);
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="MenuID"></param>
        /// <returns></returns>
        public JsonResult DeleteMenu(string MenuID)
        {
            Ideal_MenuService ideal_CompanyService = new Ideal_MenuService();
            ReturnSummary returnSummary = ideal_CompanyService.DeleteMenu(MenuID);
            return Json(returnSummary);
        }
        #endregion


        #region 查询
        /// <summary>
        /// 菜单详情
        /// </summary>
        /// <param name="MenuID"></param>
        /// <returns></returns>
        public JsonResult GetMenuDetailByID(string MenuID)
        {
            Ideal_MenuService ideal_CompanyService = new Ideal_MenuService();
            ReturnSummary returnSummary = ideal_CompanyService.GetMenuDetailByID(MenuID);
            return Json(returnSummary);
        }
        /// <summary>
        /// 菜单分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult GetMenuList(MenuQuery query)
        {
            Ideal_MenuService ideal_CompanyService = new Ideal_MenuService();
            ReturnSummary returnSummary = ideal_CompanyService.GetMenuList(query);
            return Json(returnSummary);
        }
        /// <summary>
        /// 所有菜单
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult GetMenuAllList(MenuQuery query)
        {
            Ideal_MenuService ideal_CompanyService = new Ideal_MenuService();
            ReturnSummary returnSummary = ideal_CompanyService.GetMenuAllList(query);
            return Json(returnSummary);
        }
        #endregion
    }
}
