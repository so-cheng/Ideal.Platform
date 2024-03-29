#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024   保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：LAPTOP-4OVFGLIB
 * 命名空间：Ideal.Platform.Service
 * 文件名：SystemConfigService
 * 
 * 创建者：理想再见
 * 创建时间：2024/3/29 15:06:57
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 修改人：
 * 时间：
 * 修改说明：
 *
 * 版本：V1.0.1
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Ideal.Ideal.Model;
using Ideal.Platform.BLL;
using Ideal.Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Service
{
    public class Ideal_SystemConfigService
    {
        #region <属性>
        #endregion <属性>

        #region <方法>

        public ReturnSummary UpdateSystemConfig(Ideal_SystemConfigModel model)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_SystemConfigBLL ideal_CompanyBLL = new Ideal_SystemConfigBLL();
            flag = ideal_CompanyBLL.UpdateSystemConfig(model, out code, out msg);

            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }
        public ReturnSummary GetSystemConfigByID(string SystemConfigID)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_SystemConfigBLL ideal_CompanyBLL = new Ideal_SystemConfigBLL();
            Ideal_SystemConfigModel model = new Ideal_SystemConfigModel();
            model = ideal_CompanyBLL.GetSystemConfigByID(SystemConfigID, out code, out msg);
            ReturnSummary returnSummary = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = code == 21 ? false : true,
                Data = model
            };
            return returnSummary;
        }
        #endregion <方法>

        #region <私有方法>
        #endregion <私有方法>
    }
}
