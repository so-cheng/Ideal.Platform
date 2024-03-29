#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024   保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：LAPTOP-4OVFGLIB
 * 命名空间：Ideal.Shop.Service
 * 文件名：Shop_OrderBLL
 * 
 * 创建者：理想再见
 * 创建时间：2024/3/25 13:23:36
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
using Ideal.Ideal.Model;
using Ideal.Platform.Model.Query;
using Ideal.Platform.Model;
using Ideal.Shop.BLL;
using Ideal.Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ideal.Shop.Model.Query;
using StackExchange.Redis;

namespace Ideal.Shop.Service
{
    public class Shop_OrderService
    {
        #region <属性>
        #endregion <属性>

        #region <方法>

        #region 增删改
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary InsertOrder(Shop_OrderModel model)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Shop_OrderBLL shop_OrderBLL = new Shop_OrderBLL();
            flag = shop_OrderBLL.InsertOrder(model, out code, out msg);
            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }
        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary UpdateOrder(Shop_OrderModel model)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Shop_OrderBLL shop_OrderBLL = new Shop_OrderBLL();
            flag = shop_OrderBLL.UpdateOrder(model, out code, out msg);
            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="AccountName"></param>
        /// <returns></returns>
        public ReturnSummary DeleteOrder(string OrderID)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Shop_OrderBLL shop_OrderBLL = new Shop_OrderBLL();
            flag = shop_OrderBLL.DeleteOrder(OrderID, out code, out msg);

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
        /// 查询订单详情
        /// </summary>
        /// <param name="AccountName"></param>
        /// <returns></returns>
        public ReturnSummary GetOrderByID(string OrderID)
        {
            int code = 21;
            string msg = string.Empty;
            Shop_OrderBLL shop_OrderBLL = new Shop_OrderBLL();
            Shop_OrderModel model = new Shop_OrderModel();
            model = shop_OrderBLL.GetOrderByID(OrderID, out code, out msg);
            if (code == 20 )
            {
                model.ShippingStatusName = model.ShippingStatus == "1" ? "已发货" : "未发货";
                model.SignStatusName = model.SignStatus == "1" ? "已签收" : "未签收";
                model.IsReturnName = model.IsReturn == "1" ? "是" : "否";
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
        /// <summary>
        /// 获取订单分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnSummary GetOrderList(OrderQuery query)
        {
            int code = 21;
            string msg = string.Empty;
            Shop_OrderBLL shop_OrderBLL = new Shop_OrderBLL();
            PageModel<Shop_OrderModel> model = new PageModel<Shop_OrderModel>();
            model = shop_OrderBLL.GetOrderList(query, out code, out msg);

            foreach (var item in model.PageList)
            {

                item.ShippingStatusName = item.ShippingStatus == "1" ? "已发货" : "未发货";
                item.SignStatusName = item.SignStatus == "1" ? "已签收" : "未签收";
                item.IsReturnName = item.IsReturn == "1" ? "是" : "否";
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
        #endregion

        #endregion <方法>

        #region <私有方法>
        #endregion <私有方法>
    }
}
