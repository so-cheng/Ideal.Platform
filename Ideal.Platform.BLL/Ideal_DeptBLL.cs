using Ideal.Ideal.DB.Base;
using Ideal.Ideal.Model;
using Ideal.Platform.Common.Snowflake;
using Ideal.Platform.Model;
using Ideal.Platform.Model.Query;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.BLL
{
    public class Ideal_DeptBLL
    {

        #region 增删改
        public bool InsertDept(Ideal_DeptModel model, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "添加失败！";
            model.DeptID = SnowFlakeUse.GetSnowflakeID();
            Ideal_DeptModel dept = new Ideal_DeptModel();
            dept = GetDeptDetailByName(model.DeptName, out int xcode, out string xmsg);
            if (xcode == 20)
            {
                if (dept.ParentDeptID == model.ParentDeptID)
                {
                    code = 11;
                    msg = "添加失败！部门名称不能重复！";
                    return false;
                }
            }
            dept = GetDeptDetailByCode(model.DeptCode, out xcode, out xmsg);
            if (xcode == 20)
            {

                if (dept.ParentDeptID == model.ParentDeptID)
                {
                    code = 11;
                    msg = "查询失败！部门编码不能重复！";
                    return false;
                }
            }
            flag = BaseControl.InsertDB<Ideal_DeptModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "添加成功！" : "添加失败！";
            return flag;

        }
        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="model"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateDept(Ideal_DeptModel model, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "修改失败！";
            Ideal_DeptModel dept = new Ideal_DeptModel();
            dept = GetDeptDetailByID(model.DeptID, out int xcode, out string xmsg);
            if (xcode != 20)
            {
                code = 11;
                msg = "没有找到此部门数据！";
                return false;
            }
            dept = GetDeptDetailByName(model.DeptName, out xcode, out xmsg);
            if (xcode == 20 && dept.DeptID != model.DeptID && dept.ParentDeptID == model.ParentDeptID)
            {
                code = 11;
                msg = "添加失败！部门名称不能重复！";
            }
            dept = GetDeptDetailByCode(model.DeptCode, out xcode, out xmsg);
            if (xcode == 20 && dept.DeptID != model.DeptID && dept.ParentDeptID == model.ParentDeptID)
            {
                code = 11;
                msg = "查询失败！部门编码不能重复！";
            }
            flag = BaseControl.UpdateDB<Ideal_DeptModel>(model, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "修改成功！" : "修改失败！";
            return flag;
        }
        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <param name="DeptID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool DeleteDept(string DeptID, out int code, out string msg)
        {
            bool flag = false;
            code = 11;
            msg = "删除失败！";
            Ideal_DeptModel dept = new Ideal_DeptModel();
            dept = GetDeptDetailByID(DeptID, out int xcode, out string xmsg);
            if (xcode != 20)
            {
                code = 11;
                msg = "没有找到次部门数据！";
                return false;
            }
            flag = BaseControl.Delete2DB<Ideal_DeptModel>(dept, out code, out msg);
            code = flag ? 10 : 11;
            msg = flag ? "删除成功！" : "删除失败！";
            return flag;
        }

        #endregion

        #region 查询
        /// <summary>
        /// 根据ID查询部门
        /// </summary>
        /// <param name="DeptID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_DeptModel GetDeptDetailByID(string DeptID, out int code, out string msg)
        {
            code = 22;
            msg = "查询失败！";
            Ideal_DeptModel model = new Ideal_DeptModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlWhere = " AND DeptID = '" + DeptID + "'";
            model = BaseControl.GetModel<Ideal_DeptModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 根据部门名称查询部门
        /// </summary>
        /// <param name="DeptName"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_DeptModel GetDeptDetailByName(string DeptName, out int code, out string msg)
        {
            code = 22;
            msg = "查询失败！";
            Ideal_DeptModel model = new Ideal_DeptModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlWhere = " AND DeptName = '" + DeptName + "'";
            model = BaseControl.GetModel<Ideal_DeptModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 根据Code查询部门
        /// </summary>
        /// <param name="DeptCode"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_DeptModel GetDeptDetailByCode(string DeptCode, out int code, out string msg)
        {
            code = 22;
            msg = "查询失败！";
            Ideal_DeptModel model = new Ideal_DeptModel();
            PageQueryParam param = new PageQueryParam();
            param.SqlWhere = " AND DeptCode = '" + DeptCode + "'";
            model = BaseControl.GetModel<Ideal_DeptModel>(param, out code, out msg);
            return model;
        }
        /// <summary>
        /// 查询部门分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public PageModel<Ideal_DeptModel> GetDeptList(DeptQuery query, out int code, out string msg)
        {
            code = 22;
            msg = "查询失败！";
            PageModel<Ideal_DeptModel> list = new PageModel<Ideal_DeptModel>();
            PageQueryParam param = new PageQueryParam();
            param.WithNoLock = true;
            param.SqlBody = " Ideal_Dept a Left Join Ideal_Company b ";
            param.SqlColumn = "a.*,b.CompangName";
            param.PageSize = query.PageSize;
            param.PageIndex = query.PageIndex;
            if (!string.IsNullOrEmpty(query.DeptCode))
            {
                param.SqlWhere += " AND a.DeptCode like '%" + query.DeptCode + "%'";
            }
            if (!string.IsNullOrEmpty(query.DeptName))
            {
                param.SqlWhere += " AND a.DeptName like '%" + query.DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(query.CompanyID))
            {
                param.SqlWhere += " AND a.CompanyID like '%" + query.CompanyID + "%'";
            }
            list = BaseControl.GetPageModels<Ideal_DeptModel>(param, out code, out msg);
            return list;
        }
        /// <summary>
        /// 获取所有部门
        /// </summary>
        /// <param name="query"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<Ideal_DeptModel> GetDeptAllList(DeptQuery query, out int code, out string msg)
        {
            code = 22;
            msg = "查询失败！";
            List<Ideal_DeptModel> list = new List<Ideal_DeptModel>();
            PageQueryParam param = new PageQueryParam();
            param.WithNoLock = true;
            //param.SqlBody = " Iedal_Dept a  LEFT JOIN Ideal_Company b ON a.CompanyID = b.CompanyID ";
            //param.SqlColumn = "a.*,b.CompanyName";
            param.PageSize = query.PageSize;
            param.PageIndex = query.PageIndex;
            if (!string.IsNullOrEmpty(query.DeptCode))
            {
                param.SqlWhere += " AND a.DeptCode = '" + query.DeptCode + "'";
            }
            if (!string.IsNullOrEmpty(query.DeptName))
            {
                param.SqlWhere += " AND a.DeptName like '%" + query.DeptName + "%'";
            }
            //if (!string.IsNullOrEmpty(query.CompanyID))
            //{
            //    param.SqlWhere += " AND a.CompanyID like '%" + query.CompanyID + "%'";
            //}
            list = BaseControl.GetAllModels<Ideal_DeptModel>(param, out code, out msg);
            return list;
        }
        /// <summary>
        /// 查询部门树
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<DeptTree> GetDeptTree(out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_CompanyBLL ideal_CompanyService = new Ideal_CompanyBLL();
            Ideal_DeptBLL ideal_DeptBLL = new Ideal_DeptBLL();
            List<DeptTree> list = new List<DeptTree>();
            //所有公司
            List<Ideal_CompanyModel> companyModels = ideal_CompanyService.GetCompanyAllList(new CompanyQuery(), out code, out msg);
            //所有部门 
            List<Ideal_DeptModel> deptModels = ideal_DeptBLL.GetDeptAllList(new DeptQuery(), out code, out msg);
            foreach (var item in companyModels)
            {
                DeptTree tree = new DeptTree();
                tree.ID = item.CompanyID;
                tree.Name = item.CompanyName;
                tree.Child = GetTree(deptModels, tree);
                list.Add(tree);
            }
            return list;
        }
        private List<DeptTree> GetTree(List<Ideal_DeptModel> list, DeptTree dept)
        {
            List<DeptTree> listtree = new List<DeptTree>();
            List<Ideal_DeptModel> ls = list.Where(a => a.ParentDeptID == dept.ID).ToList();
            if (ls.Count > 0)
            {
                foreach (var item in ls)
                {
                    DeptTree tree = new DeptTree();
                    tree.ID = item.DeptID;
                    tree.Name = item.DeptName;
                    tree.PID = item.ParentDeptID;
                    tree.Child = GetTree(ls, tree);
                    listtree.Add(tree);
                }
            }
            return listtree;
        }
        #endregion
    }
}
