namespace ExamCreator.Areas.Admin.Models.ViewModels.Question
{
    public class CreateQuestion
    {
        public string Content { get; set; }

        public Guid SubjectId { get; set; }
        public Guid SectionId { get; set; }
        public Guid QuestionTypeId { get; set; }
        public Guid QuestionLevelId { get; set; }
        public Guid GradeId { get; set; }
        public Guid AcademicYearId { get; set; }
    }
}
