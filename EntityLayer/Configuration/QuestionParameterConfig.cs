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
    public class QuestionParameterConfig : IEntityTypeConfiguration<QuestionParameter>
    {
        public void Configure(EntityTypeBuilder<QuestionParameter> builder)
        {
            builder.HasOne(x => x.QuestionType)
                .WithMany(x => x.QuestionParameters)
                .HasForeignKey(x => x.QuestionTypeId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.SubjectParameter)
                .WithMany(x => x.QuestionParameters)
                .HasForeignKey(x => x.SubjectParameterId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.CreatUser)
                .WithMany(x => x.QuestionParameters)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.ModifyUser)
                .WithMany(x => x.QuestionParametersM)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
