using Ideal.Ideal.Redis;
using Ideal.Platform.Common;
using Ideal.Platform.Common.Data;
using Ideal.Platform.Common.MD5;
using Ideal.Platform.Model;
using Newtonsoft.Json;

namespace Ideal.Platform.Job
{
    public static class TimerJob
    {
        public static System.Threading.Timer timer;
        public static void StarJob()
        {
            timer = new System.Threading.Timer(RemoveToken, null, TimeSpan.FromMinutes(0), TimeSpan.FromMinutes(1));
        }
        private static void RemoveToken(object sender)
        {
            string redis = RedisHelper.GetValue((int)RedisType.Authorize, "Token");
            List<TokenModel> tokens = JsonConvert.DeserializeObject<List<TokenModel>>(redis);
            foreach (var item in tokens)
            {
                string token = TokenHelper.DecryptToken(item.Token);
                TokenModel model = tokens.SingleOrDefault(a => a.Token == token);
                string day = token.Substring(0, 2);
                string hour = token.Substring(token.Length - 4, 2);
                string minute = token.Substring(token.Length - 2, 2);
                string time = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + day + " " + hour + ":" + minute;
                TimeSpan timeSpan = DateTime.Now.Subtract(Convert.ToDateTime(time));
                if (timeSpan.Minutes > 30)
                {
                    tokens.Remove(item);
                }
            }
        }
    }
}
