using Ideal.Ideal.Common.Enums;
using Ideal.Ideal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model
{
    /// <summary>
    /// 日志
    /// </summary>
    public class Ideal_LogModel : BaseModel
    {
        public Ideal_LogModel()
        {
            this.Owner_DB_TableName = "Ideal_Log";
        }
        /// <summary>
        /// 日志ID
        /// </summary>
        [DbFieldAttribute(DbFieldMode.PRIMARY_KEY)]
        public string LogID { get; set; }
        /// <summary>
        /// 日志类型 1.login 2.info 3.debug 4 warn 5.error 
        /// </summary>
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Type { get; set; }

        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string TypeName { get; set; }
        /// <summary>
        /// IP
        /// </summary>
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string IP { get; set; }

        /// <summary>
        /// 日志名称
        /// </summary>
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string LogName { get; set; }

        /// <summary>
        /// 请求接口
        /// </summary>
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string PostInterface { get; set; }
        /// <summary>
        /// 请求类型 1. post 2. get
        /// </summary>
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string PostType { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Detail { get; set; }
        /// <summary>
        /// 状态码
        /// </summary>
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string StatusCode { get; set; }
    }
}
