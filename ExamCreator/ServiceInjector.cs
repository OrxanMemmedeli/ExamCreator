using Business.Abstract;
using Business.Concrete;
using Business.Validations;
using Business.Validations.DTOs.Grade;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.EntityFramework;
using DataAccess.Repositories;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.Configuration;
using System.Reflection.Metadata;

namespace ExamCreator
{
    public static class ServiceInjector
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddTransient<ECContext, ECContext>();

            services.AddTransient<IGradeService, GradeManager>().AddTransient<IGradeDal, EFGradeRepository>();
            services.AddTransient<IAcademicYearService, AcademicYearManager>().AddTransient<IAcademicYearDal, EFAcademicYearRepository>();
            services.AddTransient<IQuestionService, QuestionManager>().AddTransient<IQuestionDal, EFQuestionRepository>();
            services.AddTransient<IQuestionLevelService, QuestionLevelManager>().AddTransient<IQuestionLevelDal, EFQuestionLevelRepository>();
            services.AddTransient<IQuestionTypeService, QuestionTypeManager>().AddTransient<IQuestionTypeDal, EFQuestionTypeRepository>();
            services.AddTransient<IResponseService, ResponseManager>().AddTransient<IResponseDal, EFResponseRepository>();
            services.AddTransient<ISectionService, SectionManager>().AddTransient<ISectionDal, EFSectionRepository>();
            services.AddTransient<ISubjectService, SubjectManager>().AddTransient<ISubjectDal, EFSubjectRepository>();
            services.AddTransient<IUserTypeService, UserTypeManager>().AddTransient<IUserTypeDal, EFUserTypeRepository>();

        }

        public static void Validators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<GradeCreateDTOValidator>();

        }
    }
}
