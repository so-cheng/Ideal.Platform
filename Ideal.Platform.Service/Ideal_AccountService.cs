using Ideal.Ideal.DB;
using Ideal.Ideal.DB.Base;
using Ideal.Ideal.Log;
using Ideal.Ideal.Model;
using Ideal.Ideal.Redis;
using Ideal.Platform.BLL;
using Ideal.Platform.Common;
using Ideal.Platform.Common.Data;
using Ideal.Platform.Common.MD5;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Dynamic;
using System.Reflection;
using System.Text;
using System.Xml.Linq;


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
                Data = model.PageList,
                Total = model.Total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
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
            Password = MD5.Encrypt(Password);
            model = ideal_AccountBLL.GetAccountDetailByNameAndPassword(AccountName, Password, out code, out msg);
            if (model == null || string.IsNullOrEmpty(model.AccountName))
            {
                returnSummary.IsSuccess = false;
                returnSummary.Message = "用户名或密码错误！";
                returnSummary.StatusCode = 22;
                return returnSummary;
            }
            // 查询账号角色的菜单
            Ideal_RoleMenuBLL ideal_RoleMenuBLL = new Ideal_RoleMenuBLL();
            List<Ideal_RoleMenuModel> roleMenu = ideal_RoleMenuBLL.GetRoleMenuListByRoleID(model.RoleID, out int rcode, out msg);
            List<dynamic> roleMenus = GetMenuList(roleMenu);
            List<dynamic> returnMenu = GetWebMenuList(roleMenus);
            model.MenuList = returnMenu;
            //model.Permissions = new List<string>() { "list.add", "list.edit", "list.delete", "user.add", "user.edit", "user.delete" };
            //model.DashboardGrid = new List<string>() { "welcome", "ver", "time", "prokgress", "echarts", "about", };

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
            string redis = RedisHelper.GetValue((int)RedisType.Authorize, model.UserID);
            if (!string.IsNullOrEmpty(redis))
            {
                RedisHelper.DeleteKey((int)RedisType.Authorize, model.UserID);
            }
            //重新添加Token
            TokenModel tokenModel = new TokenModel();
            tokenModel.Token = TokenHelper.GetTokenValue(model.UserID);
            tokenModel.StarTime = DateTime.Now;
            tokenModel.UserID = model.UserID;
            RedisHelper.SetValue((int)RedisType.Authorize, model.UserID, JsonConvert.SerializeObject(tokenModel));
            model.Token = tokenModel.Token;
            returnSummary.IsSuccess = code == 20 ? true : false;
            returnSummary.Message = code == 20 ? "登录成功！" : "登录失败！";
            returnSummary.StatusCode = 20;
            returnSummary.Data = model;
            return returnSummary;
        }

        private List<object> GetMenuList(List<Ideal_RoleMenuModel> list)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (var item in list)
            {
                dynamic myObject = new ExpandoObject();
                myObject.id = item.MenuID;
                myObject.parentid = item.ParentMenuID;
                myObject.name = item.Name;
                myObject.icon = item.Icon;
                myObject.path = item.MenuURL;
                myObject.component = item.Component;
                myObject.meta = new
                {
                    title = item.MenuName,
                    icon = item.Icon,
                    type = "menu"
                };
                dynamics.Add(myObject);
            }
            return dynamics;
        }

        private List<dynamic> GetWebMenuList(List<dynamic> webs)
        {
            var list = webs.Where(a => string.IsNullOrEmpty(a.parentid)).ToList();
            foreach (var item in list)
            {
                AddChildMenu(item, webs);
            }
            return list;
        }
        private void AddChildMenu(dynamic webMenu, List<dynamic> webMenus)
        {
            List<dynamic> list = webMenus.Where(a => a.parentid == webMenu.id).ToList();
            if (list.Count > 0)
            {
                webMenu.children = list;
            }
            foreach (var item in list)
            {
                AddChildMenu(item, webMenus);
            }

        }
        #endregion
    }
}
