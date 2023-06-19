﻿using CoreLayer.Entities;
using EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Response : BaseEntityWithUser
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public bool IsTrue { get; set; }

        public Guid SubjectId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid QuestionTypeId { get; set; }
        public Guid AcademicYearId { get; set; }

        public virtual AcademicYear AcademicYear { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Question Question { get; set; }
        public virtual QuestionType QuestionType { get; set; }

        //#region IEntity
        //public Guid Id { get; set; } = Guid.NewGuid();
        //public bool Status { get; set; }
        //public bool IsDeleted { get; set; }
        //public DateTime? CreatedDate { get; set; }
        //public DateTime? ModifyedDate { get; set; }
        //public Guid? CreatUserId { get; set; }
        //public Guid? ModifyUserId { get; set; }

        //public AppUser? CreatUser { get; set; }
        //public AppUser? ModifyUser { get; set; }
        //#endregion

    }
}
