using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObjects.Objects
{
    public class UserRoleDetail :BaseEntity
    {
        public int user_id { get; set; }
        public int role_id { get; set; }

    }
}
