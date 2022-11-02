using EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Grade : BaseEntity
    {
        public Grade()
        {
            this.Questions = new HashSet<Question>();
        }

        public string Name { get; set; }

        public ICollection<Question> Questions { get; set; }

    }
}
