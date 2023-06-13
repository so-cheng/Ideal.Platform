using Ideal.Ideal.Model;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using Ideal.Platform.Service;
using Microsoft.AspNetCore.Mvc;

namespace Ideal.Platform.Controllers
{
    public class PostController : Controller
    {
        #region 增删改
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult InsertPost(Ideal_PostModel model)
        {
            Ideal_PostService ideal_PostService = new Ideal_PostService();
            ReturnSummary returnSummary = ideal_PostService.InsertPost(model);
            return Json(returnSummary);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult UpdatePost(Ideal_PostModel model)
        {
            Ideal_PostService ideal_PostService = new Ideal_PostService();
            ReturnSummary returnSummary = ideal_PostService.UpdatePost(model);
            return Json(returnSummary);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="PostID"></param>
        /// <returns></returns>
        public JsonResult DeletePost(string PostID)
        {
            Ideal_PostService ideal_PostService = new Ideal_PostService();
            ReturnSummary returnSummary = ideal_PostService.DeletePost(PostID);
            return Json(returnSummary);
        }

        #endregion


        #region 查询
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="PostID"></param>
        /// <returns></returns>
        public JsonResult GetPostDetailByID(string PostID)
        {
            Ideal_PostService ideal_PostService = new Ideal_PostService();
            ReturnSummary returnSummary = ideal_PostService.GetPostDetailByID(PostID);
            return Json(returnSummary);
        }
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult GetPostList(PostQuery query)
        {
            Ideal_PostService ideal_PostService = new Ideal_PostService();
            ReturnSummary returnSummary = ideal_PostService.GetPostList(query);
            return Json(returnSummary);
        }
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult GetPostAllList(PostQuery query)
        {
            Ideal_PostService ideal_PostService = new Ideal_PostService();
            ReturnSummary returnSummary = ideal_PostService.GetPostAllList(query);
            return Json(returnSummary);
        }
        #endregion
    }
}
