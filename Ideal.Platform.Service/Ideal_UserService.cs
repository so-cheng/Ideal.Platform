using Ideal.Ideal.DB;
using Ideal.Ideal.DB.Base;
using Ideal.Ideal.Log;
using Ideal.Ideal.Model;
using Ideal.Ideal.Redis;
using Ideal.Platform.BLL;
using Ideal.Platform.Common.Data;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
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
        public ReturnSummary InsertUser(Ideal_UserModel model)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_UserBLL ideal_UserBLL = new Ideal_UserBLL();
            flag = ideal_UserBLL.InsertUser(model, out code, out msg);

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
        public ReturnSummary UpdateUser(Ideal_UserModel model)
        {

            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_UserBLL ideal_UserBLL = new Ideal_UserBLL();
            flag = ideal_UserBLL.UpdateUser(model, out code, out msg);

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
            if (!string.IsNullOrEmpty(userQuery.DeptID))
            {
                userQuery.DeptID = GetDeptIDs(userQuery.DeptID);
            }
            modellist = ideal_UserBLL.GetUserList(userQuery, out code, out msg);
            List<Ideal_UserModel> list = modellist.PageList;
            if (code == 20)
            {
                if (list.Count > 0)
                {
                    foreach (var model in list)
                    {
                        model.SexName = GetData.SexList().SingleOrDefault(a => a.Key == model.Sex)?.Value;
                        model.UserStatusName = GetData.UserStatusList().SingleOrDefault(a => a.Key == model.UserStatus)?.Value;
                        model.CheckTypeName = GetData.CheckTypeList().SingleOrDefault(a => a.Key == model.CheckType)?.Value;
                        model.IDCardTypeName = GetData.IDCardTypeList().SingleOrDefault(a => a.Key == model.IDCardType)?.Value;
                        model.EducationName = GetData.MyEducationDegreeList().SingleOrDefault(a => a.Key == model.Education)?.Value;
                        model.PoliticalStatusName = GetData.PoliticalStatusList().SingleOrDefault(a => a.Key == model.PoliticalStatus)?.Value;
                        model.AccountStatusName = GetData.AccountStatusList().SingleOrDefault(a => a.Key == model.AccountStatus)?.Value;
                        model.Birthday = !string.IsNullOrEmpty(model.Birthday) ? Convert.ToDateTime(model.Birthday).ToString("yyyy-MM-dd") : "";
                    }
                }

            }
            ReturnSummary returnSummary = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = code == 21 ? false : true,
                Data = modellist.PageList,
                Total = modellist.Total,
                PageIndex = modellist.PageIndex,
                PageSize = modellist.PageSize
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

        #region 私有方法

        private string GetDeptIDs(string DeptID)
        {
            List<string> strList = new List<string>();
            string deptIDs = string.Empty;
            Ideal_DeptBLL bll = new Ideal_DeptBLL();
            List<Ideal_DeptModel> alldeptList = bll.GetDeptAllList(new DeptQuery(), out int code, out string msg);
            List<Ideal_DeptModel> list = new List<Ideal_DeptModel>();
            //list = alldeptList.Where(a => a.ParentDeptID == DeptID).ToList();
            foreach (var data in alldeptList.Where(a => a.ParentDeptID == DeptID).ToList())
            {
                list.Add(data);
                GetDeptIDs(alldeptList, data, list);
            }

            if (list.Count > 0)
            {
                foreach (var data in list)
                {
                    strList.Add("'" + data.DeptID + "'");
                }
                deptIDs = string.Join(",", strList);
            }
            else
            {
                return DeptID;
            }
            return deptIDs;
        }

        private void GetDeptIDs(List<Ideal_DeptModel> alldeptList, Ideal_DeptModel deptID, List<Ideal_DeptModel> deptList)
        {

            deptList.Add(deptID);
            List<Ideal_DeptModel> dlist = alldeptList.Where(a => a.ParentDeptID == deptID.DeptID).ToList();
            if (dlist.Count > 0)
            {
                foreach (var data in dlist)
                {
                    GetDeptIDs(alldeptList, data, deptList);
                }
            }
        }

        #endregion
    }
}
