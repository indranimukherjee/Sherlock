using EntityObjects.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDataAccess.Mapping
{
    public class ProductWebsiteDetailMap : EntityTypeConfiguration<ProductWebsiteDetail>
    {

        public ProductWebsiteDetailMap()
        {
            HasKey(t => t.ID);

            ////properties  
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.product_id).IsRequired();
            Property(t => t.website_id).IsRequired();



            ToTable("t_product_website");
        }
    }
}
