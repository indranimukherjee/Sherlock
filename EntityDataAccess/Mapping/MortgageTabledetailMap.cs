using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EntityObjects.Objects;

namespace EntityDataAccess.Mapping
{
    class MortgageTabledetailMap : EntityTypeConfiguration<MortgageTabledetail>
    {
        public MortgageTabledetailMap()
        {
            HasKey(t => t.ID);

            ////properties  
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.lead_id).IsRequired();
            Property(t => t.date_of_birth).IsRequired();
            Property(t => t.age).IsRequired();
            Property(t => t.employment_status).IsRequired();
            Property(t => t.period_term).IsRequired();
            Property(t => t.property_value).IsRequired();
            Property(t => t.loan_value).IsRequired();
            Property(t => t.current_debt).IsRequired();
            Property(t => t.property_type).IsRequired();
            Property(t => t.property_location).IsRequired();
            Property(t => t.credit_history).IsRequired();
            Property(t => t.annual_income).IsRequired();
            Property(t => t.miss_any_loan).IsRequired();
            Property(t => t.had_bankruptcy).IsRequired();
            Property(t => t.applied_iva).IsRequired();
            Property(t => t.had_ccj).IsRequired();
            Property(t => t.rate_id).IsRequired();
            Property(t => t.repayment_id).IsRequired();
            Property(t => t.CreatedOn).IsRequired();
            Property(t => t.CreatedBy).IsRequired();
            Property(t => t.UpdatedOn).IsOptional();
            Property(t => t.UpdatedBy).IsOptional();


            ToTable("t_mortgage_lead");
        }
    }
}
