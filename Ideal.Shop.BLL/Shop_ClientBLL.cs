#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024   保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：LAPTOP-4OVFGLIB
 * 命名空间：Ideal.Shop.BLL
 * 文件名：Shop_ClientBLL
 * 
 * 创建者：理想再见
 * 创建时间：2024/3/25 13:08:58
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
using Ideal.Shop.Model.Query;
using Ideal.Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ideal.Platform.Common.Snowflake;

namespace Ideal.Shop.BLL
{
    public class Shop_ClientBLL
    {
        #region <属性>
        #endregion <属性>

        #region <方法>


        #region 增删改
        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="model"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool InsertClient(Shop_ClientModel model, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "添加失败！";
            model.ClientID = SnowFlakeUse.GetSnowflakeID();
            Shop_ClientBLL bll = new Shop_ClientBLL();
            List<string> sqls = new List<string>();
            flag = BaseControl.InsertDB<Shop_ClientModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "添加成功！" : "添加失败！";
            return flag;
        }


        /// <summary>
        /// 修改客户
        /// </summary>
        /// <param name="model"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateClient(Shop_ClientModel model, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "修改失败！";
            Shop_ClientModel order = GetClientByID(model.ClientID, out code, out msg);
            if (code != 20)
            {
                code = 11;
                msg = "没找到此客户！";
                return flag;
            }
            flag = BaseControl.UpdateDB<Shop_ClientModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "修改成功！" : "修改失败！";
            return flag;
        }
        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool DeleteClient(string ClientID, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "删除失败！";
            Shop_ClientModel dept = new Shop_ClientModel();
            dept = GetClientByID(ClientID, out int xcode, out string xmsg);
            if (xcode != 20)
            {
                code = 11;
                msg = "没找到此客户！";
                return false;
            }
            flag = BaseControl.Delete2DB<Shop_ClientModel>(dept, out code, out msg);
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
        public Shop_ClientModel GetClientByID(string ClientID, out int code, out string msg)
        {
            code = 22;
            msg = "查询失败！";
            Shop_ClientModel model = new Shop_ClientModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlWhere = " AND ClientID = '" + ClientID + "'";
            model = BaseControl.GetModel<Shop_ClientModel>(param, out code, out msg);
            return model;
        }

        public Shop_ClientModel GetClientByPhone(string Phone, out int code, out string msg)
        {
            code = 22;
            msg = "查询失败！";
            Shop_ClientModel model = new Shop_ClientModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlWhere = " AND Phone = '" + Phone + "'";
            model = BaseControl.GetModel<Shop_ClientModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 查询订单列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public PageModel<Shop_ClientModel> GetClientList(OrderQuery query, out int code, out string msg)
        {
            code = 22;
            msg = "查询失败！";
            List<Shop_ClientModel> list = new List<Shop_ClientModel>();
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
            PageModel<Shop_ClientModel> pageModel = BaseControl.GetPageModels<Shop_ClientModel>(param, out code, out msg);
            return pageModel;
        }
        #endregion
        #endregion <方法>

        #region <私有方法>
        #endregion <私有方法>
    }
}
