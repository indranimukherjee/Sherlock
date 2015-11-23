using EntityObjects.UtilityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObjects.Objects
{
   public class CommonTableDetail : BaseEntity
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int ProductMasterId { get; set; }
        public string IpAddress { get; set; }
        public string Source { get; set; }
        public string MatchType { get; set; }
        public string Keyword { get; set; }
        public LeadStatusEnum Status { get; set; }
        public int WebsiteMasterId { get; set; }
        public string ProductName { get; set; }

        public virtual WebsiteMasterDetail WebsiteMaster { get; set; }
        //public virtual StatusMaster StatusMaster { get; set; }
        public virtual ProductDetail ProductMaster { get; set; }
        public virtual UserDetail UserMaster { get; set; }
        //public virtual UserMaster UpdatedByUsers { get; set; }

        public virtual ICollection<CommonTableDetailLog> CommonLeadLogs { get; set; }
        public virtual ICollection<MortgageTabledetail> MortgageLeads { get; set; }
   
     

     


    }
}
