using ExamCreator.Areas.Admin.Models.ViewModels.BaseFields;
using System.ComponentModel.DataAnnotations;

namespace ExamCreator.Areas.Admin.Models.ViewModels.QuestionLevel
{
    public class EditQuestionLevel : IBaseFieldsForEdit
    {
        public DateTime? CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid? CreatUserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid? ModifyUserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? ModifyedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get; set; }
        public short Level { get; set; }
    }
}
