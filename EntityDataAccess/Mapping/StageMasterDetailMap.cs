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
    public class StageMasterDetailMap : EntityTypeConfiguration<StageMasterDetail>
    {
        public StageMasterDetailMap()
        {
            HasKey(t => t.ID);

            ////properties  
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.stage).IsRequired();
            Property(t => t.stage_detail).IsRequired();

            ToTable("t_stage_master");
        }
    }
}
