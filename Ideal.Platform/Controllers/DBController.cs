using Ideal.Ideal.Model;
using Ideal.Platform.Model.Query;
using Ideal.Platform.Model;
using Ideal.Platform.Service;
using Microsoft.AspNetCore.Mvc;

namespace Ideal.Platform.Controllers
{
    public class DBController : Controller
    {
        #region 增删改
        /// <summary>
        /// 新增数据库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult InsertDB(Ideal_DBModel model)
        {
            Ideal_DBService ideal_DBService = new Ideal_DBService();
            ReturnSummary returnSummary = ideal_DBService.InsertDB(model);
            return Json(returnSummary);
        }
        /// <summary>
        /// 修改数据库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult UpdateDB(Ideal_DBModel model)
        {
            Ideal_DBService ideal_DBService = new Ideal_DBService();
            ReturnSummary returnSummary = ideal_DBService.UpdateDB(model);
            return Json(returnSummary);
        }
        /// <summary>
        /// 删除数据库
        /// </summary>
        /// <param name="DBID"></param>
        /// <returns></returns>
        public JsonResult DeleteDB(string DBID)
        {
            Ideal_DBService ideal_DBService = new Ideal_DBService();
            ReturnSummary returnSummary = ideal_DBService.DeleteDB(DBID);
            return Json(returnSummary);
        }
        /// <summary>
        /// 修改表备注
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public JsonResult UpdateDescription(DBTable table)
        {
            Ideal_DBService ideal_DBService = new Ideal_DBService();
            ReturnSummary returnSummary = ideal_DBService.UpdateDescription(table);
            return Json(returnSummary);
        }
        public JsonResult UpdateFieldDescription(TableFields table)
        {
            Ideal_DBService ideal_DBService = new Ideal_DBService();
            ReturnSummary returnSummary = ideal_DBService.UpdateFieldDescription(table);
            return Json(returnSummary);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询数据库详情
        /// </summary>
        /// <param name="DBID"></param>
        /// <returns></returns>
        public JsonResult GetDBDetailByID(string DBID)
        {
            Ideal_DBService ideal_DBService = new Ideal_DBService();
            ReturnSummary ReturnSummary = ideal_DBService.GetDBDetailByID(DBID);
            return Json(ReturnSummary);
        }
        /// <summary>
        /// 查询数据库分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult GetDBList(DBQuery query)
        {
            Ideal_DBService ideal_DBService = new Ideal_DBService();
            ReturnSummary returnSummary = ideal_DBService.GetDBList(query);
            return Json(returnSummary);
        }
        /// <summary>
        /// 查询所有数据库
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult GetALLDBList(DBQuery query)
        {
            Ideal_DBService ideal_DBService = new Ideal_DBService();
            ReturnSummary returnSummary = ideal_DBService.GetALLDBList(query);
            return Json(returnSummary);
        }
        /// <summary>
        /// 验证连接字符串
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult VerifyConnectionString(string ConnectionString)
        {
            Ideal_DBService ideal_DBService = new Ideal_DBService();
            ReturnSummary returnSummary = ideal_DBService.VerifyConnectionString(ConnectionString);
            return Json(returnSummary);
        }
        public JsonResult GetDBTable(DBTableQuery query)
        {
            Ideal_DBService ideal_DBService = new Ideal_DBService();
            ReturnSummary returnSummary = ideal_DBService.GetDBTable(query);
            return Json(returnSummary);
        }
        /// <summary>
        /// 查询表字段
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public JsonResult GetTableFieldsList(DBTableQuery query)
        {
            Ideal_DBService ideal_DBService = new Ideal_DBService();
            ReturnSummary returnSummary = ideal_DBService.GetTableFieldsList(query);
            return Json(returnSummary);
        }
        
        #endregion
    }
}
