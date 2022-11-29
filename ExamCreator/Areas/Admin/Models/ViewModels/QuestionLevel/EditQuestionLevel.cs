using ExamCreator.Areas.Admin.Models.ViewModels.BaseFields;
using System.ComponentModel.DataAnnotations;

namespace ExamCreator.Areas.Admin.Models.ViewModels.QuestionLevel
{
    public class EditQuestionLevel : IBaseFieldsForEdit
    {
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatUserId { get; set; }
        public Guid? ModifyUserId { get; set; }
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifyedDate { get; set; }
        public string Name { get; set; }
        public short Level { get; set; }
    }
}
