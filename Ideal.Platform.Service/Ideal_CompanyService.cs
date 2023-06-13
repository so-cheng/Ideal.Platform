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
    public class Ideal_CompanyService
    {

        #region 增删改
        /// <summary>
        /// 新增公司
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary InsertCompany(Ideal_CompanyModel model)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_CompanyBLL ideal_CompanyBLL = new Ideal_CompanyBLL();
            flag = ideal_CompanyBLL.InsertCompany(model, out code, out msg);
            if (flag)
            {
                RedisHelper.SetValue((int)RedisType.Company, model.CompanyID, JsonConvert.SerializeObject(model));
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
        /// 修改公司
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary UpdateCompany(Ideal_CompanyModel model)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_CompanyBLL ideal_CompanyBLL = new Ideal_CompanyBLL();
            flag = ideal_CompanyBLL.UpdateCompany(model, out code, out msg);
            if (flag)
            {
                RedisHelper.UpdateValue((int)RedisType.Company, model.CompanyID, JsonConvert.SerializeObject(model));
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
        /// 删除公司
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public ReturnSummary DeleteCompany(string CompanyID)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_CompanyBLL ideal_CompanyBLL = new Ideal_CompanyBLL();
            flag = ideal_CompanyBLL.DeleteCompany(CompanyID, out code, out msg);
            if (flag)
            {
                RedisHelper.DeleteKey((int)RedisType.Company, CompanyID);
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
        /// 查询公司详情
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public ReturnSummary GetCompanyDetailByID(string CompanyID)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_CompanyBLL ideal_CompanyBLL = new Ideal_CompanyBLL();
            Ideal_CompanyModel model = new Ideal_CompanyModel();
            model = ideal_CompanyBLL.GetCompanyDetailByID(CompanyID, out code, out msg);
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
        /// 查询公司分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnSummary GetCompanyList(CompanyQuery query)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_CompanyBLL ideal_CompanyBLL = new Ideal_CompanyBLL();
            PageModel<Ideal_CompanyModel> model = new PageModel<Ideal_CompanyModel>();
            model = ideal_CompanyBLL.GetCompanyList(query, out code, out msg);
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
        /// 查询所有公司
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns> 
        public ReturnSummary GetCompanyAllList(CompanyQuery query)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_CompanyBLL ideal_CompanyBLL = new Ideal_CompanyBLL();
            List<Ideal_CompanyModel> model = new List<Ideal_CompanyModel>();
            model = ideal_CompanyBLL.GetCompanyAllList(query, out code, out msg);
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