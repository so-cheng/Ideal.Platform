using Ideal.Ideal.Common.Enums;
using Ideal.Ideal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model
{
    public class Ideal_StepTemplateModel : BaseModel
    {
        public Ideal_StepTemplateModel()
        {
            this.Owner_DB_TableName = "Ideal_StepTemplate";
            ChildNode = new Ideal_StepTemplateModel();
            ConditionList = new List<Ideal_StepConditionModel>();
            NodeUserList = new List<Ideal_StepUserModel>();
            NodeDeptList = new List<Ideal_StepDeptModel>();
            ConditionNodes = new List<Ideal_StepTemplateModel>();
        }
        /// <summary>
        /// 步骤ID
        /// </summary>
		[DbFieldAttribute(DbFieldMode.PRIMARY_KEY)]
        public string StepID { get; set; }
        /// <summary>
        /// 模板ID
        /// </summary>
		[DbFieldAttribute(DbFieldMode.ONLY_INSERT)]
        public string FlowTemplateID { get; set; }
        /// <summary>
        /// 步骤名称
        /// </summary>
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string StepName { get; set; }
        /// <summary>
        /// 审核类型  1.部门  2.人员
        /// </summary> 
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string SetType { get; set; }
        /// <summary>
        /// 步骤类型 0.发起人 1.节点审批  2.抄送人  4.条件路由  3.条件
        /// </summary>
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Type { get; set; }
        /// <summary>
        /// 父级步骤ID
        /// </summary>
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string ParentStepID { get; set; }
        /// <summary>
        /// 步骤序号
        /// </summary>
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public decimal StepNo { get; set; }
        /// <summary>
        /// 条件关系  1.且   2.或2
        /// </summary>
        [DbField(DbFieldMode.ALL_SAVE)]
        public string ConditionMode { get; set; }
        /// <summary>
        /// 多人审核方式 1.按顺序依次审批  2.会签 (可同时审批，每个人必须审批通过)   3.或签 (有一人审批通过即可)
        /// </summary>
        public string ExamineMode { get; set; }
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public Ideal_StepTemplateModel ChildNode { get; set; }
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public List<Ideal_StepConditionModel> ConditionList { get; set; }
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public List<Ideal_StepUserModel> NodeUserList { get; set; }
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public List<Ideal_StepDeptModel> NodeDeptList { get; set; }
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public List<Ideal_StepTemplateModel> ConditionNodes { get; set; }

        
        


    }
}
