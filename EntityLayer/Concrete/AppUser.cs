using Microsoft.AspNetCore.Http;
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
            this.Companies = new HashSet<Company>();
            this.Exams = new HashSet<Exam>();
            this.SubjectParameters = new HashSet<SubjectParameter>();
            this.ExamParameters = new HashSet<ExamParameter>();
            this.Texts = new HashSet<Text>();
            this.Variants = new HashSet<Variant>();
            this.QuestionParameters = new HashSet<QuestionParameter>();
            this.Booklets = new HashSet<Booklet>();
            this.Groups = new HashSet<Group>();
            this.Attachments = new HashSet<Attachment>();

            this.GradesM = new HashSet<Grade>();
            this.AcademicYearsM = new HashSet<AcademicYear>();
            this.QuestionLevelsM = new HashSet<QuestionLevel>();
            this.QuestionsM = new HashSet<Question>();
            this.QuestionTypesM = new HashSet<QuestionType>();
            this.ResponsesM = new HashSet<Response>();
            this.SubjectsM = new HashSet<Subject>();
            this.SectionsM = new HashSet<Section>();
            this.CompaniesM = new HashSet<Company>();
            this.ExamsM = new HashSet<Exam>();
            this.SubjectParametersM = new HashSet<SubjectParameter>();
            this.ExamParametersM = new HashSet<ExamParameter>();
            this.TextsM = new HashSet<Text>();
            this.VariantsM = new HashSet<Variant>();
            this.QuestionParametersM = new HashSet<QuestionParameter>();
            this.BookletsM = new HashSet<Booklet>();
            this.GroupsM = new HashSet<Group>();
            this.AttachmentsM = new HashSet<Attachment>();
        }

        public string FullName { get; set; }
        public bool ImageUrl { get; set; }
        public bool Status { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public Guid? UserTypeId { get; set; }

        public virtual UserType? UserType { get; set; }

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
        public ICollection<Company> Companies { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<SubjectParameter> SubjectParameters { get; set; }
        public ICollection<ExamParameter> ExamParameters { get; set; }
        public ICollection<Text> Texts { get; set; }
        public ICollection<Variant> Variants { get; set; }
        public ICollection<QuestionParameter> QuestionParameters { get; set; }
        public ICollection<Booklet> Booklets { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Attachment> Attachments { get; set; }



        public ICollection<Grade> GradesM { get; set; }
        public ICollection<AcademicYear> AcademicYearsM { get; set; }
        public ICollection<Question> QuestionsM { get; set; }
        public ICollection<QuestionLevel> QuestionLevelsM { get; set; }
        public ICollection<QuestionType> QuestionTypesM { get; set; }
        public ICollection<Response> ResponsesM { get; set; }
        public ICollection<Subject> SubjectsM { get; set; }
        public ICollection<Section> SectionsM { get; set; }
        public ICollection<Company> CompaniesM { get; set; }
        public ICollection<Exam> ExamsM { get; set; }
        public ICollection<SubjectParameter> SubjectParametersM { get; set; }
        public ICollection<ExamParameter> ExamParametersM { get; set; }
        public ICollection<Text> TextsM { get; set; }
        public ICollection<Variant> VariantsM { get; set; }
        public ICollection<QuestionParameter> QuestionParametersM { get; set; }
        public ICollection<Booklet> BookletsM { get; set; }
        public ICollection<Group> GroupsM { get; set; }
        public ICollection<Attachment> AttachmentsM { get; set; }

    }
}
