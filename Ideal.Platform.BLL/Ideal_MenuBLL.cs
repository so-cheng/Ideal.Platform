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
    public class Ideal_MenuBLL
    {

        #region 增删改
        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <param name="model"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool InsertMenu(Ideal_MenuModel model, out int code, out string msg)
        {
            code = 11;
            msg = "添加失败！";
            bool flag = false;
            model.MenuID = SnowFlakeUse.GetSnowflakeID();
            model.CreateTime = DateTime.Now;
            flag = BaseControl.InsertDB<Ideal_MenuModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "新增成功！" : "新增失败！";
            return flag;
        }
        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="model"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateMenu(Ideal_MenuModel model, out int code, out string msg)
        {
            code = 11;
            msg = "修改失败！";
            bool flag = false;
            Ideal_MenuModel ideal_Menu = new Ideal_MenuModel();
            ideal_Menu = GetMenuDetailByID(model.MenuID, out code, out msg);
            if (code == 20)
            {
                code = 11;
                msg = "没有找到此菜单";
                return false;
            }
            flag = BaseControl.UpdateDB<Ideal_MenuModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "修改成功！" : "修改失败！";

            return flag;
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="MenuID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool DeleteMenu(string MenuID, out int code, out string msg)
        {
            code = 11;
            msg = "修改失败！";
            bool flag = false;
            Ideal_MenuModel model = new Ideal_MenuModel();
            model = GetMenuDetailByID(MenuID, out code, out msg);
            if (code == 20)
            {
                code = 11;
                msg = "没有找到此菜单";
                return false;
            }
            flag = BaseControl.Delete2DB<Ideal_MenuModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "删除成功！" : "删除失败！";
            return flag;
        }
        #endregion

        #region 查询
        /// <summary>
        /// 根据ID查询菜单详情
        /// </summary>
        /// <param name="MenuID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_MenuModel GetMenuDetailByID(string MenuID, out int code, out string msg)
        {
            code = 22;
            msg = "查询失败！";
            Ideal_MenuModel model = new Ideal_MenuModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlWhere = " AND MenuID = '" + MenuID + "'";
            model = BaseControl.GetModel<Ideal_MenuModel>(param, out code, out msg);
            return model;

        }
        /// <summary>
        /// 查询菜单分页
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public PageModel<Ideal_MenuModel> GetMenuList(MenuQuery query, out int code, out string msg)
        {
            code = 22;
            msg = "查询失败！";
            PageModel<Ideal_MenuModel> pageModel = new PageModel<Ideal_MenuModel>();
            PageQueryParam param = new PageQueryParam();
            param.WithNoLock = true;
            param.PageIndex = query.PageIndex;
            param.PageSize = query.PageSize;
            if (!string.IsNullOrEmpty(query.MenuName))
            {
                param.SqlWhere += " AND MenuName like '%" + query.MenuName + "%'";
            }
            if (!string.IsNullOrEmpty(query.SystemID))
            {
                param.SqlWhere += " AND SystemID = '" + query.SystemID + "'";
            }
            pageModel = BaseControl.GetPageModels<Ideal_MenuModel>(param, out code, out msg);
            return pageModel;
        }
        /// <summary>
        /// 获取全部菜单
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<Ideal_MenuModel> GetMenuAllList(MenuQuery query, out int code, out string msg)
        {
            code = 22;
            msg = "查询失败！";
            List<Ideal_MenuModel> list = new List<Ideal_MenuModel>();
            PageQueryParam param = new PageQueryParam();
            param.WithNoLock = true;
            param.PageIndex = query.PageIndex;
            param.PageSize = query.PageSize;
            if (!string.IsNullOrEmpty(query.MenuName))
            {
                param.SqlWhere += " AND MenuName like '%" + query.MenuName + "%'";
            }
            if (!string.IsNullOrEmpty(query.SystemID))
            {
                param.SqlWhere += " AND SystemID = '" + query.SystemID + "'";
            }
            list = BaseControl.GetAllModels<Ideal_MenuModel>(param, out code, out msg);
            return list;
        }

        #endregion
    }
}
