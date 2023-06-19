using EntityLayer.Concrete;
using EntityLayer.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Configuration
{
    public class QuestionConfig : BaseEntityWithUserConfig<Question>
    {
        public override void Configure(EntityTypeBuilder<Question> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Subject)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Section)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.SectionId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.QuestionType)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.QuestionTypeId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.QuestionLevel)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.QuestionLevelId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Grade)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.GradeId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Text)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.TextId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.AcademicYear)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.AcademicYearId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.CreatUser)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.ModifyUser)
                .WithMany(x => x.QuestionsM)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
