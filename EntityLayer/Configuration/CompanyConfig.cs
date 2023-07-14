using EntityLayer.Concrete;
using EntityLayer.Configuration.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Configuration
{
    public class CompanyConfig : BaseEntityConfig<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.PaymentSummary)
                .WithOne(x => x.Company)
                .HasForeignKey<PaymentSummary>(x => x.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
