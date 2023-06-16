using EntityLayer.Concrete;
using EntityLayer.Configuration.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Configuration
{
    public class UserTypeConfiguration : BaseEntityConfiguration<UserType>
    {
        public override void Configure(EntityTypeBuilder<UserType> builder)
        {
            base.Configure(builder);
        }
    }
}
