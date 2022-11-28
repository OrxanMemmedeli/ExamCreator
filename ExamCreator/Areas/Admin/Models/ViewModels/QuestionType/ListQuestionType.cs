using ExamCreator.Areas.Admin.Models.ViewModels.BaseFields;

namespace ExamCreator.Areas.Admin.Models.ViewModels.QuestionType
{
    public class ListQuestionType : IBaseFiledsForList
    {
        public string? ModifyUserName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? ModifyedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string ResponseType { get; set; }
        public double? ResponseCount { get; set; } = 0;
        public bool IsShowAnswer { get; set; } = false;
        public string Description { get; set; }
    }
}
