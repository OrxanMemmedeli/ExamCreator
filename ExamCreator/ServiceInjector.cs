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

            //services.AddTransient<IGenericService<Grade>, GenericManager<Grade>>()
            //    .AddTransient<IGenericDal<Grade>, GenericRepository<Grade>> ();
        }

        public static void Validators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<BaseEntity>, BaseEntityValidator>();
            services.AddTransient<IValidator<Grade>, GradeValidator>();
        }
    }
}
