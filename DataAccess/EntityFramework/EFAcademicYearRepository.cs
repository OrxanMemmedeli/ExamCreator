using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EFAcademicYearRepository : GenericRepository<AcademicYear>, IAcademicYearDal
    {
        public EFAcademicYearRepository(ECContext context) : base(context)
        {
        }
    }
}
