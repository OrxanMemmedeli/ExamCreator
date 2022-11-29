using ExamCreator.Areas.Admin.Models.ViewModels.BaseFields;

namespace ExamCreator.Areas.Admin.Models.ViewModels.Response
{
    public class EditResponse : IBaseFieldsForEdit
    {
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatUserId { get; set; }
        public Guid? ModifyUserId { get; set; }
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifyedDate { get; set; }

        public string? Title { get; set; }
        public string? Content { get; set; }
        public bool IsTrue { get; set; }

        public Guid SubjectId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid QuestionTypeId { get; set; }
        public Guid AcademicYearId { get; set; }
    }
}
