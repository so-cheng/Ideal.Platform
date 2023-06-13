using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Common.Data
{
    /// <summary>
    /// 人员状态枚举类
    /// </summary>
    public class UserStatus
    {
        /// <summary>
        /// 离职
        /// </summary>
        public const string Quit = "1";
        public const string Quit_CH = "离职";

        /// <summary>
        /// 在职
        /// </summary>
        public const string Incumbency = "0";
        public const string Incumbency_CH = "在职";
    }
}
