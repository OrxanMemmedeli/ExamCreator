using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Configuration
{
    public class AcademicYearConfig : IEntityTypeConfiguration<AcademicYear>
    {
        public void Configure(EntityTypeBuilder<AcademicYear> builder)
        {
            builder.HasOne(x => x.CreatUser)
                .WithMany(x => x.AcademicYears)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.ModifyUser)
                .WithMany(x => x.AcademicYearsM)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
