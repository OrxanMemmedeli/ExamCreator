using CoreLayer.Entities;
using EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class QuestionLevel : BaseEntityWithUser
    {
        public QuestionLevel()
        {
            this.Questions = new HashSet<Question>();
        }
        public string Name { get; set; }
        [Range(1, 5)]
        public short Level { get; set; }
        public ICollection<Question> Questions { get; set; }

    }
}
