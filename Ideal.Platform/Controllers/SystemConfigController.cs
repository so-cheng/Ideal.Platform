using Ideal.Ideal.Model;
using Ideal.Platform.Authorization;
using Ideal.Platform.Model;
using Ideal.Platform.Service;
using Microsoft.AspNetCore.Mvc;

namespace Ideal.Platform.Controllers
{
    public class SystemConfigController : Controller
    {
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult UpdateSystemConfig(Ideal_SystemConfigModel model)
        {

            Ideal_SystemConfigService ideal_SystemConfigService = new Ideal_SystemConfigService();
            ReturnSummary returnSummary = ideal_SystemConfigService.UpdateSystemConfig(model);
            return Json(returnSummary);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        [NoAuthentiction]
        public JsonResult GetRoleDetailByID(string SystemConfigID)
        {
            Ideal_SystemConfigService ideal_SystemConfigService = new Ideal_SystemConfigService();
            ReturnSummary returnSummary = ideal_SystemConfigService.GetSystemConfigByID(SystemConfigID);
            return Json(returnSummary);
        }
    }
}
