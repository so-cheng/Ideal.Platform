using Ideal.Ideal.Common.Enums;
using Ideal.Ideal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model
{
    public class Ideal_FlowTemplateModel : BaseModel
    {
        public Ideal_FlowTemplateModel()
        {
            this.Owner_DB_TableName = "Ideal_FlowTemplate";
            NodeConfig = new Ideal_StepTemplateModel();
        }
        /// <summary>
        /// 流程模板ID
        /// </summary>
		[DbFieldAttribute(DbFieldMode.PRIMARY_KEY)]
        public string FlowTemplateID { get; set; }
        /// <summary>
        /// 流程模板名称
        /// </summary>
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string FlowTemplateName { get; set; }
        /// <summary>
        /// 步骤配置
        /// </summary>
        public Ideal_StepTemplateModel NodeConfig { get; set; }
    }
}
