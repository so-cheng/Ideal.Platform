using Ideal.Ideal.DB.Base;
using Ideal.Ideal.Model;
using Ideal.Platform.Common;
using Ideal.Platform.Common.Snowflake;
using Ideal.Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.BLL
{
    public class Ideal_WorkFlowBLL
    {
        #region 增删改
        /// <summary>
        /// 新增流程模板
        /// </summary>
        /// <param name="model"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool InsertFlowTemplate(Ideal_FlowTemplateModel model, out int code, out string msg)
        {
            code = 11;
            msg = "添加失败！";
            bool flag = false;
            model.FlowTemplateID = SnowFlakeUse.GetSnowflakeID();
            Ideal_FlowTemplateModel ideal_RoleModel = new Ideal_FlowTemplateModel();
            ideal_RoleModel = GetFlowTemplateDetailByName(model.FlowTemplateName, out code, out msg);
            if (code == 20)
            {
                code = 11;
                msg = "流程模板名称不能相同!";
                return flag;
            }
            List<Ideal_StepTemplateModel> list = new List<Ideal_StepTemplateModel>();
            ideal_RoleModel.NodeConfig.FlowTemplateID = model.FlowTemplateID;
            ideal_RoleModel.NodeConfig.Creator = model.Creator;
            ideal_RoleModel.NodeConfig.CreateTime = model.CreateTime;
            List<string> strings = new List<string>();
            strings = GetStepTemplateModel(ideal_RoleModel.NodeConfig, strings);

            return flag;
        }
        /// <summary>
        /// 获取新增sql
        /// </summary>
        /// <param name="model"></param>
        /// <param name="strings"></param>
        /// <returns></returns>
        private List<string> GetStepTemplateModel(Ideal_StepTemplateModel model, List<string> strings)
        {
            Ideal_StepTemplateModel ideal_StepTemplateModel = new Ideal_StepTemplateModel();
            model.StepID = SnowFlakeUse.GetSnowflakeID();
            string sqlStr = BaseControl.GetInsert2DBSQL<Ideal_StepTemplateModel>(model);
            strings.Add(sqlStr);
            if (model.NodeUserList.Count > 0)
            {
                foreach (var item in model.NodeUserList)
                {
                    strings.Add(BaseControl.GetInsert2DBSQL<Ideal_StepUserModel>(item));
                }
            }
            if (model.NodeDeptList.Count > 0)
            {
                foreach (var item in model.NodeDeptList)
                {
                    strings.Add(BaseControl.GetInsert2DBSQL<Ideal_StepDeptModel>(item));
                }
            }
            if (model.Type == StepType.ConditionRout)
            {
                if (model.ConditionNodes.Count > 0)
                {
                    foreach (var item in model.ConditionNodes)
                    {
                        strings.Add(BaseControl.GetInsert2DBSQL<Ideal_StepTemplateModel>(model));
                        foreach (var node in item.ConditionList)
                        {
                            strings.Add(BaseControl.GetInsert2DBSQL<Ideal_StepConditionModel>(node));
                        }
                    }
                }
            }
            if (string.IsNullOrEmpty(model.ChildNode.Type))
            {
                model.ChildNode.StepID = SnowFlakeUse.GetSnowflakeID();
                GetStepTemplateModel(model.ChildNode, strings);
            }
            return strings;
        }
        #endregion

        #region 查询

        /// <summary>
        /// 通过流程模板名称查询详情
        /// </summary>
        /// <param name="FlowTemplateName"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ideal_FlowTemplateModel GetFlowTemplateDetailByName(string FlowTemplateName, out int code, out string msg)
        {
            code = 21;
            msg = "查询失败！";
            Ideal_FlowTemplateModel ideal_FlowTemplateModel = new Ideal_FlowTemplateModel();
            PageQueryParam parm = new PageQueryParam();
            parm.SqlWhere = " AND FlowTemplateName = '" + FlowTemplateName + "'";
            ideal_FlowTemplateModel = BaseControl.GetModel<Ideal_FlowTemplateModel>(parm, out code, out msg);
            return ideal_FlowTemplateModel;
        }
        #endregion

    }
}
