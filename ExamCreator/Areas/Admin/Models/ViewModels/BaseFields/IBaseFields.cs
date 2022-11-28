namespace ExamCreator.Areas.Admin.Models.ViewModels.BaseFields
{
    public interface IBaseFields
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifyedDate { get; set; }
    }
}
