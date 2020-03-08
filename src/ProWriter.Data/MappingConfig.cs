using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWriter.Data
{
    
    public class UserSharedProjectMap : IEntityTypeConfiguration<UserSharedProject>
    {
        public void Configure(EntityTypeBuilder<UserSharedProject> builder)
        {
            builder.HasKey(x => new { x.UserId, x.ProjectId });
        }
    }

    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(x => new { x.UserId, x.RoleId });
        }
    }

}
