using Ideal.Ideal.Model;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using Ideal.Platform.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ideal.Platform.Controllers
{
    public class DeptController : Controller
    {
        #region 增删改
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult InsertDept(Ideal_DeptModel model)
        {
            Ideal_DeptService ideal_DeptService = new Ideal_DeptService();
            ReturnSummary returnSummary = ideal_DeptService.InsertDept(model);
            return Json(returnSummary);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult UpdateDept(Ideal_DeptModel model)
        {
            Ideal_DeptService ideal_DeptService = new Ideal_DeptService();
            ReturnSummary returnSummary = ideal_DeptService.UpdateDept(model);
            return Json(returnSummary);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="DeptID"></param>
        /// <returns></returns>
        public JsonResult DeleteDept(string DeptID)
        {
            Ideal_DeptService ideal_DeptService = new Ideal_DeptService();
            ReturnSummary returnSummary = ideal_DeptService.DeleteDept(DeptID);
            return Json(returnSummary);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询部门详情
        /// </summary>
        /// <param name="DeptID"></param>
        /// <returns></returns>
        public JsonResult GetDeptDetailByID(string DeptID)
        {
            Ideal_DeptService ideal_DeptService = new Ideal_DeptService();
            ReturnSummary returnSummary = ideal_DeptService.GetDeptDetailByID(DeptID);
            return Json(returnSummary);
        }
        /// <summary>
        /// 查询部门分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult GetDeptList(DeptQuery query)
        {
            Ideal_DeptService ideal_DeptService = new Ideal_DeptService();
            ReturnSummary returnSummary = ideal_DeptService.GetDeptList(query);
            return Json(returnSummary);
        }
        /// <summary>
        /// 获取所有部门
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult GetDeptAllList(DeptQuery query)
        {
            Ideal_DeptService ideal_DeptService = new Ideal_DeptService();
            ReturnSummary returnSummary = ideal_DeptService.GetDeptAllList(query);
            return Json(returnSummary);
        }
        /// <summary>
        /// 获取部门树
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDeptTree()
        {
            Ideal_DeptService ideal_DeptService = new Ideal_DeptService();
            ReturnSummary returnSummary = ideal_DeptService.GetDeptTree();
            return Json(returnSummary);
        }
        #endregion
    }
}