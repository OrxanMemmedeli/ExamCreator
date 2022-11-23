﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
            this.Grades = new HashSet<Grade>();
            this.AcademicYears = new HashSet<AcademicYear>();
            this.QuestionLevels = new HashSet<QuestionLevel>();
            this.Questions = new HashSet<Question>();
            this.QuestionTypes = new HashSet<QuestionType>();
            this.Responses = new HashSet<Response>();
            this.Subjects = new HashSet<Subject>();
            this.Sections = new HashSet<Section>();

            this.GradesM = new HashSet<Grade>();
            this.AcademicYearsM = new HashSet<AcademicYear>();
            this.QuestionLevelsM = new HashSet<QuestionLevel>();
            this.QuestionsM = new HashSet<Question>();
            this.QuestionTypesM = new HashSet<QuestionType>();
            this.ResponsesM = new HashSet<Response>();
            this.SubjectsM = new HashSet<Subject>();
            this.SectionsM = new HashSet<Section>();
        }

        public string FullName { get; set; }
        public bool ImageUrl { get; set; }
        public bool Status { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public Guid? UserTypeId { get; set; }

        public UserType? UserType { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        public ICollection<Grade> Grades { get; set; }
        public ICollection<AcademicYear> AcademicYears { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<QuestionLevel> QuestionLevels { get; set; }
        public ICollection<QuestionType> QuestionTypes { get; set; }
        public ICollection<Response> Responses { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Section> Sections { get; set; }

        public ICollection<Grade> GradesM { get; set; }
        public ICollection<AcademicYear> AcademicYearsM { get; set; }
        public ICollection<Question> QuestionsM { get; set; }
        public ICollection<QuestionLevel> QuestionLevelsM { get; set; }
        public ICollection<QuestionType> QuestionTypesM { get; set; }
        public ICollection<Response> ResponsesM { get; set; }
        public ICollection<Subject> SubjectsM { get; set; }
        public ICollection<Section> SectionsM { get; set; }
    }
}
