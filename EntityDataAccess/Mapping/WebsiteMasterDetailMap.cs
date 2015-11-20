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
    public class WebsiteMasterDetailMap : EntityTypeConfiguration<WebsiteMasterDetail>
    {
        public WebsiteMasterDetailMap()
        {
            HasKey(t => t.ID);

            ////properties  
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.website_address).IsRequired();
            Property(t => t.website_status).IsRequired();
            Property(t => t.website_name).IsRequired();

            ToTable("t_website_master");
        }
    }
}
