using Ideal.Ideal.Common.Enums;
using Ideal.Ideal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model
{
	/// <summary>
	///  
	/// </summary>
	public class Ideal_RoleModel : BaseModel
	{
		public Ideal_RoleModel()
		{

			this.Owner_DB_TableName = "Ideal_Role";
		}
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.ONLY_INSERT)]
		public string RoleID { get; set; }
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
		public string RoleName { get; set; }
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
		public string Note { get; set; }
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
