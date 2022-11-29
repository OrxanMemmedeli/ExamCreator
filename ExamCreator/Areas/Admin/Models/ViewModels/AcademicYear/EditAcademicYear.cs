using ExamCreator.Areas.Admin.Models.ViewModels.BaseFields;

namespace ExamCreator.Areas.Admin.Models.ViewModels.AcademicYear
{
    public class EditAcademicYear : IBaseFieldsForEdit
    {
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatUserId { get; set; }
        public Guid? ModifyUserId { get; set; }
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifyedDate { get; set; }

        public string Name { get; set; }
    }
}
