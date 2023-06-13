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
    public class Ideal_RoleMenuBLL
    {
        #region 增删改
        /// <summary>
        /// 新增角色菜单
        /// </summary>
        /// <param name="model"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool InsertRoleMenu(List<Ideal_RoleMenuModel> listmodel, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "新增失败！";
            //删除以前的角色菜单
            List<Ideal_RoleMenuModel> list = new List<Ideal_RoleMenuModel>();

            if (listmodel.Count == 0)
            {
                code = 11;
                msg = "新增失败！没有新数据！";
                return false;
            }
            list = GetRoleMenuListByRoleID(listmodel[0].RoleID, out code, out msg);
            List<string> sqllist = new List<string>();
            foreach (var item in list)
            {
                sqllist.Add(BaseControl.GetDeleteFromDBSQL(item));
            }
            foreach (var item in listmodel)
            {
                item.FlowID = SnowFlakeUse.GetSnowflakeID();
                item.CreateTime = DateTime.Now;
                sqllist.Add(BaseControl.GetInsert2DBSQL(item));
            }
            int count = BaseControl.ExecuteSqlTran(sqllist, out code, out msg);
            code = count > 0 ? 10 : 11;
            msg = count > 0 ? "新增成功！" : "新增失败！";
            if (count > 0 )
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
        /// 根据角色ID查询角色菜单
        /// </summary>
        /// <param name="RoleID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<Ideal_RoleMenuModel> GetRoleMenuListByRoleID(string RoleID, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            List<Ideal_RoleMenuModel> result = new List<Ideal_RoleMenuModel>();
            PageQueryParam param = new PageQueryParam();
            param.WithNoLock = true;
            param.SqlBody = " Ideal_RoleMenu as a Lief Join Ideal_Menu as b  on a.MenuID = b.MenuID ";
            param.SqlColumn = "a.*,b.MenuName,b.MenuURL,b.ParentMenuID,b.MenuSort,b.Icon,b.IsDisplay";
            param.SqlWhere = " AND a.RoleID = '" + RoleID + "'";
            result = BaseControl.GetAllModels<Ideal_RoleMenuModel>(param, out code, out msg);
            return result;
        }
        #endregion
    }
}
