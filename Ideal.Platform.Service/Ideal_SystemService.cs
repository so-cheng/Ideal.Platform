using Ideal.Ideal.Model;
using Ideal.Platform.BLL;
using Ideal.Platform.Model.Query;
using Ideal.Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Service
{
    public class Ideal_SystemService
    {
        #region 增删改
        /// <summary>
        /// 新增系统
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary InsertSystem(Ideal_SystemModel model)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_SystemBLL ideal_SystemBLL = new Ideal_SystemBLL();
            flag = ideal_SystemBLL.InsertSystem(model, out code, out msg);
            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }
        /// <summary>
        /// 修改系统
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary UpdateSystem(Ideal_SystemModel model)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_SystemBLL ideal_SystemBLL = new Ideal_SystemBLL();
            flag = ideal_SystemBLL.UpdateSystem(model, out code, out msg);
            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }
        /// <summary>
        /// 删除系统
        /// </summary>
        /// <param name="SystemID"></param>
        /// <returns></returns>
        public ReturnSummary DeleteSystem(string SystemID)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_SystemBLL ideal_SystemBLL = new Ideal_SystemBLL();
            flag = ideal_SystemBLL.DeleteSystem(SystemID, out code, out msg);
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
        /// 查询系统详情
        /// </summary>
        /// <param name="SystemID"></param>
        /// <returns></returns>
        public ReturnSummary GetSystemDetailByID(string SystemID)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_SystemBLL ideal_SystemBLL = new Ideal_SystemBLL();
            Ideal_SystemModel model = new Ideal_SystemModel();
            model = ideal_SystemBLL.GetSystemDetailByID(SystemID, out code, out msg);
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
        /// 查询系统分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnSummary GetSystemList(SystemQuery query)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_SystemBLL ideal_SystemBLL = new Ideal_SystemBLL();
            PageModel<Ideal_SystemModel> model = new PageModel<Ideal_SystemModel>();
            model = ideal_SystemBLL.GetSystemList(query, out code, out msg);
            ReturnSummary returnSummary = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = code == 21 ? false : true,
                Data = model.PageList,
                Total = model.Total
            };
            return returnSummary;
        }
        /// <summary>
        /// 查询所有系统
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns> 
        public ReturnSummary GetSystemAllList(SystemQuery query)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_SystemBLL ideal_SystemBLL = new Ideal_SystemBLL();
            List<Ideal_SystemModel> model = new List<Ideal_SystemModel>();
            model = ideal_SystemBLL.GetSystemAllList(query, out code, out msg);
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
