using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AcademicYear : IEntity
    {
        public AcademicYear()
        {
            this.Questions = new HashSet<Question>();
            this.Responses = new HashSet<Response>();
            this.Booklets = new HashSet<Booklet>();

        }
        public string Name { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Response> Responses { get; set; }
        public ICollection<Booklet> Booklets { get; set; }


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
