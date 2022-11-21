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
        public QuestionType()
        {
            this.Questions = new HashSet<Question>();
            this.Responses = new HashSet<Response>();
        }
        public string ResponseType { get; set; }
        public double? ResponseCount { get; set; } = 0;
        public bool IsShowAnswer { get; set; } = false;
        public string Description { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Response> Responses { get; set; }

    }
}
