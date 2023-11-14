using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model
{
    public class TableFields
    {
        public string DBID { get; set; }

        public string TableName { get; set; }
        /// <summary>
        /// 字段序号
        /// </summary>
        public string Colorder { get; set; }

        /// <summary>
        /// 字段名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 字段类型
        /// </summary>
        public string FieldsType { get; set; }
        /// <summary>
        /// 字段长度
        /// </summary>
        public string FieldsLength { get; set; }
        /// <summary>
        /// 小数位
        /// </summary>
        public string Decimals { get; set; }
        /// <summary>
        /// 是否为空
        /// </summary>
        public string IsNull { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public string Defaultvalue { get; set; }
        /// <summary>
        /// 是否自增长列
        /// </summary>
        public string AddColumn { get; set; }
        /// <summary>
        /// 是否主键
        /// </summary>
        public string IsPrimaryKey { get; set; }

        
    }
}
