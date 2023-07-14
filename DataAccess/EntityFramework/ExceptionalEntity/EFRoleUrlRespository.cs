using DataAccess.Abstract.Exceptional;
using DataAccess.Concrete.Context;
using DataAccess.Repositories;
using EntityLayer.Concrete.ForRoles;

namespace DataAccess.EntityFramework.ExceptionalEntity
{
    public class EFRoleUrlRespository : GenericBaseRepository<RoleUrl>, IRoleUrlDal
    {
        public EFRoleUrlRespository(ECContext context) : base(context)
        {
        }
    }
}
