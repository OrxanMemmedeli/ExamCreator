using ExamCreator.Areas.Admin.Models.ViewModels.BaseFields;

namespace ExamCreator.Areas.Admin.Models.ViewModels.Section
{
    public class EditSection : IBaseFieldsForEdit
    {
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatUserId { get; set; }
        public Guid? ModifyUserId { get; set; }
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifyedDate { get; set; }

        public string Name { get; set; }

        public Guid SubjectId { get; set; }
    }
}
