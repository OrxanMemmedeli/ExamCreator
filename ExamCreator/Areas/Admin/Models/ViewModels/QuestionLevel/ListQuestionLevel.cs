using ExamCreator.Areas.Admin.Models.ViewModels.BaseFields;
using System.ComponentModel.DataAnnotations;

namespace ExamCreator.Areas.Admin.Models.ViewModels.QuestionLevel
{
    public class ListQuestionLevel : IBaseFiledsForList
    {
        public string? ModifyUserName { get; set; }
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifyedDate { get; set; }
        public string Name { get; set; }
        public short Level { get; set; }
    }
}
