using Ideal.Ideal.DB.Base;
using Ideal.Ideal.Model;
using Ideal.Platform.Common.MD5;
using Ideal.Platform.Common.Snowflake;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.BLL
{
    public class Ideal_UserBLL
    {

        #region 增删改
        /// <summary>
        /// 新增人员
        /// </summary>
        /// <param name="model"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool InsertUser(Ideal_UserModel model, out int code, out string msg)
        {
            code = 11;
            msg = "添加失败！";
            bool flag = false;
            model.UserID = SnowFlakeUse.GetSnowflakeID();
            Ideal_UserModel ideal_RoleModel = new Ideal_UserModel();
            ideal_RoleModel = GetUserDetailByUserIDCard(model.UserIDCard, out code, out msg);
            if (code == 20)
            {
                code = 11;
                msg = "身份证信息不能重复！";
                return false;
            }
            ideal_RoleModel = GetUserDetailByUserCode(model.UserCode, out code, out msg);
            if (code == 20)
            {
                code = 11;
                msg = "人员编号不能重复！";
                return false;
            }
            //model.PoliticalStatus = string.IsNullOrEmpty(model.PoliticalStatus) ? "NULL" : model.PoliticalStatus;
            //model.Education = string.IsNullOrEmpty(model.Education) ? "NULL" : model.Education;
            //model.CheckType = string.IsNullOrEmpty(model.CheckType) ? "NULL" : model.CheckType;
            //model.Sex = string.IsNullOrEmpty(model.Sex) ? "NULL" : model.Sex;
            Ideal_AccountModel account = new Ideal_AccountModel();
            account.AccountName = model.AccountName;
            account.Password = MD5.Encrypt(model.PassWord);
            account.RoleID = model.RoleID;
            account.UserID = model.UserID;
            account.AccountStatus = "0";
            account.AccountLevel = model.AccountLevel;
            List<string> sqlList = new List<string>();
            sqlList.Add(BaseControl.GetInsert2DBSQL(model));
            sqlList.Add(BaseControl.GetInsert2DBSQL(account));
            int count = BaseControl.ExecuteSqlTran(sqlList, out code, out msg);
            code = count > 0 ? 10 : 11;
            msg = count > 0 ? "新增成功！" : "新增失败！";
            return flag;
        }
        /// <summary>
        /// 修改人员
        /// </summary>
        /// <param name="model"></param>
        /// <param name="postModel"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateUser(Ideal_UserModel model, out int code, out string msg)
        {
            code = 11;
            msg = "修改失败！";
            bool flag = false;
            Ideal_UserModel ideal_RoleModel = new Ideal_UserModel();
            ideal_RoleModel = GetUserDetailByUserID(model.UserID, out code, out msg);
            if (code != 20)
            {
                code = 11;
                msg = "没有找到人员信息！";
                return false;
            }
            ideal_RoleModel = GetUserDetailByUserIDCard(model.UserIDCard, out code, out msg);
            if (code == 20 && ideal_RoleModel.UserID != model.UserID)
            {
                code = 11;
                msg = "身份证信息不能重复！";
                return false;
            }
            ideal_RoleModel = GetUserDetailByUserCode(model.UserCode, out code, out msg);
            if (code == 20 && ideal_RoleModel.UserID != model.UserID)
            {
                code = 11;
                msg = "人员编号不能重复！";
                return false;
            }
            List<string> sqlList = new List<string>();
            //sqlList.Add(BaseControl.GetUpdate2DBSQL(model));//修改人员
            bool count = BaseControl.UpdateDB<Ideal_UserModel>(model, out code, out msg);
            code = count ? 10 : 11;
            msg = count ? "修改成功！" : "修改失败！";
            return count;
        }
        /// <summary>
        /// 删除人员
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool DeteleUser(string UserID, out int code, out string msg)
        {
            code = 11;
            msg = "删除失败！";
            bool flag = false;
            Ideal_UserModel ideal_UserModel = new Ideal_UserModel();
            ideal_UserModel = GetUserDetailByUserID(UserID, out code, out msg);
            if (code != 20)
            {
                code = 11;
                msg = "没有找到人员信息！";
                return false;
            }

            List<string> sqlList = new List<string>();
            sqlList.Add(BaseControl.GetDeleteFromDBSQL<Ideal_UserModel>(ideal_UserModel));//删除人员
            //删除账号
            Ideal_AccountBLL ideal_AccountBLL = new Ideal_AccountBLL();
            Ideal_AccountModel ideal_AccountModel = ideal_AccountBLL.GetAccountDetailUserID(UserID, out int xcode, out string xmsg);
            if (xcode == 20)
            {
                sqlList.Add(BaseControl.GetDeleteFromDBSQL<Ideal_AccountModel>(ideal_AccountModel));
            }
            int count = BaseControl.ExecuteSqlTran(sqlList, out code, out msg);
            code = count > 0 ? 10 : 11;
            msg = count > 0 ? "删除成功！" : "删除失败！";
            return flag;
        }
        #endregion

        #region 查询
        /// <summary>
        /// 根据UserID查询人员岗位
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_UserPostModel GetUserPostDetailByUserID(string UserID, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_UserPostModel ideal_UserModel = new Ideal_UserPostModel();
            PageQueryParam parm = new PageQueryParam();
            parm.SqlWhere = " AND UserID = '" + UserID + "'";
            ideal_UserModel = BaseControl.GetModel<Ideal_UserPostModel>(parm, out code, out msg);
            return ideal_UserModel;
        }
        /// <summary>
        /// 根据身份证查询人员详情
        /// </summary>
        /// <param name="UserIDCard"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_UserModel GetUserDetailByUserIDCard(string UserIDCard, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_UserModel ideal_UserModel = new Ideal_UserModel();
            PageQueryParam parm = new PageQueryParam();
            parm.SqlWhere = " AND UserIDCard = '" + UserIDCard + "'";
            ideal_UserModel = BaseControl.GetModel<Ideal_UserModel>(parm, out code, out msg);
            return ideal_UserModel;
        }
        /// <summary>
        /// 根据人员编号查询人员详情
        /// </summary>
        /// <param name="UserCode"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_UserModel GetUserDetailByUserCode(string UserCode, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_UserModel ideal_UserModel = new Ideal_UserModel();
            PageQueryParam parm = new PageQueryParam();
            parm.SqlWhere = " AND UserCode = '" + UserCode + "'";
            ideal_UserModel = BaseControl.GetModel<Ideal_UserModel>(parm, out code, out msg);
            return ideal_UserModel;
        }
        /// <summary>
        /// 根据UserID查询人员详情
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_UserModel GetUserDetailByUserID(string UserID, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_UserModel ideal_UserModel = new Ideal_UserModel();
            PageQueryParam parm = new PageQueryParam();
            parm.WithNoLock = true;
            parm.SqlBody = " Ideal_User as a Left Join Ideal_Dept as d on d.DeptID = a.DeptID LEFT JOIN Ideal_Account b ON a.UserID = b.UserID LEFT JOIN Ideal_Role c ON b.RoleID = c.RoleID";
            parm.SqlColumn = "a.*,d.DeptName,c.RoleID,c.RoleName,b.AccountName,b.AccountStatus,b.AccountLevel";
            parm.SqlWhere = " AND a.UserID = '" + UserID + "'";
            ideal_UserModel = BaseControl.GetModel<Ideal_UserModel>(parm, out code, out msg);
            return ideal_UserModel;
        }
        /// <summary>
        /// 查询人员分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public PageModel<Ideal_UserModel> GetUserList(UserQuery query, out int code, out string msg)
        {
            code = 22;
            msg = "查询失败！";
            PageModel<Ideal_UserModel> list = new PageModel<Ideal_UserModel>();
            PageQueryParam param = new PageQueryParam();
            param.WithNoLock = true;
            param.SqlBody = " Ideal_User as a Left Join Ideal_Dept as d on d.DeptID = a.DeptID LEFT JOIN Ideal_Account b ON a.UserID = b.UserID LEFT JOIN Ideal_Role c ON b.RoleID = c.RoleID";
            param.SqlColumn = "a.*,d.DeptName,c.RoleID,c.RoleName,b.AccountName,b.AccountStatus,b.AccountLevel";
            param.PageSize = query.PageSize;
            param.PageIndex = query.PageIndex;
            if (!string.IsNullOrEmpty(query.UserName))
            {
                param.SqlWhere += " AND a.UserName like '%" + query.UserName + "%'";
            }
            if (!string.IsNullOrEmpty(query.UserCode))
            {
                param.SqlWhere += " AND a.UserCode like '%" + query.UserCode + "%'";
            }
            if (!string.IsNullOrEmpty(query.UserIDCard))
            {
                param.SqlWhere += " AND a.UserIDCard like '%" + query.UserIDCard + "%'";
            }
            if (!string.IsNullOrEmpty(query.DeptID))
            {
                param.SqlWhere += " AND a.DeptID in (" + query.DeptID + ")";
            }
            if (!string.IsNullOrEmpty(query.Sex))
            {
                param.SqlWhere += " AND a.Sex = '" + query.Sex + "'";
            }
            if (!string.IsNullOrEmpty(query.CheckType))
            {
                param.SqlWhere += " AND a.CheckType = '" + query.CheckType + "'";
            }
            if (!string.IsNullOrEmpty(query.UserStatus))
            {
                param.SqlWhere += " AND a.UserStatus = '" + query.UserStatus + "'";
            }
            list = BaseControl.GetPageModels<Ideal_UserModel>(param, out code, out msg);
            return list;
        }
        /// <summary>
        /// 查询所有人员
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<Ideal_UserModel> GetUserAllList(UserQuery query, out int code, out string msg)
        {
            code = 22;
            msg = "查询失败！";
            List<Ideal_UserModel> list = new List<Ideal_UserModel>();
            PageQueryParam param = new PageQueryParam();
            param.WithNoLock = true;
            param.SqlBody = " Ideal_User as a Left Join  Ideal_UserPost as b on a.UserID = b.UserID Left Join Ideal_Post as c on b.PostID = c.PostID Left Join Ideal_Dept as d on d.DeptID = a.DeptID";
            param.SqlColumn = "a.*,c.PostName,d.DeptName ";
            if (!string.IsNullOrEmpty(query.UserName))
            {
                param.SqlWhere += " AND a.UserName like '%" + query.UserName + "%'";
            }
            if (!string.IsNullOrEmpty(query.UserCode))
            {
                param.SqlWhere += " AND a.UserCode like '%" + query.UserCode + "%'";
            }
            if (!string.IsNullOrEmpty(query.UserIDCard))
            {
                param.SqlWhere += " AND a.UserIDCard like '%" + query.UserIDCard + "%'";
            }
            if (!string.IsNullOrEmpty(query.DeptID))
            {
                param.SqlWhere += " AND a.DeptID = '" + query.DeptID + "'";
            }
            if (!string.IsNullOrEmpty(query.Sex))
            {
                param.SqlWhere += " AND a.Sex = '" + query.Sex + "'";
            }
            if (!string.IsNullOrEmpty(query.CheckType))
            {
                param.SqlWhere += " AND a.CheckType = '" + query.CheckType + "'";
            }
            if (!string.IsNullOrEmpty(query.UserStatus))
            {
                param.SqlWhere += " AND a.UserStatus = '" + query.UserStatus + "'";
            }
            list = BaseControl.GetAllModels<Ideal_UserModel>(param, out code, out msg);
            return list;
        }
        #endregion
    }
}
