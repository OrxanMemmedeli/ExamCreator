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
    public class PaymentSummaryConfig : BaseEntityConfig<PaymentSummary>
    {
        public override void Configure(EntityTypeBuilder<PaymentSummary> builder)
        {
            base.Configure(builder);

        }
    }
}
