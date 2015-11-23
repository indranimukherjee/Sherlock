using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObjects.Objects
{
   public class MortgageTabledetail : BaseEntity
    {

        public int LeadId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? Age { get; set; }
        public int EmploymentStatus { get; set; }
        public int PeriodTerm { get; set; }
        public int PropertyValue { get; set; }
        public int LoanValue { get; set; }
        public int CurrentDebt { get; set; }
        public int PropertyType { get; set; }
        public int PropertyLocation { get; set; }
        public int CreditHistory { get; set; }
        public int AnnualIncome { get; set; }
        public bool MissAnyLoan { get; set; }
        public bool HadBankruptcy { get; set; }
        public bool AppliedIva { get; set; }
        public bool HadCcj { get; set; }
        public int RateId { get; set; }
        public int RepaymentId { get; set; }



        public virtual ICollection<MortgageTableDetailLog> MortgageLeadLog { get; set; }

        public virtual UserDetail UserMaster { get; set; }
        public virtual UserDetail UpdatedByUsers { get; set; }
        public virtual CommonTableDetail CommonLead { get; set; }

       
}
}
