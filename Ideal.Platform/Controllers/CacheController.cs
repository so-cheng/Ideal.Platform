using Ideal.Platform.Service;
using Microsoft.AspNetCore.Mvc;
using Ideal.Ideal.Model;
using Ideal.Ideal.Redis;
using Ideal.Platform.Common.Config;
using Ideal.Platform.Common.Data;
using System.Reflection;

namespace Ideal.Platform.Controllers
{
    public class CacheController : Controller
    {
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public JsonResult GetCache(string type)
        {
            List<KeyValue> keyValues = new List<KeyValue>();
            switch (type)
            {
                case "sex":
                    keyValues = GetData.SexList();
                    break;
                case "userStatus":
                    keyValues = GetData.UserStatusList();
                    break;
                case "accountStatus":
                    keyValues = GetData.AccountStatusList();
                    break;
                case "myEducationDegree":
                    keyValues = GetData.MyEducationDegreeList();
                    break;
                case "myNation":
                    keyValues = GetData.MyNationList();
                    break;
                case "politicalStatus":
                    keyValues = GetData.PoliticalStatusList();
                    break;
                case "iDCardType":
                    keyValues = GetData.IDCardTypeList();
                    break;
                case "checkType":
                    keyValues = GetData.CheckTypeList();
                    break;
                case "accountLevel":
                    keyValues = GetData.AccountLevelList();
                    break;
                case "yesOrNo":
                    keyValues = GetData.YesOrNoList();
                    break;
                case "stepType":
                    keyValues = GetData.StepTypeList();
                    break;
                case "setType":
                    keyValues = GetData.SetTypeList();
                    break;
                case "logType":
                    keyValues = GetData.LogTypeList();
                    break;
                default:
                    break;
            }
            ReturnSummary ReturnSummary = new ReturnSummary()
            {
                StatusCode = 20,
                Message = "查询成功",
                IsSuccess = true,
                Data = keyValues,
                Total = keyValues.Count
            };
            return Json(ReturnSummary);
        }
    }
}
