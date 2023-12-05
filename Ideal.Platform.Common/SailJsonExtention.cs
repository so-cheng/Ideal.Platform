using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Common
{
    public class SailJsonExtention
    {

        /// <summary>
        /// 获取json字符串中指定key的值
        /// </summary>
        /// <param name="jsonStr">json字符串</param>
        /// <param name="key">json中的key</param>
        /// <returns>key对应的字符串</returns>
        public static string GetJsonValueByKey(string jsonStr, string key)
        {
            string rs = string.Empty;
            JObject jObj = JObject.Parse(jsonStr);
            if (jObj.ContainsKey(key))
            {
                JToken jtoken = jObj[key];
                rs = jtoken.ToString();
            }
            return rs;
        }


        /// <summary>
        /// 获取json字符串中的第一个值
        /// </summary>
        /// <param name="jsonStr">json字符串</param>
        /// <returns>json字符串第一个值</returns>
        public static string GetJsonValueByKeyFirst(string jsonStr)
        {
            string rs = string.Empty;
            if (string.IsNullOrEmpty(jsonStr))
                return rs;
            JObject jObj = JObject.Parse(jsonStr);
            if (jObj != null)
            {
                //取出第一个KEY的值
                rs = jObj.First.First.ToString();
            }
            return rs;
        }
        /// <summary>添加一个属性
        /// 
        /// </summary>
        /// <param name="obj">待添加属性的对象</param>
        /// <param name="key">键名</param>
        /// <param name="value">值</param>
        /// <returns>添加属性后的对象</returns>
        public static string AddKeyAndValueToJsonString(string jsonStr, string key, string value)
        {
            JObject jObj = JObject.Parse(jsonStr);
            jObj.Add(key, value);
            return jObj.ToString();
        }
        /// <summary>
        /// 设置json字符串中的第一个值
        /// </summary>
        /// <param name="value">json字符串</param>
        /// <returns>json字符串第一个值</returns>
        public static string SetValueToJsonString(string value)
        {
            string rs = string.Empty;
            rs = "{data:" + value + "}";
            return rs;
        }
        /// <summary>
        /// 判断是否为JSON格式的字符串
        /// </summary>
        /// <param name="jsonStr">json字符串</param>
        /// <returns>key对应的字符串</returns>
        public static bool IsJsonStr(string jsonStr)
        {
            bool suc = false;
            try
            {
                JObject jObj = JObject.Parse(jsonStr);
                suc = true;
            }
            catch (Exception e)
            {


            }
            return suc;
        }

    }
}
