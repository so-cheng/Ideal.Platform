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
    public class Ideal_CompanyBLL
    {
        #region 增删改
        /// <summary>
        /// 新增公司
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertCompany(Ideal_CompanyModel model, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "新增失败！";
            Ideal_CompanyModel company = new Ideal_CompanyModel();
            company = GetCompanyDetailByName(model.CompanyName, out int xcode, out string xmsg);
            if (xcode == 20)
            {
                code = 11;
                msg = "公司名称不能相同！";
                return false;
            }
            company = GetCompanyDetailByCode(model.CompanyCode, out xcode, out xmsg);
            if (xcode == 20)
            {
                code = 11;
                msg = "公司编码不能相同！";
                return false;
            }
            model.CompanyID = SnowFlakeUse.GetSnowflakeID();
            flag = BaseControl.InsertDB<Ideal_CompanyModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "新增成功！" : "新增失败！";
            return flag;
        }
        /// <summary>
        /// 修改公司
        /// </summary>
        /// <param name="model"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateCompany(Ideal_CompanyModel model, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "修改失败！";
            Ideal_CompanyModel company = new Ideal_CompanyModel();
            company = GetCompanyDetailByID(model.CompanyID, out code, out msg);
            if (code != 20)
            {
                code = 11;
                msg = "没有找到此公司！";
                return false;
            }
            Ideal_CompanyModel ideal_CompanyModel = new Ideal_CompanyModel();
            ideal_CompanyModel = GetCompanyDetailByName(model.CompanyName, out int xcode, out string xmsg);
            if (xcode == 20 && ideal_CompanyModel.CompanyID != model.CompanyID)
            {
                code = 11;
                msg = "公司名称不能相同！";
                return false;
            }
            ideal_CompanyModel = GetCompanyDetailByCode(model.CompanyCode, out xcode, out xmsg);
            if (xcode == 20 && ideal_CompanyModel.CompanyID != model.CompanyID)
            {
                code = 11;
                msg = "公司编码不能相同！";
                return false;
            }
            flag = BaseControl.UpdateDB<Ideal_CompanyModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "修改成功！" : "修改失败！";
            return flag;
        }
        /// <summary>
        /// 删除公司
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool DeleteCompany(string CompanyID, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "删除失败！";
            Ideal_CompanyModel company = new Ideal_CompanyModel();
            company = GetCompanyDetailByID(CompanyID, out code, out msg);
            if (code != 20)
            {
                msg = "没有找到此公司！";
                return false;
            }
            flag = BaseControl.Delete2DB<Ideal_CompanyModel>(company, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "删除成功！" : "删除失败！";
            return flag;
        }

        #endregion

        #region 查询
        /// <summary>
        /// 公司详情
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public Ideal_CompanyModel GetCompanyDetailByID(string CompanyID, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_CompanyModel model = new Ideal_CompanyModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlWhere = " AND CompanyID = '" + CompanyID + "'";
            model = BaseControl.GetModel<Ideal_CompanyModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 公司详情（公司名称）
        /// </summary>
        /// <param name="CompanyName"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_CompanyModel GetCompanyDetailByName(string CompanyName, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_CompanyModel model = new Ideal_CompanyModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlWhere = " AND CompanyName = '" + CompanyName + "'";
            model = BaseControl.GetModel<Ideal_CompanyModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 公司详情（公司编码）
        /// </summary>
        /// <param name="CompanyName"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_CompanyModel GetCompanyDetailByCode(string CompanyCode, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_CompanyModel model = new Ideal_CompanyModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlWhere = " AND CompanyCode = '" + CompanyCode + "'";
            model = BaseControl.GetModel<Ideal_CompanyModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 查询公司分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public PageModel<Ideal_CompanyModel> GetCompanyList(CompanyQuery query, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            PageModel<Ideal_CompanyModel> pageModel = new PageModel<Ideal_CompanyModel>();
            PageQueryParam param = new PageQueryParam();

            if (!string.IsNullOrEmpty(query.CompanyName))
            {
                param.SqlWhere += " AND CompanyName LIKE '%" + query.CompanyName + "%'";
            }

            if (!string.IsNullOrEmpty(query.CompanyCode))
            {
                param.SqlWhere += " AND CompanyCode LIKE '%" + query.CompanyCode + "%'";
            }
            param.PageIndex = query.PageIndex;
            param.PageSize = query.PageSize;
            param.WithNoLock = true;
            pageModel = BaseControl.GetPageModels<Ideal_CompanyModel>(param, out code, out msg);
            return pageModel;
        }
        /// <summary>
        /// 获取所有公司
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<Ideal_CompanyModel> GetCompanyAllList(CompanyQuery query, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            List<Ideal_CompanyModel> pageModel = new List<Ideal_CompanyModel>();
            PageQueryParam param = new PageQueryParam();

            if (!string.IsNullOrEmpty(query.CompanyName))
            {
                param.SqlWhere += " AND CompanyName LIKE '%" + query.CompanyName + "%'";
            }

            if (!string.IsNullOrEmpty(query.CompanyCode))
            {
                param.SqlWhere += " AND CompanyCode LIKE '%" + query.CompanyCode + "%'";
            }
            param.PageIndex = query.PageIndex;
            param.PageSize = query.PageSize;
            param.WithNoLock = true;
            pageModel = BaseControl.GetAllModels<Ideal_CompanyModel>(param, out code, out msg);
            return pageModel;
        }

        #endregion

    }
}
