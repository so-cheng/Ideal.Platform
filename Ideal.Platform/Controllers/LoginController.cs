using Ideal.Ideal.Model;
using Ideal.Platform.Service;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Login(string AccountName, string PassWord)
        {
            Ideal_AccountService ideal_AccountService = new Ideal_AccountService();
            ReturnSummary returnSummary = ideal_AccountService.Login(AccountName, PassWord);
            return Json(returnSummary);
        }
    }
}
