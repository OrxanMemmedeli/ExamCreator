using System.ComponentModel.DataAnnotations;

namespace ExamCreator.Areas.Admin.Models.ViewModels.QuestionLevel
{
    public class CreateQuestionLevel
    {
        public string Name { get; set; }
        public short Level { get; set; }
    }
}
