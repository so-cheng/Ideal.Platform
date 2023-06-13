using Ideal.Ideal.DB;
using Ideal.Ideal.DB.Base;
using Ideal.Ideal.Log;
using Ideal.Ideal.Model;
using Ideal.Ideal.Redis;
using Ideal.Platform.BLL;
using Ideal.Platform.Common.Data;
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
    public class Ideal_MenuService
    {
        #region 增删改
        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary InsertMenu(Ideal_MenuModel model)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_MenuBLL ideal_MenuBLL = new Ideal_MenuBLL();
            flag = ideal_MenuBLL.InsertMenu(model, out code, out msg);
            if (flag)
            {
                RedisHelper.SetValue((int)RedisType.Menu, model.MenuID, JsonConvert.SerializeObject(model));
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
        /// 修改菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary UpdateMenu(Ideal_MenuModel model)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_MenuBLL ideal_MenuBLL = new Ideal_MenuBLL();
            flag = ideal_MenuBLL.UpdateMenu(model, out code, out msg);
            if (flag)
            {
                RedisHelper.UpdateValue((int)RedisType.Menu, model.MenuID, JsonConvert.SerializeObject(model));
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
        /// 删除菜单
        /// </summary>
        /// <param name="MenuID"></param>
        /// <returns></returns>
        public ReturnSummary DeleteMenu(string MenuID)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_MenuBLL ideal_MenuBLL = new Ideal_MenuBLL();
            flag = ideal_MenuBLL.DeleteMenu(MenuID, out code, out msg);
            if (flag)
            {
                RedisHelper.DeleteKey((int)RedisType.Menu, MenuID);
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
        /// 根据ID查询菜单
        /// </summary>
        /// <param name="MenuID"></param>
        /// <returns></returns>
        public ReturnSummary GetMenuDetailByID(string MenuID)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_MenuBLL ideal_MenuBLL = new Ideal_MenuBLL();
            Ideal_MenuModel model = new Ideal_MenuModel();
            model = ideal_MenuBLL.GetMenuDetailByID(MenuID, out code, out msg);
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
        /// 查询菜单 分页
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnSummary GetMenuList(MenuQuery query)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_MenuBLL ideal_MenuBLL = new Ideal_MenuBLL();
            PageModel<Ideal_MenuModel> model = new PageModel<Ideal_MenuModel>();
            model = ideal_MenuBLL.GetMenuList(query, out code, out msg);
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
        /// 查询全部菜单
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnSummary GetMenuAllList(MenuQuery query)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_MenuBLL ideal_MenuBLL = new Ideal_MenuBLL();
            List<Ideal_MenuModel> model = new List<Ideal_MenuModel>();
            model = ideal_MenuBLL.GetMenuAllList(query, out code, out msg);
            ReturnSummary returnSummary = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = code == 21 ? false : true,
                Data = model
            };
            return returnSummary;
        }
        #endregion
    }
}
