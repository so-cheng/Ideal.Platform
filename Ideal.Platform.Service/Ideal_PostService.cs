using Ideal.Ideal.Model;
using Ideal.Ideal.Redis;
using Ideal.Platform.BLL;
using Ideal.Platform.Common.Data;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Service
{
    public class Ideal_PostService
    {
        #region 增删改
        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary InsertPost(Ideal_PostModel model)
        {
            int code = 11;
            string msg = string.Empty;
            bool flag = false;
            ReturnSummary returnSummary = new ReturnSummary();
            Ideal_PostBLL bll = new Ideal_PostBLL();
            flag = bll.InserPost(model, out code, out msg);
            if (flag)
            {
                RedisHelper.SetValue((int)RedisType.Post, model.PostID, JsonConvert.SerializeObject(model));
            }
            returnSummary.StatusCode = code;
            returnSummary.IsSuccess = flag;
            returnSummary.Message = msg;
            return returnSummary;
        }
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary UpdatePost(Ideal_PostModel model)
        {
            int code = 11;
            string msg = String.Empty;
            bool flag = false;
            ReturnSummary returnSummary = new ReturnSummary();
            Ideal_PostBLL bll = new Ideal_PostBLL();
            flag = bll.UpdatePost(model, out code, out msg);
            if (flag)
            {
                RedisHelper.UpdateValue((int)RedisType.Post, model.PostID, JsonConvert.SerializeObject(model));
            }
            returnSummary.StatusCode = code;
            returnSummary.IsSuccess = flag;
            returnSummary.Message = msg;
            return returnSummary;
        }
        /// <summary>
        /// 删除岗位
        /// </summary>
        /// <param name="PostID"></param>
        /// <returns></returns>
        public ReturnSummary DeletePost(string PostID)
        {
            int code = 11;
            string msg = String.Empty;
            bool flag = false;
            ReturnSummary returnSummary = new ReturnSummary();
            Ideal_PostBLL bll = new Ideal_PostBLL();
            flag = bll.DeletePost(PostID, out code, out msg);
            if (flag)
            {
                RedisHelper.DeleteKey((int)RedisType.Post, PostID);
            }
            returnSummary.StatusCode = code;
            returnSummary.IsSuccess = flag;
            returnSummary.Message = msg;
            return returnSummary;
        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询岗位详情
        /// </summary>
        /// <param name="PostID"></param>
        /// <returns></returns>
        public ReturnSummary GetPostDetailByID(string PostID)
        {
            ReturnSummary returnSummary = new ReturnSummary();
            int code = 21;
            string msg = string.Empty;
            Ideal_PostBLL bll = new Ideal_PostBLL();
            Ideal_PostModel model = new Ideal_PostModel();
            model = bll.GetPostDetailByID(PostID, out code, out msg);
            returnSummary.IsSuccess = code == 20 ? true : false;
            returnSummary.Message = msg;
            returnSummary.StatusCode = code;
            returnSummary.Data = model;
            return returnSummary;
        }
        /// <summary>
        /// 查询岗位列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnSummary GetPostList(PostQuery query)
        {
            ReturnSummary returnSummary = new ReturnSummary();
            int code = 21;
            string msg = string.Empty;
            Ideal_PostBLL bll = new Ideal_PostBLL();
            PageModel<Ideal_PostModel> model = new PageModel<Ideal_PostModel>();
            model = bll.GetPostList(query, out code, out msg);
            returnSummary.IsSuccess = code == 20 ? true : false;
            returnSummary.Message = msg;
            returnSummary.StatusCode = code;
            returnSummary.Data = model.Data;
            returnSummary.Total = model.Total;
            return returnSummary;
        }
        /// <summary>
        /// 获取所有的岗位
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnSummary GetPostAllList(PostQuery query)
        {
            ReturnSummary returnSummary = new ReturnSummary();
            int code = 21;
            string msg = string.Empty;
            Ideal_PostBLL bll = new Ideal_PostBLL();
            List<Ideal_PostModel> model = new List<Ideal_PostModel>();
            model = bll.GetPostAllList(query, out code, out msg);
            returnSummary.IsSuccess = code == 20 ? true : false;
            returnSummary.Message = msg;
            returnSummary.StatusCode = code;
            returnSummary.Data = model;
            return returnSummary;
        }
        #endregion
    }
}
