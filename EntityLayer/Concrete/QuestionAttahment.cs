using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class QuestionAttahment 
    {
        public Guid QuestionId { get; set; }
        public Guid AttachmentId { get; set; }

        public Question Question { get; set; }
        public Attachment Attachment { get; set; }
    }
}
