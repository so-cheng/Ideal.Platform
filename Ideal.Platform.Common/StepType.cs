using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Common
{
    public class StepType
    {
        /// <summary>
        /// 发起人
        /// </summary>
        public const string Initiator = "0";
        public const string Initiator_CH = "发起人";

        /// <summary>
        /// 节点审批
        /// </summary>
        public const string NodeApproval = "1";
        public const string NodeApproval_CH = "节点审批";
        /// <summary>
        /// 抄送人
        /// </summary>
        public const string CopyUser = "2";
        public const string CopyUser_CH = "抄送人";
        /// <summary>
        /// 条件路由
        /// </summary>
        public const string ConditionRout = "3";
        public const string ConditionRout_CH = "条件路由";
        /// <summary>
        /// 条件
        /// </summary>
        public const string Condition = "4";
        public const string Condition_CH = "条件";
    }
}
