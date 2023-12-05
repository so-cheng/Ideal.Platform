using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Common.Config
{
    public class WeChatConfigClass
    {
        private static string _weChatToken = string.Empty;
        private static string _requestUrl = string.Empty;
        private static string _domain = string.Empty;
        private static string _encodingAESKey = string.Empty;
        private static string _appID = string.Empty;
        private static string _appSecret = string.Empty;

        /// <summary>
        /// 微信接入配置Token
        /// </summary>
        public static string WeChatToken
        {
            get
            {
                return _weChatToken;
            }
        }
        /// <summary>
        /// 请求网站域名
        /// </summary>
        public static string RequestUrl
        {
            get
            {
                return _requestUrl;
            }
        }
        /// <summary>
        /// 网站域名
        /// </summary>
        public static string Domain
        {
            get
            {
                return _domain;
            }
        }
        /// <summary>
        /// 微信消息体加密对应的EncodingAESKey
        /// </summary>
        public static string EncodingAESKey
        {
            get
            {
                return _encodingAESKey;
            }
        }
        /// <summary>
        /// 微信AppId
        /// </summary>
        public static string AppID
        {
            get
            {
                return _appID;
            }
        }
        /// <summary>
        /// 微信AppSecret
        /// </summary>
        public static string AppSecret
        {
            get
            {
                return _appSecret;
            }
        }


        /// <summary>
        /// 存储其它配置项
        /// </summary>
        public static Dictionary<string, object> DicConfig { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 微信调用接口AccessToken
        /// </summary>
        public static string AccessToken { get; set; }
        public static void InitConfig()
        {
            ReadAppsettings();
        }

        private static void ReadAppsettings()
        {
            string BaseDirectory = AppContext.BaseDirectory;
            string path = Path.Combine(BaseDirectory, "", "wechatsettings.json");
            string jsonstr = string.Empty;
            using (FileStream fs = new FileStream(path, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("UTF-8")))
                {
                    jsonstr = sr.ReadToEnd().ToString();
                }
            }
            JObject parsed = JObject.Parse(jsonstr);
            _weChatToken = parsed["WeChatToken"].ToString();
            _requestUrl = parsed["RequestUrl"].ToString();
            _domain = parsed["Domain"].ToString();
            _encodingAESKey = parsed["EncodingAESKey"].ToString();
            _appID = parsed["AppID"].ToString();
        }
    }
}
