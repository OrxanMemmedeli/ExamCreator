namespace ExamCreator.Areas.Admin.Models.ViewModels.QuestionType
{
    public class CreateQuestionType
    {
        public string ResponseType { get; set; }
        public double? ResponseCount { get; set; } = 0;
        public bool IsShowAnswer { get; set; } = false;
        public string Description { get; set; }
    }
}
