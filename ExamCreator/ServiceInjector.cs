using Business;
using Business.Abstract;
using Business.Abstract.Exceptional;
using Business.Concrete;
using Business.Concrete.Exceptional;
using DataAccess.Abstract;
using DataAccess.Abstract.Exceptional;
using DataAccess.Concrete.Context;
using DataAccess.EntityFramework;
using DataAccess.EntityFramework.ExceptionalEntity;
using ExamCreator.Attributes;
using ExamCreator.Utilities.AreaControllerActionFinder;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace ExamCreator
{
    public static class ServiceInjector
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<ECContext, ECContext>();

            //a
            services.AddScoped<IAcademicYearService, AcademicYearManager>().AddScoped<IAcademicYearDal, EFAcademicYearRepository>();
            services.AddScoped<IAttachmentService, AttachmentManager>().AddScoped<IAttachmentDal, EFAttachmentRepository>();
            //b
            services.AddScoped<IBookletService, BookletManager>().AddScoped<IBookletDal, EFBookletRepository>();
            //c
            services.AddScoped<ICompanyService, CompanyManager>().AddScoped<ICompanyDal, EFCompanyRepository>();
            //e
            services.AddScoped<IExamService, ExamManager>().AddScoped<IExamDal, EFExamRepository>();
            services.AddScoped<IExamParameterService, ExamParameterManager>().AddScoped<IExamParameterDal, EFExamParameterRepository>();
            //g
            services.AddScoped<IGradeService, GradeManager>().AddScoped<IGradeDal, EFGradeRepository>();
            services.AddScoped<IGroupService, GroupManager>().AddScoped<IGroupDal, EFGroupRepository>();
            //p
            services.AddScoped<IPaymentService, PaymentManager>().AddScoped<IPaymentDal, EFPaymentRepository>();
            services.AddScoped<IPaymentSummaryService, PaymentSummaryManager>().AddScoped<IPaymentSummaryDal, EFPaymentSummaryRepository>();
            //q
            services.AddScoped<IQuestionService, QuestionManager>().AddScoped<IQuestionDal, EFQuestionRepository>();
            services.AddScoped<IQuestionLevelService, QuestionLevelManager>().AddScoped<IQuestionLevelDal, EFQuestionLevelRepository>();
            services.AddScoped<IQuestionParameterService, QuestionParameterManager>().AddScoped<IQuestionParameterDal, EFQuestionParameterRepository>();
            services.AddScoped<IQuestionTypeService, QuestionTypeManager>().AddScoped<IQuestionTypeDal, EFQuestionTypeRepository>();
            //r
            services.AddScoped<IResponseService, ResponseManager>().AddScoped<IResponseDal, EFResponseRepository>();
            services.AddScoped<IRoleUrlService, RoleUrlManager>().AddScoped<IRoleUrlDal, EFRoleUrlRespository>();
            //s
            services.AddScoped<ISectionService, SectionManager>().AddScoped<ISectionDal, EFSectionRepository>();
            services.AddScoped<ISubjectService, SubjectManager>().AddScoped<ISubjectDal, EFSubjectRepository>();
            services.AddScoped<ISubjectParameterService, SubjectParameterManager>().AddScoped<ISubjectParameterDal, EFSubjectParameterRepository>();
            services.AddScoped<ISysExceptionService, SysExceptionManager>().AddScoped<ISysExceptionDal, EFSysExceptionRepository>();
            //t
            services.AddScoped<ITextService, TextManager>().AddScoped<ITextDal, EFTextRepository>();
            //u
            services.AddScoped<IUserTypeService, UserTypeManager>().AddScoped<IUserTypeDal, EFUserTypeRepository>();
            //v
            services.AddScoped<IVariantService, VariantManager>().AddScoped<IVariantDal, EFVariantRepository>();



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
