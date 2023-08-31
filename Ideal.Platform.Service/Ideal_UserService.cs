using Ideal.Ideal.DB;
using Ideal.Ideal.DB.Base;
using Ideal.Ideal.Log;
using Ideal.Ideal.Model;
using Ideal.Ideal.Redis;
using Ideal.Platform.BLL;
using Ideal.Platform.Common.Data;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using Newtonsoft.Json;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;


namespace Ideal.Platform.Service
{
    public class Ideal_UserService
    {
        #region 增删改
        /// <summary>
        /// 新增人员
        /// </summary>
        /// <param name="model"></param>
        /// <param name="postModel"></param>
        /// <returns></returns>
        public ReturnSummary InsertUser(Ideal_UserModel model, Ideal_UserPostModel postModel)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_UserBLL ideal_UserBLL = new Ideal_UserBLL();
            flag = ideal_UserBLL.InsertUser(model, postModel, out code, out msg);

            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }

        /// <summary>
        /// 修改人员
        /// </summary>
        /// <param name="model"></param>
        /// <param name="postModel"></param>
        /// <returns></returns>
        public ReturnSummary UpdateUser(Ideal_UserModel model, Ideal_UserPostModel postModel)
        {

            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_UserBLL ideal_UserBLL = new Ideal_UserBLL();
            flag = ideal_UserBLL.UpdateUser(model, postModel, out code, out msg);

            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }
        /// <summary>
        /// 删除人员
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public ReturnSummary DeteleUser(string UserID)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_UserBLL ideal_UserBLL = new Ideal_UserBLL();
            flag = ideal_UserBLL.DeteleUser(UserID, out code, out msg);
            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }
        #endregion

        #region 查询

        /// <summary>
        /// 查询人员详情
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public ReturnSummary GetUserDetailByUserID(string UserID)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_UserBLL ideal_UserBLL = new Ideal_UserBLL();
            Ideal_UserModel model = new Ideal_UserModel();
            model = ideal_UserBLL.GetUserDetailByUserID(UserID, out code, out msg);
            if (code == 20)
            {
                model.SexName = GetData.SexList().SingleOrDefault(a => a.Key == model.Sex)?.Value;
                model.UserStatusName = GetData.UserStatusList().SingleOrDefault(a => a.Key == Convert.ToInt32(model.UserStatus).ToString())?.Value;
                model.CheckTypeName = GetData.CheckTypeList().SingleOrDefault(a => a.Key == model.CheckType)?.Value;
                model.IDCardTypeName = GetData.IDCardTypeList().SingleOrDefault(a => a.Key == Convert.ToInt32(model.IDCardType).ToString())?.Value;
                model.EducationName = GetData.MyEducationDegreeList().SingleOrDefault(a => a.Key == Convert.ToInt32(model.Education).ToString())?.Value;
                model.PoliticalStatusName = GetData.PoliticalStatusList().SingleOrDefault(a => a.Key == Convert.ToInt32(model.PoliticalStatus).ToString())?.Value;
            }
            ReturnSummary returnSummary = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = code == 21 ? false : true,
                Data = model
            };
            return returnSummary;
        }
        /// <summary>
        /// 查询人员列表
        /// </summary>
        /// <param name="userQuery"></param>
        /// <returns></returns>
        public ReturnSummary GetUserList(UserQuery userQuery)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_UserBLL ideal_UserBLL = new Ideal_UserBLL();
            PageModel<Ideal_UserModel> modellist = new PageModel<Ideal_UserModel>();
            modellist = ideal_UserBLL.GetUserList(userQuery, out code, out msg);
            List<Ideal_UserModel> list = modellist.Data as List<Ideal_UserModel>;
            if (code == 20)
            {
                if (list.Count > 0)
                {
                    foreach (var model in list)
                    {
                        model.SexName = GetData.SexList().SingleOrDefault(a => a.Key == model.Sex)?.Value;
                        model.UserStatusName = GetData.UserStatusList().SingleOrDefault(a => a.Key == Convert.ToInt32(model.UserStatus).ToString())?.Value;
                        model.CheckTypeName = GetData.CheckTypeList().SingleOrDefault(a => a.Key == model.CheckType)?.Value;
                        model.IDCardTypeName = GetData.IDCardTypeList().SingleOrDefault(a => a.Key == Convert.ToInt32(model.IDCardType).ToString())?.Value;
                        model.EducationName = GetData.MyEducationDegreeList().SingleOrDefault(a => a.Key == Convert.ToInt32(model.Education).ToString())?.Value;
                        model.PoliticalStatusName = GetData.PoliticalStatusList().SingleOrDefault(a => a.Key == Convert.ToInt32(model.PoliticalStatus).ToString())?.Value;
                    }
                }

            }
            ReturnSummary returnSummary = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = code == 21 ? false : true,
                Data = modellist.Data,
                Total = modellist.Total
            };
            return returnSummary;
        }
        /// <summary>
        /// 查询所有人员
        /// </summary>
        /// <param name="userQuery"></param>
        /// <returns></returns>
        public ReturnSummary GetUserAllList(UserQuery userQuery)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_UserBLL ideal_UserBLL = new Ideal_UserBLL();
            List<Ideal_UserModel> modellist = new List<Ideal_UserModel>();
            modellist = ideal_UserBLL.GetUserAllList(userQuery, out code, out msg);
            if (code == 20)
            {
                if (modellist.Count > 0)
                {
                    foreach (var model in modellist)
                    {
                        model.SexName = GetData.SexList().SingleOrDefault(a => a.Key == model.Sex)?.Value;
                        model.UserStatusName = GetData.UserStatusList().SingleOrDefault(a => a.Key == Convert.ToInt32(model.UserStatus).ToString())?.Value;
                        model.CheckTypeName = GetData.CheckTypeList().SingleOrDefault(a => a.Key == model.CheckType)?.Value;
                        model.IDCardTypeName = GetData.IDCardTypeList().SingleOrDefault(a => a.Key == Convert.ToInt32(model.IDCardType).ToString())?.Value;
                        model.EducationName = GetData.MyEducationDegreeList().SingleOrDefault(a => a.Key == Convert.ToInt32(model.Education).ToString())?.Value;
                        model.PoliticalStatusName = GetData.PoliticalStatusList().SingleOrDefault(a => a.Key == Convert.ToInt32(model.PoliticalStatus).ToString())?.Value;
                    }
                }

            }
            ReturnSummary returnSummary = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = code == 21 ? false : true,
                Data = modellist
            };
            return returnSummary;
        }
        #endregion
    }
}
