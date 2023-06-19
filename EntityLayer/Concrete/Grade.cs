using CoreLayer.Entities;
using EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Grade : BaseEntityWithUser
    {
        public Grade()
        {
            this.Questions = new HashSet<Question>();
            this.Exams = new HashSet<Exam>();
            this.Booklets = new HashSet<Booklet>();
        }

        public string Name { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<Booklet> Booklets { get; set; }
    }
}
