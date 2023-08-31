using Ideal.Ideal.DB.Base;
using Ideal.Ideal.Model;
using Ideal.Platform.Common.Snowflake;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ideal.Platform.Common.MD5;
using Ideal.Platform.Common.Config;

namespace Ideal.Platform.BLL
{
    public class Ideal_AccountBLL
    {
        #region 增删改
        /// <summary>
        /// 新增账号
        /// </summary>
        /// <param name="model"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool InsertAccount(Ideal_AccountModel model, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "新增失败！";
            Ideal_AccountModel account = new Ideal_AccountModel();
            account = GetAccountDetailByName(model.AccountName, out int xcode, out string xmsg);
            if (xcode == 20)
            {
                code = 11;
                msg = "账号不能重复！";
                return false;
            }
            account = GetAccountDetailUserID(model.UserID, out xcode, out xmsg);
            if (xcode == 20)
            {
                code = 11;
                msg = "此人员已绑定账号！";
                return false;
            }
            model.Password = MD5.Encrypt(model.Password);
            model.CreateTime = DateTime.Now;
            flag = BaseControl.InsertDB<Ideal_AccountModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "新增成功！" : "新增失败！";
            return flag;
        }
        /// <summary>
        /// 修改账号
        /// </summary>
        /// <param name="model"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateAccount(Ideal_AccountModel model, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "修改失败！";
            Ideal_AccountModel account = new Ideal_AccountModel();
            account = GetAccountDetailByName(model.AccountName, out int xcode, out string xmsg);
            if (xcode == 21)
            {
                code = 11;
                msg = "没有找到此账号！";
                return false;
            }
            account = GetAccountDetailUserID(model.UserID, out xcode, out xmsg);
            if (xcode == 20)
            {
                code = 11;
                msg = "此人员已绑定账号！";
                return false;
            }
            model.Password = MD5.Encrypt(model.Password);
            flag = BaseControl.InsertDB<Ideal_AccountModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "修改成功！" : "修改失败！";
            return flag;
        }
        /// <summary>
        /// 删除账号
        /// </summary>
        /// <param name="AccountName"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool DeteleAccount(string AccountName, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "删除失败！";
            Ideal_AccountModel account = new Ideal_AccountModel();
            account = GetAccountDetailByName(AccountName, out int xcode, out string xmsg);
            if (xcode == 21)
            {
                code = 11;
                msg = "没有找到此账号！";
                return false;
            }

            flag = BaseControl.InsertDB<Ideal_AccountModel>(account, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "删除成功！" : "删除失败！";
            return flag;
        }

        #endregion

        #region 查询

        /// <summary>
        /// 通过账号查询账号详情
        /// </summary>
        /// <param name="AccountName"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_AccountModel GetAccountDetailByName(string AccountName, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_AccountModel model = new Ideal_AccountModel();
            PageQueryParam param = new PageQueryParam();
            param.WithNoLock = true;
            param.SqlBody = " Ideal_Account as a Left Join Ideal_Role as b on a.RoleID = b.RoleID Left Join Ideal_User as c on a.UserID = b.UserID";
            param.SqlColumn = "a.*,b.RoleName,c.UserName";
            param.SqlWhere = " AND a.AccountName = '" + AccountName + "'";
            model = BaseControl.GetModel<Ideal_AccountModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 根据UserID查询账号详情
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_AccountModel GetAccountDetailUserID(string UserID, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_AccountModel model = new Ideal_AccountModel();
            PageQueryParam param = new PageQueryParam();
            param.WithNoLock = true;
            param.SqlBody = " Ideal_Account as a Left Join Ideal_Role as b on a.RoleID = b.RoleID Left Join Ideal_User as c on a.UserID = b.UserID";
            param.SqlColumn = "a.*,b.RoleName,c.UserName";
            param.SqlWhere = " AND a.UserID = '" + UserID + "'";
            model = BaseControl.GetModel<Ideal_AccountModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 根据账号密码查询账号
        /// </summary>
        /// <param name="AccountName"></param>
        /// <param name="Password"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_AccountModel GetAccountDetailByNameAndPassword(string AccountName, string Password, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_AccountModel model = new Ideal_AccountModel();
            PageQueryParam param = new PageQueryParam();
            param.WithNoLock = true;
            param.SqlBody = " Ideal_Account as a Left Join Ideal_Role as b on a.RoleID = b.RoleID Left Join Ideal_User as c on a.UserID = c.UserID";
            param.SqlColumn = "a.*,b.RoleName,c.UserName";
            param.SqlWhere = " AND a.AccountName = '" + AccountName + "' AND Password = '" + Password + "'";
            model = BaseControl.GetModel<Ideal_AccountModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 查询账号列表 分页
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public PageModel<Ideal_AccountModel> GetAccountList(AccountQuery query, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            PageModel<Ideal_AccountModel> model = new PageModel<Ideal_AccountModel>();
            PageQueryParam param = new PageQueryParam();
            param.WithNoLock = true;
            param.SqlBody = " Ideal_Account as a Left Join Ideal_Role as b on a.RoleID = b.RoleID Left Join Ideal_User as c on a.UserID = b.UserID";
            param.SqlColumn = "a.*,b.RoleName,c.UserName";
            param.PageSize = query.PageSize;
            param.PageIndex = query.PageIndex;
            if (!string.IsNullOrEmpty(query.UserName))
            {
                param.SqlWhere = " AND c.UserName like '%" + query.UserName + "%'";
            }
            if (!string.IsNullOrEmpty(query.AccountStatus))
            {
                param.SqlWhere = " AND a.AccountStatus = '" + query.AccountStatus + "'";
            }
            model = BaseControl.GetPageModels<Ideal_AccountModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 查询所有账号
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<Ideal_AccountModel> GetAccountAllList(AccountQuery query, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            List<Ideal_AccountModel> model = new List<Ideal_AccountModel>();
            PageQueryParam param = new PageQueryParam();
            param.WithNoLock = true;
            param.SqlBody = " Ideal_Account as a Left Join Ideal_Role as b on a.RoleID = b.RoleID Left Join Ideal_User as c on a.UserID = b.UserID";
            param.SqlColumn = "a.*,b.RoleName,c.UserName";
            if (!string.IsNullOrEmpty(query.UserName))
            {
                param.SqlWhere = " AND c.UserName like '%" + query.UserName + "%'";
            }
            if (!string.IsNullOrEmpty(query.AccountStatus))
            {
                param.SqlWhere = " AND a.AccountStatus = '" + query.AccountStatus + "'";
            }
            model = BaseControl.GetAllModels<Ideal_AccountModel>(param, out code, out msg);
            return model;
        }
        #endregion
    }
}
