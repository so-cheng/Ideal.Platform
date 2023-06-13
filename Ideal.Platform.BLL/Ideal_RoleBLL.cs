using Ideal.Ideal.DB.Base;
using Ideal.Ideal.Model;
using Ideal.Platform.Common.Snowflake;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.BLL
{
    public class Ideal_RoleBLL
    {

        #region 增删改
        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="model"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool InsertRole(Ideal_RoleModel model, out int code, out string msg)
        {
            code = 11;
            msg = "添加失败！";
            bool flag = false;
            model.RoleID = SnowFlakeUse.GetSnowflakeID();
            model.CreateTime = DateTime.Now;
            Ideal_RoleModel ideal_RoleModel = new Ideal_RoleModel();
            ideal_RoleModel = GetRoleDetailByName(model.RoleName, out code, out msg);
            if (code == 20)
            {
                code = 11;
                msg = "角色名称不能重复！";
                return false;
            }
            flag = BaseControl.InsertDB<Ideal_RoleModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "新增成功！" : "新增失败！";
            return flag;
        }
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="model"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateRole(Ideal_RoleModel model, out int code, out string msg)
        {
            code = 11;
            msg = "添加失败！";
            bool flag = false;
            Ideal_RoleModel ideal_RoleModel = new Ideal_RoleModel();
            ideal_RoleModel = GetRoleDetailByID(model.RoleID, out code, out msg);
            if (code == 20)
            {
                code = 11;
                msg = "没有找到此角色！";
                return false;
            }
            ideal_RoleModel = GetRoleDetailByName(model.RoleName, out code, out msg);
            if (code == 20 && model.RoleID != ideal_RoleModel.RoleID)
            {
                msg = "角色名称不能重复！";
                return false;
            }
            flag = BaseControl.UpdateDB<Ideal_RoleModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "修改成功！" : "修改失败！";
            return flag;
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="RoleID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool DeleteRole(string RoleID, out int code, out string msg)
        {
            code = 11;
            msg = "删除失败！";
            Ideal_RoleModel ideal_RoleModel = new Ideal_RoleModel();
            ideal_RoleModel = GetRoleDetailByID(RoleID, out code, out msg);
            if (code == 20)
            {
                code = 11;
                msg = "没有找到此角色！";
                return false;
            }
            //查询角色下菜单
            List<Ideal_RoleMenuModel> list = new List<Ideal_RoleMenuModel>();
            Ideal_RoleMenuBLL ideal_RoleMenuBLL = new Ideal_RoleMenuBLL();
            list = ideal_RoleMenuBLL.GetRoleMenuListByRoleID(RoleID, out code, out msg);
            List<string> sqlList = new List<string>();
            foreach (var item in list)
            {
                sqlList.Add(BaseControl.GetDeleteFromDBSQL(item));
            }   
            sqlList.Add(BaseControl.GetDeleteFromDBSQL<Ideal_RoleModel>(ideal_RoleModel));
            int count = BaseControl.ExecuteSqlTran(sqlList, out code, out msg);
            code = count > 0 ? 10 : 11;
            msg = count > 0 ? "删除成功！" : "删除失败！";
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 查询
        /// <summary>
        /// 根据ID查询角色
        /// </summary>
        /// <param name="RoleID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_RoleModel GetRoleDetailByID(string RoleID, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_RoleModel model = new Ideal_RoleModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlWhere = " AND RoleID = '" + RoleID + "'";
            model = BaseControl.GetModel<Ideal_RoleModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 根据角色名称查询角色
        /// </summary>
        /// <param name="RoleName"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_RoleModel GetRoleDetailByName(string RoleName, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_RoleModel model = new Ideal_RoleModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlWhere = " AND RoleName = '" + RoleName + "'";
            model = BaseControl.GetModel<Ideal_RoleModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 查询角色分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public PageModel<Ideal_RoleModel> GetRoleList(RoleQuery query, out int code, out string msg)
        {
            code = 22;
            msg = "查询失败！";
            PageModel<Ideal_RoleModel> list = new PageModel<Ideal_RoleModel>();
            PageQueryParam param = new PageQueryParam();
            param.WithNoLock = true;
            param.PageSize = query.PageSize;
            param.PageIndex = query.PageIndex;
            if (!string.IsNullOrEmpty(query.RoleName))
            {
                param.SqlWhere += " AND RoleName like '%" + query.RoleName + "%'";
            }
            list = BaseControl.GetPageModels<Ideal_RoleModel>(param, out code, out msg);
            return list;
        }
        /// <summary>
        /// 查询所有角色
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<Ideal_RoleModel> GetRoleAllList(RoleQuery query, out int code, out string msg)
        {
            code = 22;
            msg = "查询失败！";
            List<Ideal_RoleModel> list = new List<Ideal_RoleModel>();
            PageQueryParam param = new PageQueryParam();
            param.WithNoLock = true;
            param.PageSize = query.PageSize;
            param.PageIndex = query.PageIndex;
            if (!string.IsNullOrEmpty(query.RoleName))
            {
                param.SqlWhere += " AND RoleName = '" + query.RoleName + "'";
            }
            list = BaseControl.GetAllModels<Ideal_RoleModel>(param, out code, out msg);
            return list;
        }
        #endregion
    }
}
