namespace ExamCreator.Areas.Admin.Models.ViewModels.BaseFields
{
    public interface IBaseFieldsForEdit : IBaseFields
    {
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatUserId { get; set; }
        public Guid? ModifyUserId { get; set; }
    }
}
