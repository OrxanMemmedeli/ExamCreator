using DataAccess.Abstract.Exceptional;
using DataAccess.Concrete.Context;
using DataAccess.Repositories;
using EntityLayer.Concrete.ExceptionalEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework.ExceptionalEntity
{
    public class EFPaymentRepository : GenericBaseRepository<Payment>, IPaymentDal
    {
        public EFPaymentRepository(ECContext context) : base(context)
        {
        }
    }
}
