using EntityLayer.Concrete.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Configuration.Base
{
    public class BaseEntityWithUserConfig<T> : BaseEntityConfig<T> where T : BaseEntityWithUser
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            //builder.Property(x => x.CreatUserId).ValueGeneratedOnAdd(); 
            //builder.Property(x => x.ModifyUser).ValueGeneratedOnAddOrUpdate(); 

        }
    }
}
