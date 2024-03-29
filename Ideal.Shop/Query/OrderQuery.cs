#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024   保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：LAPTOP-4OVFGLIB
 * 命名空间：Ideal.Shop.Query
 * 文件名：OrderQuery
 * 
 * 创建者：理想再见
 * 创建时间：2024/3/25 11:14:13
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
using Ideal.Platform.Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Shop.Model.Query
{
    public class OrderQuery: QueryMust
    {
        #region <属性>

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ShippingStatus { get; set; }
        public string SignStatus { get; set; }
        public string ProductName { get; set; }
        public string IsReturn { get; set; }
        public string StarCreatTime { get; set; }
        public string EndCreatTime { get; set; }

        public string TrackingNum { get; set; }
        #endregion <属性>

        #region <方法>
        #endregion <方法>

        #region <私有方法>
        #endregion <私有方法>
    }
}
