using Ideal.Ideal.DB.Base;
using Ideal.Ideal.Model;
using Ideal.Platform.Common.Snowflake;
using Ideal.Platform.Model.Query;
using Ideal.Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ideal.Platform.BLL
{
    public class Ideal_SystemBLL
    {
        #region 增删改
        /// <summary>
        /// 新增系统
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertSystem(Ideal_SystemModel model, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "新增失败！";
            Ideal_SystemModel System = new Ideal_SystemModel();
            System = GetSystemDetailByName(model.SystemName, out int xcode, out string xmsg);
            if (xcode == 20)
            {
                code = 11;
                msg = "系统名称不能相同！";
                return false;
            }
            if (xcode == 20)
            {
                code = 11;
                msg = "系统编码不能相同！";
                return false;
            }
            model.SystemID = SnowFlakeUse.GetSnowflakeID();
            flag = BaseControl.InsertDB<Ideal_SystemModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "新增成功！" : "新增失败！";
            return flag;
        }
        /// <summary>
        /// 修改系统
        /// </summary>
        /// <param name="model"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateSystem(Ideal_SystemModel model, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "修改失败！";
            Ideal_SystemModel System = new Ideal_SystemModel();
            System = GetSystemDetailByID(model.SystemID, out code, out msg);
            if (code == 20)
            {
                code = 11;
                msg = "没有找到此系统！";
                return false;
            }
            Ideal_SystemModel ideal_SystemModel = new Ideal_SystemModel();
            ideal_SystemModel = GetSystemDetailByName(model.SystemName, out int xcode, out string xmsg);
            if (xcode == 20 && ideal_SystemModel.SystemID != model.SystemID)
            {
                code = 11;
                msg = "系统名称不能相同！";
                return false;
            }
            ideal_SystemModel = GetSystemDetailByCode(model.SystemCode, out xcode, out xmsg);
            if (xcode == 20 && ideal_SystemModel.SystemID != model.SystemID)
            {
                code = 11;
                msg = "系统编码不能相同！";
                return false;
            }
            flag = BaseControl.UpdateDB<Ideal_SystemModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "修改成功！" : "修改失败！";
            return flag;
        }
        /// <summary>
        /// 删除系统
        /// </summary>
        /// <param name="SystemID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool DeleteSystem(string SystemID, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "删除失败！";
            Ideal_SystemModel System = new Ideal_SystemModel();
            System = GetSystemDetailByID(SystemID, out code, out msg);
            if (code == 21)
            {
                msg = "没有找到此系统！";
                return false;
            }
            flag = BaseControl.Delete2DB<Ideal_SystemModel>(System, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "删除成功！" : "删除失败！";
            return flag;
        }

        #endregion

        #region 查询
        /// <summary>
        /// 系统详情
        /// </summary>
        /// <param name="SystemID"></param>
        /// <returns></returns>
        public Ideal_SystemModel GetSystemDetailByID(string SystemID, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_SystemModel model = new Ideal_SystemModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlBody = " Ideal_System as a Left Join Ideal_Company as b on a.CompanyID = b.CompanyID";
            param.SqlColumn = " a.*,b.CompanyName";
            param.SqlWhere = " AND SystemID = '" + SystemID + "'";
            model = BaseControl.GetModel<Ideal_SystemModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 系统详情（系统名称）
        /// </summary>
        /// <param name="SystemName"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_SystemModel GetSystemDetailByName(string SystemName, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_SystemModel model = new Ideal_SystemModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlBody = " Ideal_System as a Left Join Ideal_Company as b on a.ConpanyID = b.CompanyID";
            param.SqlColumn = " a.*,b.CompanyName";
            param.SqlWhere = " AND SystemName = '" + SystemName + "'";
            model = BaseControl.GetModel<Ideal_SystemModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 系统详情（系统编码）
        /// </summary>
        /// <param name="SystemName"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_SystemModel GetSystemDetailByCode(string SystemCode, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_SystemModel model = new Ideal_SystemModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlBody = " Ideal_System as a Left Join Ideal_Company as b on a.ConpanyID = b.CompanyID";
            param.SqlColumn = " a.*,b.CompanyName";
            param.SqlWhere = " AND SystemCode = '" + SystemCode + "'";
            model = BaseControl.GetModel<Ideal_SystemModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 查询系统分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public PageModel<Ideal_SystemModel> GetSystemList(SystemQuery query, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            PageModel<Ideal_SystemModel> pageModel = new PageModel<Ideal_SystemModel>();
            PageQueryParam param = new PageQueryParam();
            param.SqlBody = " Ideal_System as a Left Join Ideal_Company as b on a.CompanyID = b.CompanyID";
            param.SqlColumn = " a.*,b.CompanyName";
            if (!string.IsNullOrEmpty(query.SystemName))
            {
                param.SqlWhere += " AND a.SystemName LIKE '%" + query.SystemName + "%'";
            }

            if (!string.IsNullOrEmpty(query.SystemCode))
            {
                param.SqlWhere += " AND a.SystemCode LIKE '%" + query.SystemCode + "%'";
            }
            if (!string.IsNullOrEmpty(query.CompanyName))
            {
                param.SqlWhere += " AND b.CompanyName LIKE '%" + query.CompanyName + "%'";
            }
            param.PageIndex = query.PageIndex; 
            param.PageSize = query.PageSize;
            param.WithNoLock = true;
            pageModel = BaseControl.GetPageModels<Ideal_SystemModel>(param, out code, out msg);
            return pageModel;
        }
        /// <summary>
        /// 获取所有系统
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<Ideal_SystemModel> GetSystemAllList(SystemQuery query, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            List<Ideal_SystemModel> pageModel = new List<Ideal_SystemModel>();
            PageQueryParam param = new PageQueryParam();
            param.SqlBody = " Ideal_System as a Left Join Ideal_Company as b on a.ConpanyID = b.CompanyID";
            param.SqlColumn = " a.*,b.CompanyName";
            if (!string.IsNullOrEmpty(query.SystemName))
            {
                param.SqlWhere += " AND SystemName LIKE '%" + query.SystemName + "%'";
            }

            if (!string.IsNullOrEmpty(query.SystemCode))
            {
                param.SqlWhere += " AND SystemCode LIKE '%" + query.SystemCode + "%'";
            }
            if (!string.IsNullOrEmpty(query.SystemName))
            {
                param.SqlWhere += " AND SystemName LIKE '%" + query.SystemName + "%'";
            }

            if (!string.IsNullOrEmpty(query.SystemCode))
            {
                param.SqlWhere += " AND SystemCode LIKE '%" + query.SystemCode + "%'";
            }
            if (!string.IsNullOrEmpty(query.CompanyID))
            {

                param.SqlWhere += " AND CompanyID = '" + query.SystemCode + "s'";
            }
            param.PageIndex = query.PageIndex;
            param.PageSize = query.PageSize;
            param.WithNoLock = true;
            pageModel = BaseControl.GetAllModels<Ideal_SystemModel>(param, out code, out msg);
            return pageModel;
        }

        #endregion
    }
}
