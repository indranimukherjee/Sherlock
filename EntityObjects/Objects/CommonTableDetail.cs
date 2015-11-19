using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObjects.Objects
{
   public class CommonTableDetail : BaseEntity
    {

        public string title { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string city { get; set; }
        public string postcode { get; set; }
        public string contact1 { get; set; }
        public string contact2 { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public int product_id { get; set; }
        public string ip_address { get; set; }
        public string source { get; set; }
        public string match_type { get; set; }
        public string keyword { get; set; }

        public int status_id { get; set; }
        public int website_id { get; set; }
      //public virtual MortgageTabledetail MortgageTabledetail { get; set; }


    }
}
