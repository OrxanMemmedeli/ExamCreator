using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.EntityFramework;
using DataAccess.Repositories;
using EntityLayer.Concrete;

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
    }
}
