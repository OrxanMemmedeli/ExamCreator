using ExamCreator.Areas.Admin.Models.ViewModels.BaseFields;

namespace ExamCreator.Areas.Admin.Models.ViewModels.Subject
{
    public class ListSubject : IBaseFiledsForList
    {
        public string? ModifyUserName { get; set; }
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifyedDate { get; set; }

        public string Name { get; set; }
        public decimal? AmountForQuestion { get; set; }
    }
}
