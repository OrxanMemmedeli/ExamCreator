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
    public class QuestionAttahmentConfig : IEntityTypeConfiguration<QuestionAttahment>
    {
        public void Configure(EntityTypeBuilder<QuestionAttahment> builder)
        {
            builder.HasKey(x => new { x.QuestionId, x.AttachmentId });
            builder.HasOne<Question>(x => x.Question).WithMany(x => x.QuestionAttahments).HasForeignKey(x => x.QuestionId);
            builder.HasOne<Attachment>(x => x.Attachment).WithMany(x => x.QuestionAttahments).HasForeignKey(x => x.AttachmentId);
        }
    }
}
