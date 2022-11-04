using EntityLayer.Concrete.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Configuration
{
    public class BaseEntityConfig : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.HasOne(x => x.CreatUser)
                .WithMany(x => x.CreatUsers)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.ModifyUser)
                .WithMany(x => x.ModifyUsers)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
