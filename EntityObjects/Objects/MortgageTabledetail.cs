using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObjects.Objects
{
   public class MortgageTabledetail : BaseEntity
    {
       
        public int lead_id { get; set; }
        public DateTime date_of_birth { get; set; }
        public int age { get; set; }
        public int employment_status { get; set; }
        public int period_term { get; set; }
        public int property_value { get; set; }
        public int loan_value { get; set; }
        public int current_debt { get; set; }
        public int property_type { get; set; }
        public int property_location { get; set; }
        public int credit_history { get; set; }
        public int annual_income { get; set; }
        public bool miss_any_loan { get; set; }
        public bool had_bankruptcy { get; set; }
        public bool applied_iva  { get; set; }


        public bool had_ccj { get; set; }
        public int rate_id { get; set; }

        public int repayment_id { get; set; }
     
       //public virtual CommonTableDetail CommonTableDetail { get; set; }
}
}
