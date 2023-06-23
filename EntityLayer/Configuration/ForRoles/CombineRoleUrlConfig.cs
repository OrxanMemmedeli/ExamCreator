using EntityLayer.Concrete;
using EntityLayer.Concrete.ForRoles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Configuration.ForRoles
{
    public class CombineRoleUrlConfig : IEntityTypeConfiguration<CombineRoleUrl>
    {
        public void Configure(EntityTypeBuilder<CombineRoleUrl> builder)
        {
            builder.HasKey(x => new { x.AppRoleId, x.RoleUrlId });
            builder.HasOne<RoleUrl>(x => x.RoleUrl).WithMany(x => x.CombineRoleUrls).HasForeignKey(x => x.RoleUrlId);
            builder.HasOne<AppRole>(x => x.AppRole).WithMany(x => x.CombineRoleUrls).HasForeignKey(x => x.AppRoleId);
        }
    }
}
