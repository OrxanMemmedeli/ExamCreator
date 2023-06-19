using CoreLayer.Entities;
using EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Subject : BaseEntityWithUser
    {
        public Subject()
        {
            this.Sections = new HashSet<Section>();
            this.Responses = new HashSet<Response>();
            this.Questions = new HashSet<Question>();
            this.SubjectParameters = new HashSet<SubjectParameter>();
        }
        public string Name { get; set; }
        public decimal? AmountForQuestion { get; set; }

        public ICollection<Section> Sections { get; set; }
        public ICollection<Response> Responses { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<SubjectParameter> SubjectParameters { get; set; }

    }
}
