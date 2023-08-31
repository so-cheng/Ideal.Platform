using Ideal.Ideal.DB.Base;
using Ideal.Ideal.Redis;
using Ideal.Platform.Common.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Common.Config
{
    public static class ConfigClass
    {
        public static string SqlConnectionStr { get; set; }

        public static string RedisConnectionStr { get; set; }

        public static void Inti()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "", "appsettings.json");
            string appsettingsJsonstr = string.Empty;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("UTF-8")))
                {
                    appsettingsJsonstr = sr.ReadToEnd().ToString();
                }
            }
            JObject appsettingsJObject = JObject.Parse(appsettingsJsonstr);
            SqlConnectionStr = appsettingsJObject["SqlConnection"].ToString();
            RedisConnectionStr = appsettingsJObject["RedisConnection"].ToString();
            BaseControl.SetConnton(SqlConnectionStr); 
            RedisHelper.connection = RedisConnectionStr;
            SetRedis();
        }

        public static void SetRedis()
        {
            //性别
            List<KeyValue> keyValues = GetData.SexList();
            RedisHelper.SetValue((int)RedisType.Cache, "Sex", JsonConvert.SerializeObject(keyValues));
            //人员状态
            keyValues = GetData.UserStatusList();
            RedisHelper.SetValue((int)RedisType.Cache, "UserStatus", JsonConvert.SerializeObject(keyValues));
            //账号状态
            keyValues = GetData.AccountStatusList();
            RedisHelper.SetValue((int)RedisType.Cache, "AccountStatus", JsonConvert.SerializeObject(keyValues));
            //学历
            keyValues = GetData.MyEducationDegreeList();
            RedisHelper.SetValue((int)RedisType.Cache, "MyEducationDegree", JsonConvert.SerializeObject(keyValues));
            //名族
            keyValues = GetData.MyNationList();
            RedisHelper.SetValue((int)RedisType.Basics, "MyNation", JsonConvert.SerializeObject(keyValues));
            //政治面貌
            keyValues = GetData.PoliticalStatusList();
            RedisHelper.SetValue((int)RedisType.Cache, "PoliticalStatus", JsonConvert.SerializeObject(keyValues));
            //证件类型
            keyValues = GetData.IDCardTypeList();
            RedisHelper.SetValue((int)RedisType.Basics, "IDCardType", JsonConvert.SerializeObject(keyValues));
            //核算类型
            keyValues = GetData.CheckTypeList();
            RedisHelper.SetValue((int)RedisType.Cache, "CheckType", JsonConvert.SerializeObject(keyValues));
            //账号级别
            keyValues = GetData.AccountLevelList();
            RedisHelper.SetValue((int)RedisType.Cache, "AccountLevel", JsonConvert.SerializeObject(keyValues));
        }


    }
    public class KeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
