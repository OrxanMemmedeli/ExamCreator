using EntityLayer.Concrete.CombineEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Configuration.CombineConfigs
{
    public class CompanyUserConfig : IEntityTypeConfiguration<CompanyUser>
    {
        public void Configure(EntityTypeBuilder<CompanyUser> builder)
        {
            builder.HasKey(x => new { x.CompanyId, x.AppUserId });
            builder.HasOne(x => x.Company).WithMany(x => x.CompanyUsers).HasForeignKey(x => x.CompanyId);
            builder.HasOne(x => x.AppUser).WithMany(x => x.CompanyUsers).HasForeignKey(x => x.AppUserId);
        }
    }
}
