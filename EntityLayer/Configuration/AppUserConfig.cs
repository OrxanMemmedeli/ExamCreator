using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Configuration
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasOne(x => x.UserType)
                .WithMany(x => x.AppUsers)
                .HasForeignKey(x => x.UserTypeId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(x => x.AcademicYears)
                .WithOne(x => x.CreatUser)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(x => x.AcademicYearsM)
                .WithOne(x => x.ModifyUser)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

        }
    }
}
