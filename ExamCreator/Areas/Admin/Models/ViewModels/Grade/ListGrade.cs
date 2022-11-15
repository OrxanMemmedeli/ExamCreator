using EntityLayer.Concrete;

namespace ExamCreator.Areas.Admin.Models.ViewModels.Grade
{
    public class ListGrade
    {
        public Guid Id { get; set; } 
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyedDate { get; set; }
        public string? CreatUserName { get; set; }
        public string? ModifyUserName { get; set; }
        public string Name { get; set; }

    }
}
