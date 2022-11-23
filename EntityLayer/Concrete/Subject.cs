using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Subject:IEntity
    {
        public Subject()
        {
            this.Sections = new HashSet<Section>();
            this.Responses = new HashSet<Response>();
            this.Questions = new HashSet<Question>();
        }
        public string Name { get; set; }
        public decimal? AmountForQuestion{ get; set; }

        public ICollection<Section> Sections { get; set; }
        public ICollection<Response> Responses { get; set; }
        public ICollection<Question> Questions { get; set; }

        #region IEntity
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyedDate { get; set; }
        public Guid? CreatUserId { get; set; }
        public Guid? ModifyUserId { get; set; }

        public AppUser? CreatUser { get; set; }
        public AppUser? ModifyUser { get; set; }
        #endregion


    }
}
