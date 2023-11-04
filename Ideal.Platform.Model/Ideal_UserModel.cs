// <copyright file="Ideal_UserModel.cs" company=" Pvirtech Information Technology , Inc.">
//    Copyright (c) 2019 Pvirtech Information Technology , Inc. 
//    All Rights Reserved.
//    @文件名: Ideal_UserModel.cs
//    @功能描述: 
// 
//    @版本: 1.0
//    @创建人: 宋诚
//    @创建日期: 2020-02-17
// </copyright>
using System;
using System.Collections.Generic;
using System.Text;
using Ideal.Ideal.Common.Enums;
using Ideal.Ideal.Model;

namespace Ideal.Platform.Model
{
    /// <summary>
    ///  
    /// </summary>
    public class Ideal_UserModel : BaseModel
    {
        public Ideal_UserModel()
        {

            this.Owner_DB_TableName = "Ideal_User";
        }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ONLY_INSERT)]
        public string UserID { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string UserCode { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string DeptID { get; set; }

        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string DeptName { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string UserIDCard { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Sex { get; set; }
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string SexName { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Phone { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public decimal PoliticalStatus { get; set; }
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string PoliticalStatusName { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string QQ { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string WeChat { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Birthday { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public decimal Education { get; set; }
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string EducationName { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string AccumulationFund { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string SocialSecurity { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Salary { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string CheckType { get; set; }
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string CheckTypeName { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string HeadImg { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public decimal UserStatus { get; set; }
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string UserStatusName { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public decimal IDCardType { get; set; }
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string IDCardTypeName { get; set; }

        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string PostID { get; set; }
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string PostName { get; set; }
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string RoleID { get; set; }
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string RoleName { get; set; }
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string AccountName { get; set; }
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string PassWord { get; set; }
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public decimal AccountLevel { get; set; }
        
    }
}

