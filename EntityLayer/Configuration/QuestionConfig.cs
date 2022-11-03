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
    public class QuestionConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.AppUserId);

            builder.HasOne(x => x.Subject)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.SubjectId);

            builder.HasOne(x => x.Section)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.SectionId);

            builder.HasOne(x => x.QuestionType)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.QuestionTypeId);

            builder.HasOne(x => x.QuestionLevel)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.QuestionLevelId);

            builder.HasOne(x => x.Grade)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.GradeId);
        }
    }
}
