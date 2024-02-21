using Ideal.Ideal.Model;
using Ideal.Ideal.Redis;
using Ideal.Ideal.WeChat;
using Ideal.Platform.Common;
using Ideal.Platform.Common.Config;
using Ideal.Platform.Common.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XAct.Users;

namespace Ideal.Platform.BLL
{
    public class Ideal_WechatBLL
    {
        #region Token
        /// <summary>
        /// 获取微信token
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public string GetAccessToken(out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            string token = string.Empty;
            AuthModel authModel = new AuthModel();
            WeChatToken weChatToken = new WeChatToken();
            authModel.AppID = WeChatConfigClass.AppID;
            authModel.AppSecret = WeChatConfigClass.AppSecret;
            //判断Token是否过期
            string redisToken = RedisHelper.GetValue((int)RedisType.WeChatToken, WeChatConfigClass.AppID);
            if (string.IsNullOrEmpty(redisToken))
            {
                string time = SailJsonExtention.GetJsonValueByKey(redisToken, "time");
                if (Convert.ToDateTime(time) < DateTime.Now)
                {
                    ReturnSummary returnSummary = weChatToken.GetAccessToken();
                    if (returnSummary.StatusCode == 10)
                    {
                        dynamic res = returnSummary.Data;
                        token = res.access_token;
                        var tk = new
                        {
                            token = res.access_token,
                            time = DateTime.Now.AddHours(1.5).ToString(),
                        };
                        RedisHelper.DeleteKey((int)RedisType.WeChatToken, WeChatConfigClass.AppID);
                        RedisHelper.SetValue((int)RedisType.WeChatToken, WeChatConfigClass.AppID, JsonConvert.SerializeObject(tk));
                    }
                }
                else
                {
                    return SailJsonExtention.GetJsonValueByKey(redisToken, "token");
                }
            }
            else
            {
                ReturnSummary returnSummary = weChatToken.GetAccessToken();
                if (returnSummary.StatusCode == 10)
                {
                    dynamic res = returnSummary.Data;
                    token = res.access_token;
                    var tk = new
                    {
                        token = res.access_token,
                        time = DateTime.Now.AddHours(1.5).ToString(),
                    };
                    RedisHelper.DeleteKey((int)RedisType.WeChatToken, WeChatConfigClass.AppID);
                    RedisHelper.SetValue((int)RedisType.WeChatToken, WeChatConfigClass.AppID, JsonConvert.SerializeObject(tk));
                }
            }
            return token;
        }
        #endregion

    }
}
