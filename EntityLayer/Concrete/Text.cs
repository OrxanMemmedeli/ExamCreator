using CoreLayer.Entities;
using EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Text : BaseEntityWithUser
    {
        public Text()
        {
            this.Questions = new HashSet<Question>();
        }

        public string Name { get; set; }
        public string Title { get; set; } = "Mətni oxuyun və {0} – {1} nömrəli tapşırıqları mətnə uyğun cavablayın.";
        public string Content { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
