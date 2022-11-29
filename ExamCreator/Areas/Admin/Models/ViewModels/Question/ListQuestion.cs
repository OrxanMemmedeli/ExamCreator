using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.BaseFields;

namespace ExamCreator.Areas.Admin.Models.ViewModels.Question
{
    public class ListQuestion : IBaseFiledsForList
    {
        public string? ModifyUserName { get; set; }
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifyedDate { get; set; }


        public string Content { get; set; }

        public string SubjectName { get; set; }
        public string SectionName { get; set; }
        public string QuestionTypeName { get; set; }
        public string QuestionLevelName { get; set; }
        public string GradeName { get; set; }
        public string AcademicYearName { get; set; }
    }
}
