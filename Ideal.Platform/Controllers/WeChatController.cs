using Ideal.Ideal.Model;
using Ideal.Ideal.WeChat;
using Ideal.Platform.Authorization;
using Ideal.Platform.Common;
using Ideal.Platform.Common.Config;
using Microsoft.AspNetCore.Mvc;

namespace Ideal.Platform.Controllers
{
    public class WeChatController : Controller
    {
        [NoAuthentiction]
        public IActionResult Register(string signature, string timestamp, string nonce, string echostr)
        {
            if (!string.IsNullOrEmpty(signature))
            {
                //请求方式
                string Method = Request.HttpContext.Request.Method.ToUpper();
                //返回微信
                if (Method == "GET")
                {
                    return WeChatIndexGet(signature, timestamp, nonce, echostr);
                }
                else if (Method == "POST")
                {
                    return WeChatIndexPost(signature, timestamp, nonce, echostr);   
                }
            }
            //返回oa首页
            return View();
        }
        /// <summary>
        /// 微信接入get
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="echostr"></param>
        /// <returns></returns>
        [NoAuthentiction]
        private IActionResult WeChatIndexGet(string signature, string timestamp, string nonce, string echostr)
        {

            var token = WeChatConfigClass.WeChatToken;//微信公众平台后台设置的Token

            if (string.IsNullOrEmpty(token)) return Content("请先设置Token！");
            AuthModel model = new AuthModel();
            //封装参数
            model.Token = WeChatConfigClass.WeChatToken;//微信公众平台后台设置的Token
            model.Signature = signature;
            model.Timestamp = timestamp;
            model.Nonce = nonce;
            //声明实例
            OAuth auth = new OAuth(model);
            ReturnSummary returnSummary = auth.Auth();
            if (returnSummary.StatusCode != 10)
            {
                return Content(returnSummary.Message);
            }
            return Content(echostr); //返回随机字符串则表示验证通过
        }
        /// <summary>
        /// 微信接入POST
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="echostr"></param>
        /// <returns></returns>
        [NoAuthentiction]
        private ActionResult WeChatIndexPost(string signature, string timestamp, string nonce, string echostr)
        {
            //WeixinMessage wxMessage = new WeixinMessage();
            //AuthModel model = new AuthModel();
            //string body = "";
            //using (var streamReader = new StreamReader(HttpContext.Request.Body))
            //{
            //    body = streamReader.ReadToEnd();
            //}
            //var msg_signature = HttpContext.Request.Query["msg_signature"];
            ReturnSummary returnSummary = null;
            ////封装参数
            //model.Token = WeChatConfigClass.WeChatToken;//微信公众平台后台设置的Token
            //model.Signature = signature;
            //model.Timestamp = timestamp;
            //model.Nonce = nonce;
            //model.BodyMsg = body;
            //model.Encrypt_type = HttpContext.Request.Query["encrypt_type"].ToString() == "aes";
            //model.Msg_signature = msg_signature.ToString();
            //var http = HttpContext;
            ////声明实例
            //OAuth auth = new OAuth(model);
            //returnSummary = auth.GetWeixinMessage();

            //if (returnSummary.StatusCode == 10)
            //{
            //    wxMessage = returnSummary.Data as WeixinMessage;
            //    var openId = wxMessage.Body.FromUserName.Value;
            //    switch (wxMessage.Type)
            //    {
            //        case WeixinMessageType.Event:
            //            string eventType = wxMessage.Body.Event.Value.ToLower();
            //            string eventKey = string.Empty;
            //            try
            //            {
            //                eventKey = wxMessage.Body.EventKey.Value;
            //            }
            //            catch { }
            //            switch (eventType)
            //            {

            //                case "subscribe":
            //                    string Touser = openId;
            //                    string Access_token = WeChatConfigClass.GetToken();
            //                    string Content = "你有一条新信息";
            //                    string Kf_account = "";
            //                    //声明实例
            //                    Message ms = new Message();
            //                    returnSummary = ms.RepayText(Access_token, Touser, Content, Kf_account);
            //                    break;

            //                default:
            //                    break;
            //            }
            //            break;

            //        default:

            //            break;
            //    }
            //}

            return new ContentResult
            {
                Content = returnSummary.Message,
                ContentType = "text/xml;charset=utf-8"
            };
        }
        [NoAuthentiction]
        public void AcceptWeChatToAppHome()
        {
            var domain = WeChatConfigClass.Domain;
            var page = "";
            //通过page读取RouteViews中的页面路由
            var redirect_uri = domain + "/WeChat/AppHome";//这里需要完整url地址，对应Controller里面的OAuthController的Callback
            var scope = "snsapi_userinfo";
            var state = Math.Abs(DateTime.Now.ToBinary()).ToString();//state保证唯一即可,可以用其他方式生成
            var weixinOAuth2Url = string.Format(
                     "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope={2}&state={3}#wechat_redirect",
                      WeChatConfigClass.AppID, redirect_uri, scope, state);
            Response.Redirect(weixinOAuth2Url);
        }
        /// <summary>
        /// 通过code获取openid，跳转login页面
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [NoAuthentiction]
        public IActionResult AppHome(string code)
        {
            string openid = string.Empty;
            string resStr = string.Empty;
            //验证是微信请求
            if (string.IsNullOrEmpty(code))
            {
                return Content("非法访问!");
            }

            //验证code是否可用
            string sessionCode = WebCommon.GetSession(HttpContext, "code");
            //接收的code和Session就重定向
            if (code == sessionCode)
            {
                WebCommon.RemoveSession(HttpContext, "code");
                return Redirect("/WeChat/AcceptWeChatToAppHome");
            }
            //如果code不为空获取code存入Session
            WebCommon.SetSession(HttpContext, "code", code);
            //获取用户openid
            string openIDJson = OAuth2API.GetOpenIDAndToken(code, WeChatConfigClass.AppID, WeChatConfigClass.AppSecret);
            if (!string.IsNullOrEmpty(openIDJson))
            {
                //吧openID存入Session
                string openID = SailJsonExtention.GetJsonValueByKey(openIDJson, "openId");
                string access_token = SailJsonExtention.GetJsonValueByKey(openIDJson, "access_token");
                WebCommon.SetSession(HttpContext, "openId", openID);
                openid = openID;
            }
            //调用是否使用P7登录

            return Redirect("/Login");

        }
    }
}
