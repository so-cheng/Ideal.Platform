using Ideal.Ideal.DB.Base;
using Ideal.Ideal.Model;
using Ideal.Platform.Common.Snowflake;
using Ideal.Platform.Model.Query;
using Ideal.Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Ideal.Ideal.DB;
using System.Collections;
using System.Reflection;
using System.Data;

namespace Ideal.Platform.BLL
{
    public class Ideal_DBBLL
    {
        #region 增删改
        public bool InsertDB(Ideal_DBModel model, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "添加失败！";
            model.DBID = SnowFlakeUse.GetSnowflakeID();
            Ideal_DBModel db = new Ideal_DBModel();
            db = GetDBByName(model.DBName, out int xcode, out string xmsg);
            if (xcode == 20)
            {
                code = 11;
                msg = "添加失败！数据库名称重复！";
                return false;
            }
            flag = VerifyConnectionString(model.ConnectionString, out code, out msg);
            if (!flag)
            {
                msg = "字符串连接失败！";
                return false;
            }

            flag = BaseControl.InsertDB<Ideal_DBModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "添加成功！" : "添加失败！";
            return flag;

        }
        /// <summary>
        /// 修改数据库
        /// </summary>
        /// <param name="model"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateDB(Ideal_DBModel model, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "修改失败！";
            Ideal_DBModel db = new Ideal_DBModel();
            db = GetDBByName(model.DBName, out int xcode, out string xmsg);
            if (xcode == 20)
            {
                if (db.DBID != model.DBID)
                {
                    code = 11;
                    msg = "修改失败！数据库名称重复！";
                    return false;
                }
            }
            flag = VerifyConnectionString(model.ConnectionString, out code, out msg);
            if (!flag)
            {
                msg = "字符串连接失败！";
                return false;
            }
            flag = BaseControl.UpdateDB<Ideal_DBModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "修改成功！" : "修改失败！";
            return flag;

        }

