// <copyright file="Ideal_UserPostModel.cs" company=" Pvirtech Information Technology , Inc.">
//    Copyright (c) 2019 Pvirtech Information Technology , Inc. 
//    All Rights Reserved.
//    @文件名: Ideal_UserPostModel.cs
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
    public class Ideal_UserPostModel : BaseModel
    {
        public Ideal_UserPostModel()
        {

            this.Owner_DB_TableName = "Ideal_UserPost";
        }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ONLY_INSERT)]
        public string FlowID { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string UserID { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string PostID { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ONLY_INSERT)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ONLY_INSERT)]
        public string Creator { get; set; }
    }
}

