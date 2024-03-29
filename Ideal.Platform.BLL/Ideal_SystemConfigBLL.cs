#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024   保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：LAPTOP-4OVFGLIB
 * 命名空间：Ideal.Platform.BLL
 * 文件名：SystemConfigBLL
 * 
 * 创建者：理想再见
 * 创建时间：2024/3/29 15:06:45
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
using Ideal.Ideal.DB.Base;
using Ideal.Ideal.Model;
using Ideal.Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.BLL
{
    public class Ideal_SystemConfigBLL
    {
        #region <属性>
        #endregion <属性>

        #region <方法>

        #region 增删改

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="model"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateSystemConfig(Ideal_SystemConfigModel model, out int code, out string msg)
        {
            code = 11;
            msg = "添加失败！";
            bool flag = false;
            Ideal_SystemConfigModel ideal_RoleModel = new Ideal_SystemConfigModel();

            flag = BaseControl.UpdateDB<Ideal_SystemConfigModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "修改成功！" : "修改失败！";
            return flag;
        }

        #endregion


        #region 查询
        /// <summary>
        /// 根据ID查询角色
        /// </summary>
        /// <param name="RoleID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_SystemConfigModel GetSystemConfigByID(string SystemConfigID, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_SystemConfigModel model = new Ideal_SystemConfigModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlWhere = " AND SystemConfigID = '" + SystemConfigID + "'";
            model = BaseControl.GetModel<Ideal_SystemConfigModel>(param, out code, out msg);
            return model;
        }

        #endregion

        #endregion <方法>

        #region <私有方法>
        #endregion <私有方法>
    }
}
