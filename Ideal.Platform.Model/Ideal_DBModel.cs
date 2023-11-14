using Ideal.Ideal.Common.Enums;
using Ideal.Ideal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model
{
    public class Ideal_DBModel:BaseModel
    {
        public Ideal_DBModel()
        {

            this.Owner_DB_TableName = "Ideal_DB";
        }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.PRIMARY_KEY)]
        public string DBID { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string DBName { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string ConnectionString { get; set; }

    }
}
