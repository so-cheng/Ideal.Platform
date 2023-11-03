using Ideal.Ideal.Model;
using Ideal.Ideal.Redis;
using Ideal.Platform.BLL;
using Ideal.Platform.Common.Data;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Service
{
    public class Ideal_DeptService
    {

        #region 增删改
        /// <summary>
        /// 新增部门
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary InsertDept(Ideal_DeptModel model)
        {
            ReturnSummary returnSummary = new ReturnSummary();
            int code = 11;
            string msg = string.Empty;
            bool flag = false;
            Ideal_DeptBLL bll = new Ideal_DeptBLL();
            flag = bll.InsertDept(model, out code, out msg);
            returnSummary.IsSuccess = flag;
            returnSummary.Message = msg;
            returnSummary.StatusCode = code;
            return returnSummary;
        }
        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary UpdateDept(Ideal_DeptModel model)
        {
            ReturnSummary returnSummary = new ReturnSummary();
            int code = 11;
            string msg = string.Empty;
            bool flag = false;
            Ideal_DeptBLL bll = new Ideal_DeptBLL();
            flag = bll.UpdateDept(model, out code, out msg);

            returnSummary.IsSuccess = flag;
            returnSummary.Message = msg;
            returnSummary.StatusCode = code;
            return returnSummary;
        }
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary DeleteDept(string DeptID)
        {
            ReturnSummary returnSummary = new ReturnSummary();
            int code = 11;
            string msg = string.Empty;
            bool flag = false;
            Ideal_DeptBLL bll = new Ideal_DeptBLL();
            flag = bll.DeleteDept(DeptID, out code, out msg);

            returnSummary.IsSuccess = flag;
            returnSummary.Message = msg;
            returnSummary.StatusCode = code;
            return returnSummary;
        }

        #endregion
        #region 查询
        /// <summary>
        /// 查询部门详情
        /// </summary>
        /// <param name="DeptID"></param>
        /// <returns></returns>
        public ReturnSummary GetDeptDetailByID(string DeptID)
        {
            ReturnSummary returnSummary = new ReturnSummary();
            int code = 21;
            string msg = string.Empty;
            Ideal_DeptBLL bll = new Ideal_DeptBLL();
            Ideal_DeptModel model = new Ideal_DeptModel();
            model = bll.GetDeptDetailByID(DeptID, out code, out msg);
            returnSummary.IsSuccess = code == 20 ? true : false;
            returnSummary.Message = msg;
            returnSummary.StatusCode = code;
            returnSummary.Data = model;
            return returnSummary;
        }
        /// <summary>
        /// 查询部门分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnSummary GetDeptPageList(DeptQuery query)
        {
            ReturnSummary returnSummary = new ReturnSummary();
            int code = 21;
            string msg = string.Empty;
            Ideal_DeptBLL bll = new Ideal_DeptBLL();
            PageModel<Ideal_DeptModel> list = bll.GetDeptList(query, out code, out msg);
            returnSummary.IsSuccess = code == 20 ? true : false;
            returnSummary.Message = msg;
            returnSummary.StatusCode = code;
            returnSummary.Data = list.PageList;
            returnSummary.Total = list.Total;
            returnSummary.PageIndex = list.PageIndex;
            returnSummary.PageSize = list.PageSize;
            return returnSummary;
        }
        /// <summary>
        /// 获取所有部门
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnSummary GetDeptAllList(DeptQuery query)
        {
            ReturnSummary returnSummary = new ReturnSummary();
            int code = 21;
            string msg = string.Empty;
            Ideal_DeptBLL bll = new Ideal_DeptBLL();
            Ideal_CompanyBLL cbll = new Ideal_CompanyBLL();
            List<Ideal_CompanyModel> company = cbll.GetCompanyAllList(new CompanyQuery(), out code, out msg);
            List<Ideal_DeptModel> cdept = new List<Ideal_DeptModel>();
            foreach (var item in company)
            {
                Ideal_DeptModel model = new Ideal_DeptModel()
                {
                    DeptID = item.CompanyID,
                    DeptName = item.CompanyName,
                    ParentDeptID = "",
                    CompanyID = item.CompanyID
                };
                cdept.Add(model);
            }
            List<Ideal_DeptModel> list = bll.GetDeptAllList(query, out code, out msg);
            foreach (var item in list)
            {
                if (string.IsNullOrEmpty(item.ParentDeptID))
                {
                    item.ParentDeptID = item.CompanyID;
                }
            }
            list.AddRange(cdept);
            List<Ideal_DeptModel> roleMenus = GetDeptList(list);
            List<Ideal_DeptModel> returnMenu = GetWebDeptList(roleMenus);
            returnSummary.IsSuccess = code == 20 ? true : false;
            returnSummary.Message = msg;
            returnSummary.StatusCode = code;
            returnSummary.Data = returnMenu;
            return returnSummary;
        }
        /// <summary>
        /// 获取部门树
        /// </summary>
        /// <returns></returns>
        public ReturnSummary GetDeptTree()
        {
            int code = 21;
            string msg = "查询失败！";
            ReturnSummary returnSummary = new ReturnSummary();
            Ideal_DeptBLL bll = new Ideal_DeptBLL();
            List<DeptTree> list = bll.GetDeptTree(out code, out msg);
            returnSummary.IsSuccess = code == 20 ? true : false;
            returnSummary.Message = msg;
            returnSummary.StatusCode = code;
            returnSummary.Data = list;
            return returnSummary;
        }
        #endregion




        private List<Ideal_DeptModel> GetDeptList(List<Ideal_DeptModel> list)
        {
            List<Ideal_DeptModel> dynamics = new List<Ideal_DeptModel>();
            foreach (var item in list)
            {
                dynamics.Add(item);
            }
            return dynamics;
        }

        private List<Ideal_DeptModel> GetWebDeptList(List<Ideal_DeptModel> webs)
        {
            var list = webs.Where(a => string.IsNullOrEmpty(a.ParentDeptID)).ToList();
            foreach (var item in list)
            {
                AddChildDept(item, webs);
            }
            return list;
        }
        private void AddChildDept(Ideal_DeptModel webMenu, List<Ideal_DeptModel> webMenus)
        {
            List<Ideal_DeptModel> list = webMenus.Where(a => a.ParentDeptID == webMenu.DeptID).ToList();
            if (list.Count > 0)
            {
                webMenu.Children = list;
            }
            foreach (var item in list)
            {
                AddChildDept(item, webMenus);
            }

        }
    }
}
