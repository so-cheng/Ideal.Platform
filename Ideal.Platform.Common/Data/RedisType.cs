using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Common.Data
{
    public enum RedisType
    {
        Authorize = 0,//授权
        Login =1,//登录
        Basics =2,//基础数据
        Cache =3,//缓存字典
        WeChatToken =4,//微信AccessToken
    }
}
