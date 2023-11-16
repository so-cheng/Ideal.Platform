using Ideal.Ideal.Common.Enums;
using Ideal.Ideal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model
{
    public class Ideal_StepUserModel : BaseModel
    {

        public Ideal_StepUserModel()
        {
            this.Owner_DB_TableName = "Ideal_StepUser";
        }
        /// <summary>
        /// 步骤审核人员ID
        /// </summary>
		[DbFieldAttribute(DbFieldMode.PRIMARY_KEY)]
        public string StepUserFolwID { get; set; }
        /// <summary>
        /// 步骤ID
        /// </summary>
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string StepID { get; set; }
        /// <summary>
        /// 人员ID
        /// </summary>
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string UserID { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public int Sort { get; set; }
    }
}
