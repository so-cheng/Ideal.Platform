using Ideal.Ideal.Model;
using Ideal.Platform.BLL;
using Ideal.Platform.Model.Query;
using Ideal.Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Service
{
    public class Ideal_DBService
    {

        #region 增删改
        /// <summary>
        /// 新增数据库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary InsertDB(Ideal_DBModel model)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_DBBLL ideal_db = new Ideal_DBBLL();
            flag = ideal_db.InsertDB(model, out code, out msg);
            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }
        /// <summary>
        /// 修改数据库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnSummary UpdateDB(Ideal_DBModel model)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_DBBLL ideal_DBBLL = new Ideal_DBBLL();
            flag = ideal_DBBLL.UpdateDB(model, out code, out msg);
            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }
        /// <summary>
        /// 删除数据库
        /// </summary>
        /// <param name="SystemID"></param>
        /// <returns></returns>
        public ReturnSummary DeleteDB(string DBID)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_DBBLL ideal_DBBLL = new Ideal_DBBLL();
            flag = ideal_DBBLL.DeleteDB(DBID, out code, out msg);
            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }
        /// <summary>
        /// 修改表备注
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public ReturnSummary UpdateDescription(DBTable table)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_DBBLL ideal_DBBLL = new Ideal_DBBLL();
            flag = ideal_DBBLL.UpdateDescription(table, out code, out msg);
            ReturnSummary rs = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = flag
            };
            return rs;
        }
        public ReturnSummary UpdateFieldDescription(TableFields table)
        {
            bool flag = false;
            int code = 11;
            string msg = string.Empty;
            Ideal_DBBLL ideal_DBBLL = new Ideal_DBBLL();
            flag = ideal_DBBLL.UpdateFieldDescription(table, out code, out msg);
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
        /// 查询系统详情
        /// </summary>
        /// <param name="SystemID"></param>
        /// <returns></returns>
        public ReturnSummary GetDBDetailByID(string DBID)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_DBBLL ideal_DBBLL = new Ideal_DBBLL();
            Ideal_DBModel model = new Ideal_DBModel();
            model = ideal_DBBLL.GetDBByID(DBID, out code, out msg);
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
        /// 查询系统分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnSummary GetDBList(DBQuery query)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_DBBLL ideal_DBBLL = new Ideal_DBBLL();
            PageModel<Ideal_DBModel> model = new PageModel<Ideal_DBModel>();
            model = ideal_DBBLL.GetDBList(query, out code, out msg);
            ReturnSummary returnSummary = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = code == 21 ? false : true,
                Data = model.PageList,
                Total = model.Total,
                PageIndex = query.PageIndex,
                PageSize = query.PageSize

            };
            return returnSummary;
        }
        /// <summary>
        /// 查询所有系统
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns> 
        public ReturnSummary GetALLDBList(DBQuery query)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_DBBLL ideal_DBBLL = new Ideal_DBBLL();
            List<Ideal_DBModel> model = new List<Ideal_DBModel>();
            model = ideal_DBBLL.GetALLDBList(query, out code, out msg);
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
        /// 验证连接字符串
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns> 
        public ReturnSummary VerifyConnectionString(string ConnectionString)
        {
            bool flag = false;
            int code = 21;
            string msg = string.Empty;
            Ideal_DBBLL ideal_DBBLL = new Ideal_DBBLL();
            flag = ideal_DBBLL.VerifyConnectionString(ConnectionString, out code, out msg);
            ReturnSummary returnSummary = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = code == 21 ? false : true,
            };
            return returnSummary;
        }

        /// <summary>
        /// 查询系统分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnSummary GetDBTable(DBTableQuery query)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_DBBLL ideal_DBBLL = new Ideal_DBBLL();
            List<DBTable> model = new List<DBTable>();
            model = ideal_DBBLL.GetDBTable(query, out code, out msg);
            ReturnSummary returnSummary = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = code == 21 ? false : true,
                Data = model,
                Total = model.Count
            };
            return returnSummary;
        }
        /// <summary>
        /// 查询表字段
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnSummary GetTableFieldsList(DBTableQuery query)
        {
            int code = 21;
            string msg = string.Empty;
            Ideal_DBBLL ideal_DBBLL = new Ideal_DBBLL();
            List<TableFields> model = new List<TableFields>();
            model = ideal_DBBLL.GetTableFieldsList(query, out code, out msg);
            ReturnSummary returnSummary = new ReturnSummary()
            {
                StatusCode = code,
                Message = msg,
                IsSuccess = code == 21 ? false : true,
                Data = model,
                Total = model.Count
            };
            return returnSummary;
        }
        
        #endregion
    }
}
