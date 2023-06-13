using Ideal.Ideal.Model;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using Ideal.Platform.Service;
using Microsoft.AspNetCore.Mvc;

namespace Ideal.Platform.Controllers
{
    public class UserController : Controller
    {
        #region 增删改
        /// <summary>
        /// 新增人员
        /// </summary>
        /// <param name="userModel"></param>
        /// <param name="postModel"></param>
        /// <returns></returns>
        public JsonResult InsertUser(Ideal_UserModel userModel, Ideal_UserPostModel postModel)
        {
            Ideal_UserService ideal_UserService = new Ideal_UserService();
            ReturnSummary returnSummary = ideal_UserService.InsertUser(userModel, postModel);
            return Json(returnSummary);
        }
        /// <summary>
        /// 修改人员
        /// </summary>
        /// <param name="userModel"></param>
        /// <param name="postModel"></param>
        /// <returns></returns>
        public JsonResult UpdateUser(Ideal_UserModel userModel, Ideal_UserPostModel postModel)
        {
            Ideal_UserService ideal_UserService = new Ideal_UserService();
            ReturnSummary returnSummary = ideal_UserService.UpdateUser(userModel, postModel);
            return Json(returnSummary);
        }
        /// <summary>
        /// 删除人员
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public JsonResult DeteleUser(string UserID)
        {
            Ideal_UserService ideal_UserService = new Ideal_UserService();
            ReturnSummary returnSummary = ideal_UserService.DeteleUser(UserID);
            return Json(returnSummary);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询人员详情
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public JsonResult GetUserDetailByUserID(string UserID)
        {
            Ideal_UserService ideal_UserService = new Ideal_UserService();
            ReturnSummary returnSummary = ideal_UserService.GetUserDetailByUserID(UserID);
            return Json(returnSummary);
        }
        /// <summary>
        /// 人员分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult GetUserList(UserQuery query)
        {
            Ideal_UserService ideal_UserService = new Ideal_UserService();
            ReturnSummary returnSummary = ideal_UserService.GetUserList(query);
            return Json(returnSummary);
        }
        /// <summary>
        /// 所有人员
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult GetUserAllList(UserQuery query)
        {
            Ideal_UserService ideal_UserService = new Ideal_UserService();
            ReturnSummary returnSummary = ideal_UserService.GetUserAllList(query);
            return Json(returnSummary);
        }
        #endregion
    }
}
