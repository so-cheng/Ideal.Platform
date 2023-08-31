using Ideal.Ideal.Common.Enums;
using Ideal.Ideal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model
{
    public class Ideal_SystemModel : BaseModel
    {
        public Ideal_SystemModel()
        {

            this.Owner_DB_TableName = "Ideal_System";
        }

        [DbFieldAttribute(DbFieldMode.PRIMARY_KEY)]
        public string SystemID { get; set; }

        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string SystemName { get; set; }
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string SystemCode { get; set; }

        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string CallbackUrl { get; set; }

        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string CompanyID { get; set; }

        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string CompanyName { get; set; }

        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public int Sort { get; set; }

        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Note { get; set; }
        
    }
}
