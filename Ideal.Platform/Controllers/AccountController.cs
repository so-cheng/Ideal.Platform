using Ideal.Ideal.Model;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using Ideal.Platform.Service;
using Microsoft.AspNetCore.Mvc;


namespace Ideal.Platform.Controllers
{
    public class AccountController : Controller
    {
        #region 增删改
        /// <summary>
        /// 新增账号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult InsertAccount(Ideal_AccountModel model)
        {
            Ideal_AccountService ideal_AccountService = new Ideal_AccountService();
            ReturnSummary returnSummary = ideal_AccountService.InsertAccount(model);
            return Json(returnSummary);
        }
        /// <summary>
        /// 修改账号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult UpdateAccount(Ideal_AccountModel model)
        {
            Ideal_AccountService ideal_AccountService = new Ideal_AccountService();
            ReturnSummary returnSummary = ideal_AccountService.UpdateAccount(model);
            return Json(returnSummary);
        }
        /// <summary>
        /// 删除账号
        /// </summary>
        /// <param name="AccountName"></param>
        /// <returns></returns>
        public JsonResult DeteleAccount(string AccountName)
        {
            Ideal_AccountService ideal_AccountService = new Ideal_AccountService();
            ReturnSummary returnSummary = ideal_AccountService.DeteleAccount(AccountName);
            return Json(returnSummary);
        }
        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="AccountName"></param>
        /// <returns></returns>
        public JsonResult ResetPassWord(string AccountName)
        {
            Ideal_AccountService ideal_AccountService = new Ideal_AccountService();
            ReturnSummary returnSummary = ideal_AccountService.ResetPassWord(AccountName);
            return Json(returnSummary);
        }
        
        #endregion

        #region 查询

        /// <summary>
        /// 查询账号详情
        /// </summary>
        /// <param name="AccountName"></param>
        /// <returns></returns>
        public JsonResult GetAccountDetailByName(string AccountName)
        {
            Ideal_AccountService ideal_AccountService = new Ideal_AccountService();
            ReturnSummary returnSummary = ideal_AccountService.GetAccountDetailByName(AccountName);
            return Json(returnSummary);
        }
        /// <summary>
        /// 查询账号分页
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult GetAccountList(AccountQuery query)
        {
            Ideal_AccountService ideal_AccountService = new Ideal_AccountService();
            ReturnSummary returnSummary = ideal_AccountService.GetAccountList(query);
            return Json(returnSummary);
        }
        /// <summary>
        /// 查询所有账号
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult GetAccountAllList(AccountQuery query)
        {
            Ideal_AccountService ideal_AccountService = new Ideal_AccountService();
            ReturnSummary returnSummary = ideal_AccountService.GetAccountAllList(query);
            return Json(returnSummary);
        }
        #endregion
    }
}
