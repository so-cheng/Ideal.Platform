using System;
using System.Collections.Generic;
using System.Text;

namespace Ideal.Platform.Common.Snowflake
{
    /// <summary>
    /// 版 本 v1.0
    /// Copyright (c) 2018 
    /// 创建人：zl
    /// 日 期：2018.11.08
    /// 描 述：雪花算法使用类
    /// </summary>
    public static class SnowFlakeUse
    {
        /// <summary>
        /// 生成一个雪花算法生成的唯一ID
        /// </summary>
        /// <returns></returns>
        public static string GetSnowflakeID()
        {
            string id = string.Empty;
            SnowFlakeBase.Instance.Init(10, 10);
            id = SnowFlakeBase.Instance.GetId().ToString();

            return id;
        }
    }
}
