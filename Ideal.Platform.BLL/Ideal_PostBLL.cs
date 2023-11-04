using Ideal.Ideal.DB.Base;
using Ideal.Ideal.Model;
using Ideal.Platform.Common.Snowflake;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.BLL
{
    public class Ideal_PostBLL
    {
        #region 增删改
        /// <summary>
        /// 新增岗位
        /// </summary>
        /// <param name="model"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool InserPost(Ideal_PostModel model, out int code, out string msg)
        {
            code = 11;
            msg = "添加失败！";
            bool flag = false;
            model.PostID = SnowFlakeUse.GetSnowflakeID();
            Ideal_PostModel ideal_Post = GetPostDetailByCode(model.PostCode, out code, out msg);
            if (code == 20)
            {
                code = 11;
                msg = "部门编号重复！";
                return false;
            }
            ideal_Post = GetPostDetailByDeptIDAndName(model.PostName, model.DeptID, out code, out msg);
            if (code != 20)
            {
                code = 11;
                msg = "同一部门下岗位名称不能相同！";
                return false;
            }
            flag = BaseControl.InsertDB<Ideal_PostModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "新增成功！" : "新增失败！";
            return flag;
        }
        /// <summary>
        /// 修改岗位
        /// </summary>
        /// <param name="model"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdatePost(Ideal_PostModel model, out int code, out string msg)
        {
            code = 11;
            msg = "修改失败！";
            bool flag = false;
            Ideal_PostModel ideal_Post = GetPostDetailByID(model.PostID, out code, out msg);
            if (code != 20)
            {
                code = 11;
                msg = "没有找到此岗位！";
                return false;
            }
            ideal_Post = GetPostDetailByCode(model.PostCode, out code, out msg);
            if (code == 20 && ideal_Post.PostID != model.PostID)
            {
                code = 11;
                msg = "岗位编码不能相同！";
                return false;
            }
            ideal_Post = GetPostDetailByDeptIDAndName(model.PostName, model.DeptID, out code, out msg);
            if (code == 20 && ideal_Post.PostID == model.PostID)
            {
                code = 11;
                msg = "同一部门下岗位名称不能相同！";
                return false;
            }
            flag = BaseControl.InsertDB<Ideal_PostModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "修改成功！" : "修改失败！";
            return flag;
        }
        /// <summary>
        /// 删除岗位
        /// </summary>
        /// <param name="PostID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool DeletePost(string PostID, out int code, out string msg)
        {
            code = 11;
            msg = "修改失败！";
            bool flag = false;

            Ideal_PostModel ideal_Post = GetPostDetailByID(PostID, out code, out msg);
            if (code == 20)
            {
                code = 11;
                msg = "没有找到此岗位！";
                return false;
            }

            flag = BaseControl.Delete2DB<Ideal_PostModel>(ideal_Post, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "删除成功！" : "删除失败！";
            return flag;
        }
        #endregion

        #region 查询
        /// <summary>
        /// 根据岗位ID查询岗位详情
        /// </summary>
        /// <param name="PostID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_PostModel GetPostDetailByID(string PostID, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_PostModel model = new Ideal_PostModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlWhere = " AND PostID = '" + PostID + "'";
            model = BaseControl.GetModel<Ideal_PostModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 根据岗位Code查询岗位详情
        /// </summary>
        /// <param name="PostCode"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_PostModel GetPostDetailByCode(string PostCode, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_PostModel model = new Ideal_PostModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlWhere = " AND PostCode = '" + PostCode + "'";
            model = BaseControl.GetModel<Ideal_PostModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 根据岗位名称查询岗位详情
        /// </summary>
        /// <param name="PostCode"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_PostModel GetPostDetailByDeptIDAndName(string PostName, string DeptID, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_PostModel model = new Ideal_PostModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlWhere = " AND PostName = '" + PostName + "' AND DeptID = '" + DeptID + "'";
            model = BaseControl.GetModel<Ideal_PostModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 查询岗位分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public PageModel<Ideal_PostModel> GetPostList(PostQuery query, out int code, out string msg)
        {
            code = 22;
            msg = "查询失败！";
            PageModel<Ideal_PostModel> list = new PageModel<Ideal_PostModel>();
            PageQueryParam param = new PageQueryParam();
            param.WithNoLock = true;
            param.SqlBody = " Ideal_Post a Left Join Ideal_Dept b ";
            param.SqlColumn = "a.*,b.DeptName";
            param.PageSize = query.PageSize;
            param.PageIndex = query.PageIndex;
            if (!string.IsNullOrEmpty(query.PostCode))
            {
                param.SqlWhere += " AND a.PostCode like '%" + query.PostCode + "%'";
            }
            if (!string.IsNullOrEmpty(query.PostName))
            {
                param.SqlWhere += " AND a.PostName like '%" + query.PostName + "%'";
            }
            if (!string.IsNullOrEmpty(query.DeptID))
            {
                param.SqlWhere += " AND a.DeptID like '%" + query.DeptID + "%'";
            }
            list = BaseControl.GetPageModels<Ideal_PostModel>(param, out code, out msg);
            return list;
        }
        /// <summary>
        /// 获取所有的岗位
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<Ideal_PostModel> GetPostAllList(PostQuery query, out int code, out string msg)
        {
            code = 22;
            msg = "查询失败！";
            List<Ideal_PostModel> list = new List<Ideal_PostModel>();
            PageQueryParam param = new PageQueryParam();
            param.WithNoLock = true;
            param.SqlBody = " Ideal_Post a Left Join Ideal_Dept b ";
            param.SqlColumn = "a.*,b.DeptName";
            if (!string.IsNullOrEmpty(query.PostCode))
            {
                param.SqlWhere += " AND a.PostCode like '%" + query.PostCode + "%'";
            }
            if (!string.IsNullOrEmpty(query.PostName))
            {
                param.SqlWhere += " AND a.PostName like '%" + query.PostName + "%'";
            }
            if (!string.IsNullOrEmpty(query.DeptID))
            {
                param.SqlWhere += " AND a.DeptID like '%" + query.DeptID + "%'";
            }
            list = BaseControl.GetAllModels<Ideal_PostModel>(param, out code, out msg);
            return list;
        }
        #endregion
    }
}
