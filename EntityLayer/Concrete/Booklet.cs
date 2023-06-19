using CoreLayer.Entities;
using EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Booklet : BaseEntityWithUser
    {
        //public Guid? CreatUserId { get; set; }
        //public Guid? ModifyUserId { get; set; }
        //public Guid Id { get; set; }
        //public bool Status { get; set; }
        //public bool IsDeleted { get; set; }
        //public DateTime? CreatedDate { get; set; }
        //public DateTime? ModifyedDate { get; set; }

        public Guid GradeId { get; set; }
        public Guid? GroupId { get; set; }
        public Guid VariantId { get; set; }
        public Guid ExamId { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid AcademicYearId { get; set; }


        public virtual Grade Grade { get; set; }
        public virtual Group Group { get; set; }
        public virtual Variant Variant { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual Company Company { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
        //public AppUser? CreatUser { get; set; }
        //public AppUser? ModifyUser { get; set; }

    }
}
