#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024   保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：LAPTOP-4OVFGLIB
 * 命名空间：Ideal.Shop
 * 文件名：Shop_ClientModel
 * 
 * 创建者：理想再见
 * 创建时间：2024/3/25 11:12:11
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
using Ideal.Ideal.Common.Enums;
using Ideal.Ideal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Shop.Model
{
    public class Shop_ClientModel : BaseModel
    {
        #region <属性>
        /// <summary>
        /// 客户
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.PRIMARY_KEY)]
        public string ClientID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Name { get; set; }
        /// <summary>
        /// 电话
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Phone { get; set; }
        #endregion <属性>

        #region <方法>

        public Shop_ClientModel()
        {
            this.Owner_DB_TableName = "Shop_Client";
        }
        #endregion <方法>

        #region <私有方法>
        #endregion <私有方法>
    }
}
