using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.BaseFields;

namespace ExamCreator.Areas.Admin.Models.ViewModels.Question
{
    public class EditQuestion : IBaseFieldsForEdit
    {
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatUserId { get; set; }
        public Guid? ModifyUserId { get; set; }
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifyedDate { get; set; }

        public string Content { get; set; }

        public Guid SubjectId { get; set; }
        public Guid SectionId { get; set; }
        public Guid QuestionTypeId { get; set; }
        public Guid QuestionLevelId { get; set; }
        public Guid GradeId { get; set; }
        public Guid AcademicYearId { get; set; }
    }
}
