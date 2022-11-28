using ExamCreator.Areas.Admin.Models.ViewModels.BaseFields;

namespace ExamCreator.Areas.Admin.Models.ViewModels.Response
{
    public class ListResponse : IBaseFiledsForList
    {
        public string? ModifyUserName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? ModifyedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string? Title { get; set; }
        public string? Content { get; set; }
        public bool IsTrue { get; set; }

        public string SubjectName { get; set; }
        public string QuestionName { get; set; }
        public string QuestionTypeName { get; set; }
        public string AcademicYearName { get; set; }
    }
}
