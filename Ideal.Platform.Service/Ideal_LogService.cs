using Ideal.Ideal.Model;
using Ideal.Platform.BLL;
using Ideal.Platform.Model.Query;
using Ideal.Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ideal.Platform.Common.Data;

namespace Ideal.Platform.Service
{
    public class Ideal_LogService
    {
        #region 增删改
        /// <summary>
        /// 新增日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary InsertLog(Ideal_LogModel model)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_LogBLL ideal_LogBLL = new Ideal_LogBLL();
            flag = ideal_LogBLL.InsertLog(model, out code, out msg);
            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }

        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="LogID"></param>
        /// <returns></returns>
        public ReturnSummary DeleteLog(string LogID)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_LogBLL ideal_LogBLL = new Ideal_LogBLL();
            flag = ideal_LogBLL.DeleteLog(LogID, out code, out msg);
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
        /// 查询日志详情
        /// </summary>
        /// <param name="LogID"></param>
        /// <returns></returns>
        public ReturnSummary GetLogDetailByID(string LogID)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_LogBLL ideal_LogBLL = new Ideal_LogBLL();
            Ideal_LogModel model = new Ideal_LogModel();
            model = ideal_LogBLL.GetLogDetailByID(LogID, out code, out msg);
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
        /// 查询日志分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnSummary GetLogList(LogQuery query)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_LogBLL ideal_LogBLL = new Ideal_LogBLL();
            PageModel<Ideal_LogModel> model = new PageModel<Ideal_LogModel>();
            model = ideal_LogBLL.GetLogList(query, out code, out msg);
            foreach (var item in model.PageList)
            {
                item.TypeName = GetData.LogTypeList().SingleOrDefault(a => a.Key == item.Type)?.Value;
            }
            ReturnSummary returnSummary = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = code == 21 ? false : true,
                Data = model.PageList,
                Total = model.Total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };
            return returnSummary;
        }
        /// <summary>
        /// 查询所有日志
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns> 
        public ReturnSummary GetLogAllList(LogQuery query)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_LogBLL ideal_LogBLL = new Ideal_LogBLL();
            List<Ideal_LogModel> model = new List<Ideal_LogModel>();
            model = ideal_LogBLL.GetLogAllList(query, out code, out msg);
            foreach (var item in model)
            {
                item.TypeName = GetData.LogTypeList().SingleOrDefault(a => a.Key == item.Type)?.Value;
            }
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
