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
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Service
{
    public class Ideal_RoleService
    {

        #region 增删改
        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary InsertRole(Ideal_RoleModel model)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_RoleBLL ideal_CompanyBLL = new Ideal_RoleBLL();

            flag = ideal_CompanyBLL.InsertRole(model, out code, out msg);
           
            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary UpdateRole(Ideal_RoleModel model)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_RoleBLL ideal_CompanyBLL = new Ideal_RoleBLL();
            flag = ideal_CompanyBLL.UpdateRole(model, out code, out msg);
           
            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public ReturnSummary DeleteRole(string RoleID)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_RoleBLL ideal_CompanyBLL = new Ideal_RoleBLL();
            flag = ideal_CompanyBLL.DeleteRole(RoleID, out code, out msg);
           
            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询公司详情
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public ReturnSummary GetRoleDetailByID(string RoleID)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_RoleBLL ideal_CompanyBLL = new Ideal_RoleBLL();
            Ideal_RoleModel model = new Ideal_RoleModel();
            model = ideal_CompanyBLL.GetRoleDetailByID(RoleID, out code, out msg);
            ReturnSummary returnSummary = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = code == 21 ? false : true,
                Data = model
            };
            return returnSummary;
        }
        /// <summary>
        /// 查询公司分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnSummary GetRoleList(RoleQuery query)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_RoleBLL ideal_CompanyBLL = new Ideal_RoleBLL();
            PageModel<Ideal_RoleModel> model = new PageModel<Ideal_RoleModel>();
            model = ideal_CompanyBLL.GetRoleList(query, out code, out msg);
            ReturnSummary returnSummary = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = code == 21 ? false : true,
                Data = model.PageList,
                Total = model.Total,
                PageIndex = query.PageIndex,
                PageSize = query.PageSize
            };
            return returnSummary;
        }
        /// <summary>
        /// 查询所有公司
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnSummary GetRoleAllList(RoleQuery query)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_RoleBLL ideal_CompanyBLL = new Ideal_RoleBLL();
            List<Ideal_RoleModel> model = new List<Ideal_RoleModel>();
            model = ideal_CompanyBLL.GetRoleAllList(query, out code, out msg);
            ReturnSummary returnSummary = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = code == 21 ? false : true,
                Data = model
            };
            return returnSummary;
        }
        #endregion

    }
}
