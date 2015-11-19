using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObjects.Objects
{
    public class UserDetail : BaseEntity
    {
        public string user_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string password { get; set; }

    }
}
