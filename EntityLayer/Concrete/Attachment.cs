using CoreLayer.Enums;
using EntityLayer.Concrete.Base;
using EntityLayer.Concrete.CombineEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Attachment : BaseEntityWithUser
    {
        public Attachment()
        {
            QuestionAttahments = new HashSet<QuestionAttahment>();
        }
        public AttachmentType ProductType { get; set; }
        public string FileName { get; set; }
        public string NewFileName { get; set; }
        public string FileExtention { get; set; }
        public string FilePath { get; set; }
        public string? ContentType { get; set; }

        public ICollection<QuestionAttahment> QuestionAttahments { get; set; }

    }
}
