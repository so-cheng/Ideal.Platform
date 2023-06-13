using System;
using System.Collections.Generic;
using System.Text;

namespace Ideal.Platform.Common.Data
{
    /// <summary>
    /// 证件类型枚举
    /// </summary>
    public class IDCardType
    {
        /// <summary>
        /// 身份证
        /// </summary>
        public const string ResidentID = "1";
        public const string ResidentID_CH = "身份证";

        /// <summary>
        /// 护照
        /// </summary>
        public const string Passport = "2";
        public const string Passport_CH = "护照";

        /// <summary>
        /// 内地通行证
        /// </summary>
        public const string MainlandPass = "3";
        public const string MainlandPass_CH = "内地通行证";
    }
}
