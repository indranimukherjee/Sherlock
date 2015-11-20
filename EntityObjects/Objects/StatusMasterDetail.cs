using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObjects.Objects
{
    public class StatusMasterDetail : BaseEntity
    {
        public string status_name { get; set; }
        public string status_desc { get; set; }
        public DateTime creation_datetime { get; set; }
        public DateTime last_updated_datetime { get; set; }

    }
}
