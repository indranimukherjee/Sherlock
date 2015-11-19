//using EntityObjects;
//using EntityObjects.Objects;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EntityObjects.Objects;

namespace EntityDataAccess.Mapping
{
    public class CommonTableDetailMap : EntityTypeConfiguration<CommonTableDetail>
    {
        public CommonTableDetailMap()
        {
            HasKey(t => t.ID);

            ////properties  
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.title).IsRequired();
            Property(t => t.first_name).IsRequired();
            Property(t => t.last_name).IsRequired();
            Property(t => t.city).IsRequired();
            Property(t => t.postcode).IsRequired();
            Property(t => t.contact1).IsRequired();
            Property(t => t.contact2).IsOptional();
            Property(t => t.address).IsRequired();
            Property(t => t.email).IsRequired();
            Property(t => t.product_id).IsRequired();
            Property(t => t.ip_address).IsRequired();
            Property(t => t.source).IsOptional();
            Property(t => t.match_type).IsOptional();
            Property(t => t.keyword).IsOptional();
            Property(t => t.status_id).IsRequired();
            Property(t => t.CreatedOn).IsRequired();
            Property(t => t.CreatedBy).IsRequired();
            Property(t => t.UpdatedOn).IsOptional();
            Property(t => t.UpdatedBy).IsOptional();
            Property(t => t.website_id).IsOptional();


            ToTable("t_common_leads");
        }
    }
}
