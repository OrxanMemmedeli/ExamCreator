using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.BaseFields;

namespace ExamCreator.Areas.Admin.Models.ViewModels.UserType
{
    public class EditUserType 
    {
        public DateTime? CreatedDate { get; set; }
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifyedDate { get; set; }

        public string Type { get; set; }

    }
}
