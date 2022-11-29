using ExamCreator.Areas.Admin.Models.ViewModels.BaseFields;

namespace ExamCreator.Areas.Admin.Models.ViewModels.Response
{
    public class ListResponse : IBaseFiledsForList
    {
        public string? ModifyUserName { get; set; }
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifyedDate { get; set; }

        public string? Title { get; set; }
        public string? Content { get; set; }
        public bool IsTrue { get; set; }

        public string SubjectName { get; set; }
        public string QuestionName { get; set; }
        public string QuestionTypeName { get; set; }
        public string AcademicYearName { get; set; }
    }
}
