#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024   保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：LAPTOP-4OVFGLIB
 * 命名空间：Ideal.Shop.Service
 * 文件名：Shop_ClientService
 * 
 * 创建者：理想再见
 * 创建时间：2024/3/25 13:32:27
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 修改人：
 * 时间：
 * 修改说明：
 *
 * 版本：V1.0.1
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Ideal.Ideal.DB.Base;
using Ideal.Ideal.Model;
using Ideal.Platform.Common.Snowflake;
using Ideal.Shop.BLL;
using Ideal.Shop.Model.Query;
using Ideal.Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Shop.Service
{
    public class Shop_ClientService
    {
        #region <属性>
        #endregion <属性>

        #region <方法>

        #region 增删改
        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary InsertClient(Shop_ClientModel model)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Shop_ClientBLL shop_ClientBLL = new Shop_ClientBLL();
            flag = shop_ClientBLL.InsertClient(model, out code, out msg);
            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }
        /// <summary>
        /// 修改客户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary UpdateClient(Shop_ClientModel model)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Shop_ClientBLL shop_ClientBLL = new Shop_ClientBLL();
            flag = shop_ClientBLL.UpdateClient(model, out code, out msg);
            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }
        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="ClientID"></param>
        /// <returns></returns>
        public ReturnSummary DeleteClient(string ClientID)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Shop_ClientBLL shop_ClientBLL = new Shop_ClientBLL();
            flag = shop_ClientBLL.DeleteClient(ClientID, out code, out msg);
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
        /// 查询客户详情
        /// </summary>
        /// <param name="AccountName"></param>
        /// <returns></returns>
        public ReturnSummary GetClientByID(string ClientID)
        {
            int code = 21;
            string msg = string.Empty;
            Shop_ClientBLL shop_ClientBLL = new Shop_ClientBLL();
            Shop_ClientModel model = new Shop_ClientModel();
            model = shop_ClientBLL.GetClientByID(ClientID, out code, out msg);
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
        /// 获取客户分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnSummary GetClientList(OrderQuery query)
        {
            int code = 21;
            string msg = string.Empty;
            Shop_ClientBLL shop_ClientBLL = new Shop_ClientBLL();
            PageModel<Shop_ClientModel> model = new PageModel<Shop_ClientModel>();
            model = shop_ClientBLL.GetClientList(query, out code, out msg);
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
        #endregion

        #endregion <方法>

        #region <私有方法>
        #endregion <私有方法>
    }
}
