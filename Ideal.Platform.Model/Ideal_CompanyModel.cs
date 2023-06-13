using Ideal.Ideal.Common.Enums;
using Ideal.Ideal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model
{
	public class Ideal_CompanyModel : BaseModel
	{
		public Ideal_CompanyModel()
		{

			this.Owner_DB_TableName = "Ideal_Company";
		}
		/// <summary>
		/// 公司ID
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.ONLY_INSERT)]
		public string CompanyID { get; set; }
		/// <summary>
		/// 公司编码
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.ONLY_INSERT)]
		public string CompanyCode { get; set; }
		/// <summary>
		/// 公司名称
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.ALL_SAVE)]
		public string CompanyName { get; set; }
		/// <summary>
		/// 创建时间
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.ONLY_INSERT)]
		public DateTime CreateTime { get; set; }
		/// <summary>
		/// 创建人
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.ONLY_INSERT)]
		public string Creator { get; set; }
	}
}
