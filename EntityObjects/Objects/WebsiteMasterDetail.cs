using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObjects.Objects
{
    public class WebsiteMasterDetail : BaseEntity
    {
        public string website_address { get; set; }
        public string website_status { get; set; }

        public string website_name { get; set; }

    }
}
