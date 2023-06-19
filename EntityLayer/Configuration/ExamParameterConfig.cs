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
    public class ExamParameterConfig : BaseEntityWithUserConfig<ExamParameter>
    {
        public override void Configure(EntityTypeBuilder<ExamParameter> builder)
        {

            base.Configure(builder);

            builder.HasOne(x => x.CreatUser)
                .WithMany(x => x.ExamParameters)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.ModifyUser)
                .WithMany(x => x.ExamParametersM)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
