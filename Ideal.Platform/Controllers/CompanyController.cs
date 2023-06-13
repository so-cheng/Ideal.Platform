using Ideal.Ideal.Model;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using Ideal.Platform.Service;
using Microsoft.AspNetCore.Mvc;

namespace Ideal.Platform.Controllers
{
    public class CompanyController : Controller
    {
        #region 增删改
        /// <summary>
        /// 新增公司
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult InsertCompany(Ideal_CompanyModel model)
        {
            Ideal_CompanyService ideal_CompanyService = new Ideal_CompanyService();
            ReturnSummary returnSummary = ideal_CompanyService.InsertCompany(model);
            return Json(returnSummary);
        }
        /// <summary>
        /// 修改公司
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult UpdateCompany(Ideal_CompanyModel model)
        {
            Ideal_CompanyService ideal_CompanyService = new Ideal_CompanyService();
            ReturnSummary returnSummary = ideal_CompanyService.UpdateCompany(model);
            return Json(returnSummary);
        }
        /// <summary>
        /// 删除公司
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public JsonResult DeleteCompany(string CompanyID)
        {
            Ideal_CompanyService ideal_CompanyService = new Ideal_CompanyService();
            ReturnSummary returnSummary = ideal_CompanyService.DeleteCompany(CompanyID);
            return Json(returnSummary);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询公司详情
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public JsonResult GetCompanyDetailByID(string CompanyID)
        {
            Ideal_CompanyService ideal_CompanyService = new Ideal_CompanyService();
            ReturnSummary ReturnSummary = ideal_CompanyService.GetCompanyDetailByID(CompanyID);
            return Json(ReturnSummary);
        }
        /// <summary>
        /// 查询公司分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult GetCompanyList(CompanyQuery query)
        {
            Ideal_CompanyService ideal_CompanyService = new Ideal_CompanyService();
            ReturnSummary returnSummary = ideal_CompanyService.GetCompanyList(query);
            return Json(returnSummary);
        }
        /// <summary>
        /// 查询所有公司
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult GetCompanyAllList(CompanyQuery query)
        {
            Ideal_CompanyService ideal_CompanyService = new Ideal_CompanyService();
            ReturnSummary returnSummary = ideal_CompanyService.GetCompanyAllList(query);
            return Json(returnSummary);
        }
        #endregion
    }
}
