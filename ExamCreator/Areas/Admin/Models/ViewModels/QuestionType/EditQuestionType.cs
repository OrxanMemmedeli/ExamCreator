using ExamCreator.Areas.Admin.Models.ViewModels.BaseFields;

namespace ExamCreator.Areas.Admin.Models.ViewModels.QuestionType
{
    public class EditQuestionType : IBaseFieldsForEdit
    {
        public DateTime? CreatedDate { get ; set ; }
        public Guid? CreatUserId { get ; set ; }
        public Guid? ModifyUserId { get ; set ; }
        public Guid Id { get ; set ; }
        public bool Status { get ; set ; }
        public bool IsDeleted { get ; set ; }
        public DateTime? ModifyedDate { get ; set ; }

        public string ResponseType { get; set; }
        public double? ResponseCount { get; set; } = 0;
        public bool IsShowAnswer { get; set; } = false;
        public string Description { get; set; }
    }
}
