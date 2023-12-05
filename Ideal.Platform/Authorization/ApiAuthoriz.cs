using Ideal.Ideal.Model;
using Ideal.Ideal.Redis;
using Ideal.Platform.Common.Data;
using Ideal.Platform.Model;
using Ideal.Platform.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Ideal.Platform.Authorization
{
    public class ApiAuthoriz : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.Filters.Contains(new NoAuthentiction()))
            {
                return;
            }
            Ideal_LogService ideal_LogService = new Ideal_LogService();
            Ideal_LogModel model = new Ideal_LogModel();
            model.Type = LogType.Warn;
            model.StatusCode = "500";
            model.IP = context.HttpContext.Connection.RemoteIpAddress.ToString();
            model.PostInterface = context.HttpContext.Request.Path;
            model.PostType = context.HttpContext.Request.Method.ToString();
            model.LogName = "接口请求";
            //获取传输的Authorize
            var authorize = context.HttpContext.Request.Headers["Authorize"];
            var UserID = context.HttpContext.Request.Headers["userID"];
            if (string.IsNullOrEmpty(UserID))
            {
                model.Creator = UserID;
            }
            //判断传输的Authorize是否为空
            if (string.IsNullOrEmpty(authorize))
            {
                ReturnSummary returnSummary = new ReturnSummary();
                returnSummary.StatusCode = 00;
                returnSummary.Message = "请求Authorize不能为空！";
                returnSummary.IsSuccess = false;
                model.Detail = returnSummary.Message;
                ideal_LogService.InsertLog(model);
                context.Result = new JsonResult(returnSummary);
                return;
            }
            string redis = RedisHelper.GetValue((int)RedisType.Authorize, UserID);
            if (string.IsNullOrEmpty(redis))
            {
                ReturnSummary returnSummary = new ReturnSummary();
                returnSummary.StatusCode = 00;
                returnSummary.Message = "非法访问！";
                returnSummary.IsSuccess = false;
                model.Detail = returnSummary.Message;
                ideal_LogService.InsertLog(model);
                context.Result = new JsonResult(returnSummary);
                return;
            }
            TokenModel tokens = JsonConvert.DeserializeObject<TokenModel>(redis);
            if (string.IsNullOrEmpty(redis) || tokens.Token != authorize)
            {
                ReturnSummary returnSummary = new ReturnSummary();
                returnSummary.StatusCode = 00;
                returnSummary.Message = "非法访问！";
                returnSummary.IsSuccess = false;
                model.Detail = returnSummary.Message;
                ideal_LogService.InsertLog(model);
                context.Result = new JsonResult(returnSummary);
                return;
            }
            TimeSpan timeDiff = DateTime.Now - tokens.StarTime;
            if (timeDiff.TotalMinutes > 40)
            {
                RedisHelper.DeleteKey((int)RedisType.Authorize, UserID);
                RedisHelper.DeleteKey((int)RedisType.Login, UserID);
                ReturnSummary returnSummary = new ReturnSummary();
                returnSummary.StatusCode = 00;
                returnSummary.Message = "登录过期!请重新登录。";
                returnSummary.IsSuccess = false;
                context.Result = new JsonResult(returnSummary);
                return;
            }
            
        }
    }
}
