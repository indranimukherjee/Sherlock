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
    
    public partial class t_mortgage_period_term
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_mortgage_period_term()
        {
            this.t_buyer_mortgage_criteria = new HashSet<t_buyer_mortgage_criteria>();
            this.t_buyer_mortgage_face = new HashSet<t_buyer_mortgage_face>();
            this.t_mortgage_lead = new HashSet<t_mortgage_lead>();
            this.t_mortgage_lead_log = new HashSet<t_mortgage_lead_log>();
        }
    
        public int period_term { get; set; }
        public string term_name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_buyer_mortgage_criteria> t_buyer_mortgage_criteria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_buyer_mortgage_face> t_buyer_mortgage_face { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_mortgage_lead> t_mortgage_lead { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_mortgage_lead_log> t_mortgage_lead_log { get; set; }
    }
}
