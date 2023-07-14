using DataAccess.Abstract.Exceptional;
using DataAccess.Concrete.Context;
using DataAccess.Repositories;
using EntityLayer.Concrete;

namespace DataAccess.EntityFramework.ExceptionalEntity
{
    public class EFSysExceptionRepository : GenericBaseRepository<SysException>, ISysExceptionDal
    {
        public EFSysExceptionRepository(ECContext context) : base(context)
        {
        }
    }
}
