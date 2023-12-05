using Ideal.Ideal.Common.Enums;
using Ideal.Ideal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model
{
    public class Ideal_DeptModel: BaseModel
    {
		public Ideal_DeptModel()
		{

			this.Owner_DB_TableName = "Ideal_Dept";
			Children = new List<Ideal_DeptModel>();

        }
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.PRIMARY_KEY)]
		public string DeptID { get; set; }
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
		public string DeptName { get; set; }
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
		public string DeptCode { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
		public string DeptType { get; set; }
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
		public string ParentDeptID { get; set; }
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
		public decimal Sort { get; set; }
		/// <summary>
		/// 
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
		public string Landline { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
		public string CompanyName { get; set; }

        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public List<Ideal_DeptModel> Children { get; set; }
    }
}
