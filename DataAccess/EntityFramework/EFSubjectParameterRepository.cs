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
    public class EFSubjectParameterRepository : GenericRepository<SubjectParameter>, ISubjectParameterDal
    {
        public EFSubjectParameterRepository(ECContext context) : base(context)
        {
        }
    }
}
