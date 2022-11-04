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
    public class ResponseConig : IEntityTypeConfiguration<Response>
    {
        public void Configure(EntityTypeBuilder<Response> builder)
        {
            builder.HasOne(x => x.Subject)
                .WithMany(x => x.Responses)
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Question)
                .WithMany(x => x.Responses)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.QuestionType)
                .WithMany(x => x.Responses)
                .HasForeignKey(x => x.QuestionTypeId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
