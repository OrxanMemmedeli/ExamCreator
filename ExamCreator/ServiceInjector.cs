using Business.Abstract;
using Business.Concrete;
using Business.Validations;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.EntityFramework;
using DataAccess.Repositories;
using EntityLayer.Concrete;
using EntityLayer.Concrete.Base;
using ExamCreator.Areas.Admin.Models.ViewModels.Grade;
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

        }

        public static void Validators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<BaseEntityValidator>();
            services.AddValidatorsFromAssemblyContaining<GradeValidator>();
            services.AddValidatorsFromAssemblyContaining<QuestionLevelValidator>();
            services.AddValidatorsFromAssemblyContaining<QuestionTypeValidator>();
            services.AddValidatorsFromAssemblyContaining<QuestionValidator>();
            services.AddValidatorsFromAssemblyContaining<ResponseValidator>();
            services.AddValidatorsFromAssemblyContaining<SectionValidator>();
            services.AddValidatorsFromAssemblyContaining<SubjectValidator>();
            services.AddValidatorsFromAssemblyContaining<UserTypeValidator>();

        }
    }
}
