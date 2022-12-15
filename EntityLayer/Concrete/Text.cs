using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Text : IEntity
    {
        public Text()
        {
            this.Questions = new HashSet<Question>();
        }
        public Guid? CreatUserId { get; set; }
        public Guid? ModifyUserId { get; set; }
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyedDate { get; set; }

        public AppUser? CreatUser { get; set; }
        public AppUser? ModifyUser { get; set; }

        public string Name { get; set; }
        public string Title { get; set; } = "Mətni oxuyun və {0} – {1} nömrəli tapşırıqları mətnə uyğun cavablayın.";
        public string Content { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
