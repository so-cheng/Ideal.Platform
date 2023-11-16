using Ideal.Ideal.Common.Enums;
using Ideal.Ideal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model
{
    public class Ideal_StepConditionModel : BaseModel
    {

        public Ideal_StepConditionModel()
        {
            this.Owner_DB_TableName = "Ideal_StepCondition";
        }
        /// <summary>
        /// 步骤条件ID
        /// </summary>
		[DbFieldAttribute(DbFieldMode.PRIMARY_KEY)]
        public string StepConditionID { get; set; }
        /// <summary>
        /// 步骤ID
        /// </summary>
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string StepID { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Label { get; set; }
        /// <summary>
        /// 条件字段
        /// </summary>
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Field { get; set; }
        /// <summary>
        /// 运算符
        /// </summary>
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Operator { get; set; }
        /// <summary>
        /// 值
        /// </summary>
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Value { get; set; }
    }
}
