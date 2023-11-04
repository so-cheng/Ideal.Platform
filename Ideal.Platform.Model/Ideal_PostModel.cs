using Ideal.Ideal.Common.Enums;
using Ideal.Ideal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model
{
	public class Ideal_PostModel : BaseModel
	{
		public Ideal_PostModel()
		{

			this.Owner_DB_TableName = "Ideal_Post";
		}
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.PRIMARY_KEY)]
		public string PostID { get; set; }
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
		public string ParentPostID { get; set; }
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
		public string PostCode { get; set; }
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
		public string DeptID { get; set; }
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
		public string PostName { get; set; }
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
		public string PostDesc { get; set; }
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
		public decimal PostSalary { get; set; }
	}
}
