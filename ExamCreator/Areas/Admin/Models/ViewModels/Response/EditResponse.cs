﻿using ExamCreator.Areas.Admin.Models.ViewModels.BaseFields;

namespace ExamCreator.Areas.Admin.Models.ViewModels.Response
{
    public class EditResponse : IBaseFieldsForEdit
    {
        public DateTime? CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid? CreatUserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid? ModifyUserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? ModifyedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string? Title { get; set; }
        public string? Content { get; set; }
        public bool IsTrue { get; set; }

        public Guid SubjectId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid QuestionTypeId { get; set; }
        public Guid AcademicYearId { get; set; }
    }
}