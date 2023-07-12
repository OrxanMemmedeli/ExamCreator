using Business.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AttachmentManager : IAttachmentService
    {
        private readonly IAttachmentDal _attachmentDal;

        public AttachmentManager(IAttachmentDal attachmentDal)
        {
            _attachmentDal = attachmentDal;
        }

        public async Task Delete(Attachment t)
        {
            await _attachmentDal.Delete(t);
            await _attachmentDal.SaveAsync();
        }

        public IQueryable<Attachment> GetAllAsnyc(params Expression<Func<Attachment, object>>[] includes)
        {
            return _attachmentDal.GetAllAsnyc(includes);
        }

        public IQueryable<Attachment> GetAllAsnyc(Expression<Func<Attachment, bool>> filter, params Expression<Func<Attachment, object>>[] includes)
        {
            return _attachmentDal.GetAllAsnyc(filter, includes);
        }

        public async Task<Attachment> GetByAsnyc(Expression<Func<Attachment, bool>> filter, params Expression<Func<Attachment, object>>[] includes)
        {
            return await _attachmentDal.GetByAsnyc(filter, includes);
        }

        public async Task<Attachment> GetByIdAsnyc(Guid id)
        {
            return await _attachmentDal.GetByIdAsnyc(id);
        }

        public async Task Insert(Attachment t)
        {
            await _attachmentDal.Insert(t);
            await _attachmentDal.SaveAsync();
        }

        public async Task Remove(Attachment t)
        {
            await _attachmentDal.Remove(t);
            await _attachmentDal.SaveAsync();
        }

        public async Task Update(Attachment t, Action<EntityEntry<Attachment>> rules = null)
        {
            await _attachmentDal.Update(t, rules);
            await _attachmentDal.SaveAsync();
        }
    }
}
