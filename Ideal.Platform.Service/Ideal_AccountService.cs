using Ideal.Ideal.DB;
using Ideal.Ideal.DB.Base;
using Ideal.Ideal.Log;
using Ideal.Ideal.Model;
using Ideal.Ideal.Redis;
using Ideal.Platform.BLL;
using Ideal.Platform.Common.Data;
using Ideal.Platform.Common.MD5;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using Newtonsoft.Json;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;


namespace Ideal.Platform.Service
{
    public class Ideal_AccountService
    {
        #region 增删改
        /// <summary>
        /// 新增账号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary InsertAccount(Ideal_AccountModel model)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_AccountBLL ideal_AccountBLL = new Ideal_AccountBLL();
            flag = ideal_AccountBLL.InsertAccount(model, out code, out msg);
            if (flag)
            {
                RedisHelper.SetValue((int)RedisType.Account, model.AccountName, JsonConvert.SerializeObject(model));
            }
            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }
        /// <summary>
        /// 修改账号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary UpdateAccount(Ideal_AccountModel model)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_AccountBLL ideal_AccountBLL = new Ideal_AccountBLL();
            flag = ideal_AccountBLL.UpdateAccount(model, out code, out msg);
            if (flag)
            {
                RedisHelper.UpdateValue((int)RedisType.Account, model.AccountName, JsonConvert.SerializeObject(model));
            }
            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }
        /// <summary>
        /// 删除账号
        /// </summary>
        /// <param name="AccountName"></param>
        /// <returns></returns>
        public ReturnSummary DeteleAccount(string AccountName)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_AccountBLL ideal_AccountBLL = new Ideal_AccountBLL();
            flag = ideal_AccountBLL.DeteleAccount(AccountName, out code, out msg);
            if (flag)
            {
                RedisHelper.DeleteKey((int)RedisType.Account, AccountName);
            }
            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询账号详情
        /// </summary>
        /// <param name="AccountName"></param>
        /// <returns></returns>
        public ReturnSummary GetAccountDetailByName(string AccountName)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_AccountBLL ideal_AccountBLL = new Ideal_AccountBLL();
            Ideal_AccountModel model = new Ideal_AccountModel();
            model = ideal_AccountBLL.GetAccountDetailByName(AccountName, out code, out msg);
            ReturnSummary returnSummary = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = code == 21 ? false : true,
                Data = model
            };
            return returnSummary;
        }
        /// <summary>
        /// 获取账号分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnSummary GetAccountList(AccountQuery query)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_AccountBLL ideal_AccountBLL = new Ideal_AccountBLL();
            PageModel<Ideal_AccountModel> model = new PageModel<Ideal_AccountModel>();
            model = ideal_AccountBLL.GetAccountList(query, out code, out msg);
            ReturnSummary returnSummary = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = code == 21 ? false : true,
                Data = model.Data,
                Total = model.Total
            };
            return returnSummary;
        }
        /// <summary>
        /// 查询所有账号
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnSummary GetAccountAllList(AccountQuery query)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_AccountBLL ideal_AccountBLL = new Ideal_AccountBLL();
            List<Ideal_AccountModel> model = new List<Ideal_AccountModel>();
            model = ideal_AccountBLL.GetAccountAllList(query, out code, out msg);
            ReturnSummary returnSummary = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = code == 21 ? false : true,
                Data = model
            };
            return returnSummary;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="AccountName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public ReturnSummary Login(string AccountName, string Password)
        {
            int code = 21;
            string msg = string.Empty;
            ReturnSummary returnSummary = new ReturnSummary();
            //验证账号密码
            Ideal_AccountBLL ideal_AccountBLL = new Ideal_AccountBLL();
            Ideal_AccountModel model = new Ideal_AccountModel();
            model = ideal_AccountBLL.GetAccountDetailByNameAndPassword(AccountName, Password, out code, out msg);
            if (model == null && string.IsNullOrEmpty(model.AccountName))
            {
                returnSummary.IsSuccess = false;
                returnSummary.Message = "用户名或密码错误！";
                returnSummary.StatusCode = 22;
                return returnSummary;
            }
            // 查询账号角色的菜单
            Ideal_RoleMenuBLL ideal_RoleMenuBLL = new Ideal_RoleMenuBLL();
            List<Ideal_RoleMenuModel> roleMenu = ideal_RoleMenuBLL.GetRoleMenuListByRoleID(model.RoleID, out code, out msg);
            model.MenuList = roleMenu;
            //登录信息存入Redis

            //判断是否登录
            string user = RedisHelper.GetValue((int)RedisType.Login, model.UserID);
            //存在登录就删除之前缓存
            if (!string.IsNullOrEmpty(user))
            {
                RedisHelper.DeleteKey((int)RedisType.Login, model.UserID);
            }
            //重新把登录缓存加入
            RedisHelper.SetValue((int)RedisType.Login, model.UserID, JsonConvert.SerializeObject(model));
            //查询Redis所有Token
            string redis = RedisHelper.GetValue((int)RedisType.Authorize, "Token");
            List<TokenModel> tokens = JsonConvert.DeserializeObject<List<TokenModel>>(redis);
            //找出当前登录人的Token删除
            foreach (var item in tokens)
            {
                string token = DecryptToken(item.Token);
                Ideal_UserModel ideal_UserModel = JsonConvert.DeserializeObject<Ideal_UserModel>(token);
                if (ideal_UserModel.UserID == model.UserID)
                {
                    tokens.Remove(item);
                    break;
                }
            }
            //重新添加Token
            TokenModel tokenModel = new TokenModel();
            tokenModel.Token = GetTokenValue(model);
            tokenModel.StarTime = DateTime.Now;
            tokens.Add(tokenModel);
            RedisHelper.UpdateValue((int)RedisType.Authorize, "Token", JsonConvert.SerializeObject(tokens));
            returnSummary.IsSuccess = code == 20 ? true : false;
            returnSummary.Message = code == 20 ? "登录成功！" : "登录失败！";
            returnSummary.StatusCode = 20;
            returnSummary.Data = model;
            return returnSummary;
        }
        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetTokenValue(Ideal_AccountModel model)
        {
            string token = string.Empty;
            string usermodel = JsonConvert.SerializeObject(model);
            int day = DateTime.Now.Day;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            token = day.ToString("dd") + usermodel + hour.ToString("HH") + minute.ToString("mm");
            MD5.Encrypt(token);
            return token;
        }
        private string DecryptToken(string Token)
        {
            string key = string.Empty;
            string encryptToken = MD5.Decrypt(Token);
            encryptToken = encryptToken.Substring(2, encryptToken.Length - 2);
            encryptToken = encryptToken.Substring(2, encryptToken.Length - 4);

            return encryptToken;
        }
        #endregion
    }
}
