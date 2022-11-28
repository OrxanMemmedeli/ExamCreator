using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.BaseFields;

namespace ExamCreator.Areas.Admin.Models.ViewModels.Question
{
    public class EditQuestion : IBaseFieldsForEdit
    {
        public DateTime? CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid? CreatUserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid? ModifyUserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? ModifyedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Content { get; set; }

        public Guid SubjectId { get; set; }
        public Guid SectionId { get; set; }
        public Guid QuestionTypeId { get; set; }
        public Guid QuestionLevelId { get; set; }
        public Guid GradeId { get; set; }
        public Guid AcademicYearId { get; set; }
    }
}
