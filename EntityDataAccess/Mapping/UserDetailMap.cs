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
    class UserDetailMap : EntityTypeConfiguration<UserDetail>
    {
        public UserDetailMap()
        {
            HasKey(t => t.ID);

            //properties  
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.user_name).IsRequired();
            Property(t => t.first_name).IsRequired();
            Property(t => t.last_name).IsRequired();
            Property(t => t.password).IsRequired();
            Property(t => t.UpdatedOn).IsRequired();

            ToTable("t_user_master");
        }
    }
}
