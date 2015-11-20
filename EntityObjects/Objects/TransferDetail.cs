using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObjects.Objects
{
   public class TransferDetail :BaseEntity
    {
        public DateTime generated_datetime { get; set; }
        public DateTime transfer_datetime { get; set; }
        public int buyer_id { get; set; }
        public int lead_id { get; set; }
        public int buyer_return_lead_id { get; set; }
        public string buyer_end_status { get; set; }
        public int status_id { get; set; }
        public string msg_returned { get; set; }

        

    }
}
