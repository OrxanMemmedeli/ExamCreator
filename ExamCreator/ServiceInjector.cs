using Business;
using Business.Abstract;
using Business.Concrete;
using Business.Validations;
using Business.Validations.DTOs.Grade;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.EntityFramework;
using DataAccess.Repositories;
using EntityLayer.Concrete;
using ExamCreator.Attributes;
using ExamCreator.Utilities.AreaControllerActionFinder;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using System.Configuration;
using System.Reflection.Metadata;

namespace ExamCreator
{
    public static class ServiceInjector
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<ECContext, ECContext>();

            services.AddScoped<IGradeService, GradeManager>().AddScoped<IGradeDal, EFGradeRepository>();
            services.AddScoped<IAcademicYearService, AcademicYearManager>().AddScoped<IAcademicYearDal, EFAcademicYearRepository>();
            services.AddScoped<IQuestionService, QuestionManager>().AddScoped<IQuestionDal, EFQuestionRepository>();
            services.AddScoped<IQuestionLevelService, QuestionLevelManager>().AddScoped<IQuestionLevelDal, EFQuestionLevelRepository>();
            services.AddScoped<IQuestionTypeService, QuestionTypeManager>().AddScoped<IQuestionTypeDal, EFQuestionTypeRepository>();
            services.AddScoped<IResponseService, ResponseManager>().AddScoped<IResponseDal, EFResponseRepository>();
            services.AddScoped<ISectionService, SectionManager>().AddScoped<ISectionDal, EFSectionRepository>();
            services.AddScoped<ISubjectService, SubjectManager>().AddScoped<ISubjectDal, EFSubjectRepository>();
            services.AddScoped<IUserTypeService, UserTypeManager>().AddScoped<IUserTypeDal, EFUserTypeRepository>();



            //services.AddScoped<RouteDataFilter>(provider => new RouteDataFilter(services));
            //services.AddScoped<RouteDataFilter>(provider => new RouteDataFilter() { _services = services});
            services.AddScoped<RouteDataFilter>();

        }

        public static void UseApp(this IApplicationBuilder app)
        {
            NameFinder.Find(app);
        }

        public static void Validators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<IValidatorReferance>();
            //services.AddFluentValidationClientsideAdapters(); // Clinet teref ucun auto mehdudiyyet

            services.AddFluentValidationAutoValidation();

        }
    }
}
