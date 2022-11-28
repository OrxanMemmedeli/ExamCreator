using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.BaseFields;

namespace ExamCreator.Areas.Admin.Models.ViewModels.Grade
{
    public class EditGrade : IBaseFieldsForEdit
    {
        public Guid Id { get; set; } 
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyedDate { get; set; }

        public Guid? CreatUserId { get; set; }
        public Guid? ModifyUserId { get; set; }

        public string Name { get; set; }

    }
}
