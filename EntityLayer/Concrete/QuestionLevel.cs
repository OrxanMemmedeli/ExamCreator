using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class QuestionLevel : IEntity
    {
        public QuestionLevel()
        {
            this.Questions = new HashSet<Question>();
        }
        public string Name { get; set; }
        [Range(1, 5)]
        public short Level { get; set; }
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
