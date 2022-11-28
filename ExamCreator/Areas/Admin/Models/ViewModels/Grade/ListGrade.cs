using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.BaseFields;

namespace ExamCreator.Areas.Admin.Models.ViewModels.Grade
{
    public class ListGrade : IBaseFiledsForList
    {
        public Guid Id { get; set; } 
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifyedDate { get; set; }
        public string? ModifyUserName { get; set; }
        public string Name { get; set; }

    }
}
