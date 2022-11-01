using EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class QuestionType : BaseEntity
    {
        public string ResponseType { get; set; }
        public string Description { get; set; }
    }
}
