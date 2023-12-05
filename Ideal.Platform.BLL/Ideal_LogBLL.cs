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

namespace Ideal.Platform.BLL
{
    public class Ideal_LogBLL
    {
        #region 增删改
        /// <summary>
        /// 新增日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertLog(Ideal_LogModel model, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "新增失败！";
            model.LogID = SnowFlakeUse.GetSnowflakeID();
            flag = BaseControl.InsertDB<Ideal_LogModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "新增成功！" : "新增失败！";
            return flag;
        }
        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="LogID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool DeleteLog(string LogID, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "删除失败！";
            Ideal_LogModel Log = new Ideal_LogModel();
            Log = GetLogDetailByID(LogID, out code, out msg);
            if (code != 20)
            {
                msg = "没有找到此日志！";
                return false;
            }
            flag = BaseControl.Delete2DB<Ideal_LogModel>(Log, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "删除成功！" : "删除失败！";
            return flag;
        }

        #endregion

        #region 查询
        /// <summary>
        /// 日志详情
        /// </summary>
        /// <param name="LogID"></param>
        /// <returns></returns>
        public Ideal_LogModel GetLogDetailByID(string LogID, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_LogModel model = new Ideal_LogModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlWhere = " AND LogID = '" + LogID + "'";
            model = BaseControl.GetModel<Ideal_LogModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 查询日志分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public PageModel<Ideal_LogModel> GetLogList(LogQuery query, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            PageModel<Ideal_LogModel> pageModel = new PageModel<Ideal_LogModel>();
            PageQueryParam param = new PageQueryParam();
            param.SqlBody = " Ideal_Log as a left join Ideal_User  as b on a.Creator = b.UserID ";
            param.SqlColumn = "a.*,b.UserName as CreatorName";
            if (!string.IsNullOrEmpty(query.Type))
            {
                param.SqlWhere += " AND Type = '" + query.Type + "'";
            }

            if (!string.IsNullOrEmpty(query.StartTime))
            {
                param.SqlWhere += " AND a.CreateTime >= '" + query.StartTime + "'";
            }
            if (!string.IsNullOrEmpty(query.EndTime))
            {
                param.SqlWhere += " AND a.CreateTime <= '" + query.EndTime + "'";
            }
            param.PageIndex = query.PageIndex;
            param.PageSize = query.PageSize;
            param.WithNoLock = true;
            pageModel = BaseControl.GetPageModels<Ideal_LogModel>(param, out code, out msg);
            return pageModel;
        }
        /// <summary>
        /// 获取所有日志
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<Ideal_LogModel> GetLogAllList(LogQuery query, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            List<Ideal_LogModel> pageModel = new List<Ideal_LogModel>();
            PageQueryParam param = new PageQueryParam();
            param.SqlBody = " Ideal_Log as a left join Ideal_User as b on a.Creator = b.UserID ";
            param.SqlColumn = "a.*,b.UserName as CreatorName";
            if (!string.IsNullOrEmpty(query.Type))
            {
                param.SqlWhere += " AND Type = '" + query.Type + "'";
            }

            if (!string.IsNullOrEmpty(query.StartTime))
            {
                param.SqlWhere += " AND a.CreateTime >= '" + query.StartTime + "'";
            }
            if (!string.IsNullOrEmpty(query.EndTime))
            {
                param.SqlWhere += " AND a.CreateTime <= '" + query.EndTime + "'";
            }
            param.PageIndex = query.PageIndex;
            param.PageSize = query.PageSize;
            param.WithNoLock = true;
            pageModel = BaseControl.GetAllModels<Ideal_LogModel>(param, out code, out msg);
            return pageModel;
        }

        #endregion
    }
}
