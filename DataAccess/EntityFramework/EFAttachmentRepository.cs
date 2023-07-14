using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.Repositories;
using EntityLayer.Concrete;

namespace DataAccess.EntityFramework
{
    public class EFAttachmentRepository : GenericRepository<Attachment>, IAttachmentDal
    {
        public EFAttachmentRepository(ECContext context) : base(context)
        {
        }
    }
}
