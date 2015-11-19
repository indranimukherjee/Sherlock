using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityObjects.Objects;

namespace EntityDataAccess.Mapping
{
    class ProductDetailMap : EntityTypeConfiguration<ProductDetail>
    {
        public ProductDetailMap()
        {
            HasKey(t => t.ID);

            ////properties  
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.product_name);
            Property(t => t.parent_product_id);
            Property(t => t.product_deleted).IsRequired();
           


            ToTable("t_product_master");
        }
    }
}
