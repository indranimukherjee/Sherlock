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
    public class StatusMasterDetailMap : EntityTypeConfiguration<StatusMasterDetail>
    {
        public StatusMasterDetailMap()
        {
            HasKey(t => t.ID);

            ////properties  
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.status_name).IsRequired();
            Property(t => t.status_desc).IsRequired();
            Property(t => t.creation_datetime).IsRequired();
            Property(t => t.last_updated_datetime).IsRequired();

            ToTable("t_status_type_master");
        }

    }
}