        /// <summary>
        /// 删除数据库
        /// </summary>
        /// <param name="SystemID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool DeleteDB(string DBID, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "删除失败！";
            Ideal_DBModel System = new Ideal_DBModel();
            System = GetDBByID(DBID, out code, out msg);
            if (code != 20)
            {
                msg = "没有找到此数据库！";
                return false;
            }
            flag = BaseControl.Delete2DB<Ideal_DBModel>(System, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "删除成功！" : "删除失败！";
            return flag;
        }
        /// <summary>
        /// 修改表注释
        /// </summary>
        /// <param name="table"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateDescription(DBTable table, out int code,out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "修改失败！";
            List<DBTable> dBTable = new List<DBTable>();
            Ideal_DBModel db = new Ideal_DBModel();
            List<DBTable> list = GetDBTable(new DBTableQuery() { DBID = table.DBID}, out code, out msg);
            string isadd = string.Empty;
            DBTable dBTable1 = list.SingleOrDefault(a => a.TableName == table.TableName);
            if (string.IsNullOrEmpty(dBTable1.TableDesc))
            {
                isadd = "sys.sp_addextendedproperty";
            }
            else
            {
                isadd = "sys.sp_updateextendedproperty";
            }
            db = GetDBByID(table.DBID, out int xcode, out string xmsg);
            DbUtility dbUtility = new DbUtility(db.ConnectionString);
            string querstr = string.Empty;
            string sqlstr = @$"
                    EXEC {isadd}
                    @name = N'MS_Description',
                    @value = N'{table.TableDesc}',
                    @level0type = N'SCHEMA',
                    @level0name = N'dbo',
                    @level1type = N'TABLE',
                    @level1name = N'{table.TableName}';
                ";
            int count  = dbUtility.ExecuteNonQuery(sqlstr, out code, out msg);
            if (count == 0)
            {
                flag = true;
                msg = "修改成功！";
            }
            return flag;

        }



        /// <summary>
        /// 修改表注释
        /// </summary>
        /// <param name="table"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateFieldDescription(TableFields table, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "修改失败！";
            List<DBTable> dBTable = new List<DBTable>();
            Ideal_DBModel db = new Ideal_DBModel();
            List<TableFields> list = GetTableFieldsList(new DBTableQuery() { DBID = table.DBID }, out code, out msg);
            TableFields fd = list.SingleOrDefault(a => a.TableName == table.TableName && a.Name == table.Name);
            string isadd = string.Empty;
            if (string.IsNullOrEmpty(fd.Description))
            {
                isadd = "sys.sp_addextendedproperty";
            }
            else
            {
                isadd = "sys.sp_updateextendedproperty ";
            }
            db = GetDBByID(table.DBID, out int xcode, out string xmsg);
            DbUtility dbUtility = new DbUtility(db.ConnectionString);
            string querstr = string.Empty;
            string sqlstr = @$"
                    EXEC {isadd}
                    @name=N'MS_Description', 
                    @value=N'{table.Description}', 
                    @level0type=N'SCHEMA',
                    @level0name=N'dbo',
                    @level1type=N'TABLE',
                    @level1name=N'{table.TableName}',
                    @level2type=N'COLUMN',
                    @level2name=N'{table.Name}';
                ";
            int count = dbUtility.ExecuteNonQuery(sqlstr, out code, out msg);
            if (count == 0)
            {
                flag = true;
                msg = "修改成功！";
            }
            return flag;

        }

        #endregion

        #region 查询
        /// <summary>
        /// 通过DBName查询DB
        /// </summary>
        /// <param name="DBName"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_DBModel GetDBByName(string DBName, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_DBModel model = new Ideal_DBModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlWhere = " AND DBName = '" + DBName + "'";
            model = BaseControl.GetModel<Ideal_DBModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 通过数据库ID查询
        /// </summary>
        /// <param name="DBID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_DBModel GetDBByID(string DBID, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_DBModel model = new Ideal_DBModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlWhere = " AND DBID = '" + DBID + "'";
            model = BaseControl.GetModel<Ideal_DBModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 查询数据库分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public PageModel<Ideal_DBModel> GetDBList(DBQuery query, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            PageModel<Ideal_DBModel> pageModel = new PageModel<Ideal_DBModel>();
            PageQueryParam param = new PageQueryParam();
            if (!string.IsNullOrEmpty(query.DBName))
            {
                param.SqlWhere += " AND DBName LIKE '%" + query.DBName + "%'";
            }
            param.PageIndex = query.PageIndex;
            param.PageSize = query.PageSize;
            param.WithNoLock = true;
            pageModel = BaseControl.GetPageModels<Ideal_DBModel>(param, out code, out msg);
            return pageModel;
        }
        /// <summary>
        /// 查询数据库分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<Ideal_DBModel> GetALLDBList(DBQuery query, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            List<Ideal_DBModel> pageModel = new List<Ideal_DBModel>();
            PageQueryParam param = new PageQueryParam();
            if (!string.IsNullOrEmpty(query.DBName))
            {
                param.SqlWhere += " AND DBName LIKE '%" + query.DBName + "%'";
            }
            param.WithNoLock = true;
            pageModel = BaseControl.GetAllModels<Ideal_DBModel>(param, out code, out msg);
            return pageModel;
        }
        /// <summary>
        /// 验证连接字符串
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool VerifyConnectionString(string ConnectionString, out int code, out string msg)
        {
            bool flag = false;
            code = 21;
            msg = "连接失败！";
            DbUtility dbUtility = new DbUtility();
            flag = dbUtility.ValidateDbConnection(ConnectionString);
            if (flag)
            {
                code = 20;
                msg = "连接成功!";
            }
            return flag;
        }
        /// <summary>
        /// 查询数据库表
        /// </summary>
        /// <param name="DBID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        public List<DBTable> GetDBTable(DBTableQuery query, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            List<DBTable> dBTable = new List<DBTable>();
            Ideal_DBModel db = new Ideal_DBModel();
            if (string.IsNullOrEmpty(query.DBID))
            {
                return dBTable;
            }
            db = GetDBByID(query.DBID, out int xcode, out string xmsg);
            DbUtility dbUtility = new DbUtility(db.ConnectionString);
            string querstr = string.Empty;
            string sqlstr = @"
                SELECT
                CASE WHEN C.column_id=1 THEN O.name ELSE N'' END AS TableName ,
                ISNULL(CASE WHEN C.column_id=1 THEN PTB.[value] END,N'') AS TableDesc
                FROM sys.columns C
                INNER JOIN sys.objects O ON C.[object_id]=O.[object_id]
                AND O.type='U' AND O.is_ms_shipped=0
                INNER JOIN sys.types T ON C.user_type_id=T.user_type_id
                LEFT JOIN sys.default_constraints D ON C.[object_id]=D.parent_object_id
                AND C.column_id=D.parent_column_id AND C.default_object_id=D.[object_id]
                LEFT JOIN sys.extended_properties PFD ON PFD.class=1
                AND C.[object_id]=PFD.major_id AND C.column_id=PFD.minor_id
                -- AND PFD.name='Caption' -- 字段说明对应的描述名称(一个字段可以添加多个不同name的描述)
                LEFT JOIN sys.extended_properties PTB ON PTB.class=1
                AND PTB.minor_id=0 AND C.[object_id]=PTB.major_id
                -- AND PFD.name='Caption' -- 表说明对应的描述名称(一个表可以添加多个不同name的描述)
                LEFT JOIN -- 索引及主键信息
                (
                SELECT
                IDXC.[object_id],
                IDXC.column_id,
                Sort=CASE INDEXKEY_PROPERTY(IDXC.[object_id],IDXC.index_id,IDXC.index_column_id,'IsDescending')
                WHEN 1 THEN 'DESC' WHEN 0 THEN 'ASC' ELSE '' END,
                PrimaryKey=CASE WHEN IDX.is_primary_key=1 THEN N'√'ELSE N'' END,
                IndexName=IDX.Name
                FROM sys.indexes IDX
                INNER JOIN sys.index_columns IDXC ON IDX.[object_id]=IDXC.[object_id]
                AND IDX.index_id=IDXC.index_id
                LEFT JOIN sys.key_constraints KC ON IDX.[object_id]=KC.[parent_object_id]
                AND IDX.index_id=KC.unique_index_id
                INNER JOIN -- 对于一个列包含多个索引的情况,只显示第1个索引信息
                (
                SELECT [object_id], Column_id, index_id=MIN(index_id)
                FROM sys.index_columns
                GROUP BY [object_id], Column_id
                ) IDXCUQ ON IDXC.[object_id]=IDXCUQ.[object_id]
                AND IDXC.Column_id=IDXCUQ.Column_id AND IDXC.index_id=IDXCUQ.index_id
                ) IDX ON C.[object_id]=IDX.[object_id]
                AND C.column_id=IDX.column_id
                WHERE C.column_id=1 " + querstr + " ORDER BY O.name,C.column_id ";
            DataTable dt = dbUtility.ExecuteScalar(sqlstr, out code, out msg);
            dBTable = BaseControl.ConvertToEntityList<DBTable>(dt);
            List<TableFields> tables = GetTableFieldsList(query, out code, out msg);
            foreach (var item in dBTable)
            {
                item.Table = tables.Where(a => a.TableName == item.TableName).ToList();
            }
            return dBTable;
        }
        /// <summary>
        /// 查询表字段
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<TableFields> GetTableFieldsList(DBTableQuery query, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            List<TableFields> list = new List<TableFields>();
            Ideal_DBModel db = new Ideal_DBModel();
            db = GetDBByID(query.DBID, out int xcode, out string xmsg);
            DbUtility dbUtility = new DbUtility(db.ConnectionString);
            string sqlstr = $@"
                    select
                    TableName   =d.name,
                    Colorder    = a.colorder,
                    Name    = a.name,
                    Description    = isnull(g.[value],''),
                    FieldsType    = case when b.name='decimal' or b.name='numeric' 
                                 then b.name + '(' + CONVERT(varchar(10), a.prec) + ',' + CONVERT(varchar(10), a.xscale) +')' 
                                 when b.name like '%char' 
                                 then b.name + '(' + (case when a.length=-1 then 'max' else CONVERT(varchar(10), iif(b.name LIKE 'n%',a.length/2,a.length))     end) +  ')' 
                                 else b.name end,
                    FieldsLength    = a.length,
                    Decimals    = isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0),
                    IsNull    = case when a.isnullable=1 then '√'else '' end,
                    Defaultvalue    = isnull(e.text,''),    
                    AddColumn    = case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then '√'else '' end,
                    IsPrimaryKey    = case when exists(SELECT 1 FROM sysobjects where xtype='PK' and parent_obj=a.id and name in (
                                 select name FROM sysindexes WHERE indid in( SELECT indid FROM sysindexkeys WHERE id = a.id AND colid=a.colid))) then '√' else  ''   end
                from syscolumns a
                left join systypes b on a.xusertype=b.xusertype
                inner join sysobjects d on a.id=d.id  and d.xtype='U' and  d.name<>'dtproperties'
                left join syscomments e on a.cdefault=e.id
                left join sys.extended_properties   g on a.id=G.major_id and a.colid=g.minor_id  
                left join sys.extended_properties f on d.id=f.major_id and f.minor_id=0
                order by a.id,a.colorder 
            ";
            DataTable dt = dbUtility.ExecuteScalar(sqlstr, out code, out msg);
            list = BaseControl.ConvertToEntityList<TableFields>(dt);
            return list;
        }

        #endregion
    }
}
