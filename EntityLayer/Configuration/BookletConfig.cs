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
    public class BookletConfig : IEntityTypeConfiguration<Booklet>
    {
        public void Configure(EntityTypeBuilder<Booklet> builder)
        {
            builder.HasOne(x => x.Grade)
                .WithMany(x => x.Booklets)
                .HasForeignKey(x => x.GradeId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Group)
                .WithMany(x => x.Booklets)
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Variant)
                .WithMany(x => x.Booklets)
                .HasForeignKey(x => x.VariantId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Exam)
                .WithMany(x => x.Booklets)
                .HasForeignKey(x => x.ExamId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Booklets)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.AcademicYear)
                .WithMany(x => x.Booklets)
                .HasForeignKey(x => x.AcademicYearId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.CreatUser)
                .WithMany(x => x.Booklets)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.ModifyUser)
                .WithMany(x => x.BookletsM)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
