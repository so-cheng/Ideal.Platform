#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024   保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：LAPTOP-4OVFGLIB
 * 命名空间：Ideal.Shop.BLL
 * 文件名：Shop_OrderBLL
 * 
 * 创建者：理想再见
 * 创建时间：2024/3/25 11:18:24
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
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using Ideal.Shop.Model;
using Ideal.Shop.Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Shop.BLL
{
    public class Shop_OrderBLL
    {
        #region <属性>
        #endregion <属性>

        #region <方法>

        #region 增删改
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="model"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool InsertOrder(Shop_OrderModel model, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "添加失败！";
            model.OrderID = SnowFlakeUse.GetSnowflakeID();
            Shop_ClientBLL bll = new Shop_ClientBLL();
            List<string> sqls = new List<string>();
            Shop_ClientModel shop_ClientModel = bll.GetClientByPhone(model.Phone, out int xcode, out string xmsg);

            if (xcode != 20)
            {
                shop_ClientModel.ClientID = SnowFlakeUse.GetSnowflakeID();
                shop_ClientModel.Name = model.Name;
                shop_ClientModel.Phone = model.Phone;
                shop_ClientModel.Creator = model.Creator;
                sqls.Add(GetClientSql(shop_ClientModel));
            }
            sqls.Add(BaseControl.GetInsert2DBSQL<Shop_OrderModel>(model));
            int count = BaseControl.ExecuteSqlTran(sqls, out code, out msg);
            flag = count > 0 ? true : false;
            code = flag ? 10 : 11;
            msg = flag ? "添加成功！" : "添加失败！";
            return flag;
        }
        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="model"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateOrder(Shop_OrderModel model, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "修改失败！";
            Shop_OrderModel order = GetOrderByID(model.OrderID, out code, out msg);
            if (code != 20)
            {
                code = 11;
                msg = "没找到此订单！";
                return flag;
            }
            flag = BaseControl.UpdateDB<Shop_OrderModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "修改成功！" : "修改失败！";
            return flag;
        }
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool DeleteOrder(string OrderID, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "删除失败！";
            Shop_OrderModel dept = new Shop_OrderModel();
            dept = GetOrderByID(OrderID, out int xcode, out string xmsg);
            if (xcode != 20)
            {
                code = 11;
                msg = "没有找到订单数据！";
                return false;
            }
            flag = BaseControl.Delete2DB<Shop_OrderModel>(dept, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "删除成功！" : "删除失败！";
            return flag;
        }


        #endregion


        #region 查询

        /// <summary>
        /// 根据OrderID查询
        /// </summary>
        /// <param name="DeptID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Shop_OrderModel GetOrderByID(string OrderID, out int code, out string msg)
        {
            code = 22;
            msg = "查询失败！";
            Shop_OrderModel model = new Shop_OrderModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlWhere = " AND OrderID = '" + OrderID + "'";
            model = BaseControl.GetModel<Shop_OrderModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 查询订单列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public PageModel<Shop_OrderModel> GetOrderList(OrderQuery query, out int code, out string msg)
        {
            code = 22;
            msg = "查询失败！";
            List<Shop_OrderModel> list = new List<Shop_OrderModel>();
            PageQueryParam param = new PageQueryParam();
            param.WithNoLock = true;
            //param.SqlBody = " Iedal_Dept a  LEFT JOIN Ideal_Company b ON a.CompanyID = b.CompanyID ";
            //param.SqlColumn = "a.*,b.CompanyName";
            param.PageSize = query.PageSize;
            param.PageIndex = query.PageIndex;
            if (!string.IsNullOrEmpty(query.Name))
            {
                param.SqlWhere += " AND Name  like '%" + query.Name + "%'";
            }
            if (!string.IsNullOrEmpty(query.Phone))
            {
                param.SqlWhere += " AND Phone = '" + query.Phone + "'";
            }
            if (!string.IsNullOrEmpty(query.Address))
            {
                param.SqlWhere += " AND Address  like '%" + query.Address + "%'";
            }
            if (!string.IsNullOrEmpty(query.ShippingStatus))
            {
                param.SqlWhere += " AND ShippingStatus = '" + query.ShippingStatus + "'";
            }
            if (!string.IsNullOrEmpty(query.SignStatus))
            {
                param.SqlWhere += " AND SignStatus = '" + query.SignStatus + "'";
            }
            if (!string.IsNullOrEmpty(query.ProductName))
            {
                param.SqlWhere += " AND ProductName  like '%" + query.ProductName + "%'";
            }
            if (!string.IsNullOrEmpty(query.TrackingNum))
            {
                param.SqlWhere += " AND TrackingNum = '" + query.TrackingNum + "'";
            }

            if (!string.IsNullOrEmpty(query.IsReturn))
            {
                param.SqlWhere += " AND IsReturn = '" + query.IsReturn + "'";
            }
            if (!string.IsNullOrEmpty(query.StarCreatTime))
            {
                param.SqlWhere += " AND CreatTime >= '" + query.StarCreatTime + "'";
            }
            if (!string.IsNullOrEmpty(query.EndCreatTime))
            {
                param.SqlWhere += " AND CreatTime <= '" + query.EndCreatTime + "'";
            }
            PageModel<Shop_OrderModel> pageModel = BaseControl.GetPageModels<Shop_OrderModel>(param, out code, out msg);

            return pageModel;
        }
        #endregion

        #endregion <方法>
        /// <summary>
        /// 获取客户Sql
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetClientSql(Shop_ClientModel model)
        {
            string str = string.Empty;
            str = BaseControl.GetInsert2DBSQL<Shop_ClientModel>(model);
            return str;

        }
        #region <私有方法>
        #endregion <私有方法>
    }
}
