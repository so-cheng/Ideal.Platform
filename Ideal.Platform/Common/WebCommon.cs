using Ideal.Platform.Common.Config;

namespace Ideal.Platform.Common
{
    public class WebCommon
    {
        public static string GetSession(HttpContext httpContext, string key)
        {
            string res = string.Empty;
            res = httpContext.Session.GetString(key);
            return res;
        }

        public static void SetSession(HttpContext httpContext, string key, string Value)
        {
            httpContext.Session.SetString(key, Value);
        }

        public static void RemoveSession(HttpContext httpContext, string key)
        {
            httpContext.Session.Remove(key);
        }
    }
}
