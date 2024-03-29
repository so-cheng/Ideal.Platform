#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024   保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：LAPTOP-4OVFGLIB
 * 命名空间：Ideal.Platform.Model
 * 文件名：SystemConfigModel
 * 
 * 创建者：理想再见
 * 创建时间：2024/3/29 15:05:03
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
using XAct.Collections;

namespace Ideal.Platform.Model
{
    public class Ideal_SystemConfigModel:BaseModel
    {
        #region <属性>

        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.PRIMARY_KEY)]
        public string SystemConfigID { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string SystemName { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Intro { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string VersionNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string SystemImage { get; set; }
        #endregion <属性>

        #region <方法>

        public Ideal_SystemConfigModel()
        {
            this.Owner_DB_TableName = "Ideal_SystemConfig";
        }
        #endregion <方法>

        #region <私有方法>
        #endregion <私有方法>
    }
}
