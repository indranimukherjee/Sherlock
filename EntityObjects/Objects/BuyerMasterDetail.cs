using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObjects.Objects
{
    public class BuyerMasterDetail : BaseEntity
    {
        public string buyer_name { get; set; }
        public string buyer_address { get; set; }
        public string buyer_pincode { get; set; }
        public string buyer_poc_name { get; set; }
        public string buyer_contact_number { get; set; }
        public string buyer_poc_contact_number { get; set; }
        public string buyer_type { get; set; }
        public string ico_no { get; set; }

        public string fca_no { get; set; }
        public DateTime ico_exp_date { get; set; }
        public string company_registration_no { get; set; }

    }
}
