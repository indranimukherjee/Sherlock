//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_buyer_product
    {
        public int buyer_product_id { get; set; }
        public int buyer_id { get; set; }
        public int product_id { get; set; }
        public int integration_type_id { get; set; }
        public int buyer_quota { get; set; }
        public string buyer_priority { get; set; }
        public System.DateTime start_date { get; set; }
        public System.DateTime end_date { get; set; }
        public int buyer_state { get; set; }
        public string buyer_payment_mode { get; set; }
        public string prepaid_order_amount { get; set; }
        public decimal product_price { get; set; }
        public decimal remaining_amount { get; set; }
    
        public virtual t_buyer_integration t_buyer_integration { get; set; }
        public virtual t_buyer_master t_buyer_master { get; set; }
        public virtual t_buyer_state t_buyer_state { get; set; }
        public virtual t_product_master t_product_master { get; set; }
    }
}
