// <copyright file="Ideal_AccountModel.cs" company=" Pvirtech Information Technology , Inc.">
//    Copyright (c) 2019 Pvirtech Information Technology , Inc. 
//    All Rights Reserved.
//    @文件名: Ideal_AccountModel.cs
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
    public class Ideal_AccountModel : BaseModel
    {
        public Ideal_AccountModel()
        {

            this.Owner_DB_TableName = "Ideal_Account";
            MenuList = new List<dynamic>(); 
        }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string AccountName { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string RoleID { get; set; }
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string RoleName { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string UserID { get; set; }
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string AccountStatus { get; set; }

        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string AccountStatusName { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string AccountLevel { get; set; }
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string AccountLevelName { get; set; }

        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public List<dynamic> MenuList { get; set; }

        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string Token { get; set; }
    }
}

