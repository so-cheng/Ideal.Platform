using Ideal.Ideal.Model;
using Ideal.Platform.Authorization;
using Ideal.Platform.Common.Data;
using Ideal.Platform.Model;
using Ideal.Platform.Service;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Ideal.Platform.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="AccountName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        [NoAuthentiction]
        public IActionResult Login(string AccountName, string PassWord)
        {
            Ideal_AccountService ideal_AccountService = new Ideal_AccountService();
            ReturnSummary returnSummary = ideal_AccountService.Login(AccountName, PassWord);

            Ideal_LogService ideal_LogService = new Ideal_LogService();
            Ideal_LogModel model = new Ideal_LogModel();
            model.Type = LogType.Login;
            model.StatusCode = returnSummary.StatusCode.ToString();
            model.IP = HttpContext.Connection.RemoteIpAddress.ToString();
            model.PostInterface = Request.Path;
            model.PostType = Request.Method.ToString();
            model.LogName = "系统登录";
            model.Detail = returnSummary.Message;
            if (returnSummary.StatusCode == 20)
            {
                Ideal_AccountModel user = returnSummary.Data as Ideal_AccountModel;
                model.Creator = user.UserID;
            }
            ideal_LogService.InsertLog(model);
            return Json(returnSummary);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
