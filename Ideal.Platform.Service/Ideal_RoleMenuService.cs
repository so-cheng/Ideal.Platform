using Ideal.Ideal.DB;
using Ideal.Ideal.DB.Base;
using Ideal.Ideal.Log;
using Ideal.Ideal.Model;
using Ideal.Ideal.Redis;
using Ideal.Platform.BLL;
using Ideal.Platform.Common.Data;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using Newtonsoft.Json;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;


namespace Ideal.Platform.Service
{
    public class Ideal_RoleMenuService
    {
        #region 增删改
        /// <summary>
        /// 新增角色菜单
        /// </summary>
        /// <param name="listmodel"></param>
        /// <returns></returns>
        public ReturnSummary InsertRoleMenu(List<Ideal_RoleMenuModel> listmodel)
        {
            ReturnSummary returnSummary = new ReturnSummary();
            int code = 11;
            string msg = string.Empty;
            bool flag = false;
            Ideal_RoleMenuBLL bll = new Ideal_RoleMenuBLL();
            flag = bll.InsertRoleMenu(listmodel, out code, out msg);
           
            returnSummary.IsSuccess = flag;
            returnSummary.Message = msg;
            returnSummary.StatusCode = code;
            return returnSummary;
        }
        #endregion

        #region 查询
        /// <summary>
        /// 根据RoleID查询角色菜单
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public ReturnSummary GetRoleMenuListByRoleID(string RoleID)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_RoleMenuBLL ideal_RoleMenuBLL = new Ideal_RoleMenuBLL();
            List<Ideal_RoleMenuModel> model = new List<Ideal_RoleMenuModel>();
            model = ideal_RoleMenuBLL.GetRoleMenuListByRoleID(RoleID, out code, out msg);
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
