using Ideal.Ideal.Common.Enums;
using Ideal.Ideal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model
{
    public class Ideal_RoleMenuModel :BaseModel
    {
		public Ideal_RoleMenuModel()
		{

			this.Owner_DB_TableName = "Ideal_RoleMenu";
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
		public string RoleID { get; set; }
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
		public string MenuID { get; set; }
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

		[DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
		public string MenuName { get; set; }
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
		public string MenuURL { get; set; }
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
		public string ParentMenuID { get; set; }
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
		public string Icon { get; set; }
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
		public decimal MenuSort { get; set; }
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
		public string IsDisplay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Component { get; set; }
    }
}
