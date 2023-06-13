using Ideal.Ideal.Model;
using Ideal.Ideal.Redis;
using Ideal.Platform.Common.Data;
using Ideal.Platform.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Ideal.Platform.Authorization
{
    public class ApiAuthoriz : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //if (context.Filters.Contains(new NoAuthentiction()))
            //{
            //    return;
            //}
            ////获取传输的Authorize
            //var authorize = context.HttpContext.Request.Headers["Authorize"];
            ////判断传输的Authorize是否为空

            //if (string.IsNullOrEmpty(authorize))
            //{
            //    ReturnSummary returnSummary = new ReturnSummary();
            //    returnSummary.StatusCode = 00;
            //    returnSummary.Message = "请求Authorize不能为空！";
            //    returnSummary.IsSuccess = false;
            //    context.Result = new JsonResult(returnSummary);
            //    return;
            //}
            //string redis = RedisHelper.GetValue((int)RedisType.Authorize, "Token");
            //List<TokenModel> tokens = JsonConvert.DeserializeObject<List<TokenModel>>(redis);
            //if (tokens.Where(a => a.Token != authorize).Count() == 0)
            //{
            //    ReturnSummary returnSummary = new ReturnSummary();
            //    returnSummary.StatusCode = 00;
            //    returnSummary.Message = "无效的Authorize授权信息，或者授权信息已过期";
            //    returnSummary.IsSuccess = false;
            //    context.Result = new JsonResult(returnSummary);
            //    context.Result = new JsonResult("无效的Authorize授权信息，或者授权信息已过期");
            //    return;
            //}

        }
    }
}
