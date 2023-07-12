using EntityLayer.Concrete;
using EntityLayer.Concrete.CombineEntities;
using EntityLayer.Concrete.ExceptionalEntities;
using EntityLayer.Concrete.ForRoles;
using EntityLayer.Configuration;
using EntityLayer.Configuration.CombineConfigs;
using EntityLayer.Configuration.Exceptional;
using EntityLayer.Configuration.ForRoles;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Context
{
    public class ECContext : IdentityDbContext<AppUser, AppRole, Guid>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-TROAMS4; Database=HilalDemoSecond; Integrated Security = true; MultipleActiveResultSets = True", sqlServerOptions =>
            //{
            //    sqlServerOptions.EnableRetryOnFailure();
            //});

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                string computerName = Environment.MachineName;
                if (computerName == "DESKTOP-TROAMS4")
                {
                    optionsBuilder.UseSqlServer(@"Server=DESKTOP-TROAMS4; Database=HilalDemoSecond; Integrated Security=true; MultipleActiveResultSets=True");
                }
                else if (computerName == "ORXAN")
                {
                    optionsBuilder.UseSqlServer(@"Server=ORXAN\SQLEXPRESS01; Database=Demo; Integrated Security = true; MultipleActiveResultSets = True");
                }
            }
            else if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                optionsBuilder.UseSqlServer(@"Server=161.97.166.102; Database=HilalDemoSecond; User Id=orxan; password=Ov!tBg@A2g2jA@Z; Trusted_Connection=False; MultipleActiveResultSets=true;");
            }
        }



        #region Base Entities
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<PaymentSummary> PaymentSummary { get; set; }

        #endregion



        #region Base Entities With User
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Booklet> Booklets { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamParameter> ExamParameters { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionLevel> QuestionLevels { get; set; }
        public DbSet<QuestionParameter> QuestionParameters { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectParameter> SubjectParameters { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        #endregion



        #region Simple Entities
        public DbSet<RoleUrl> RoleUrls { get; set; }
        public DbSet<SysException> SysExceptions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        #endregion



        #region Combination Entities
        public DbSet<QuestionAttahment> QuestionAttahments { get; set; }
        public DbSet<CombineRoleUrl> CombineRoleUrls { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }
        #endregion



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Manually configure 
            AddConfigurations(builder);



        }


        #region SaveChangesAsync
        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    var datas = ChangeTracker.Entries<IEntity>();
        //    var baseDatas = ChangeTracker.Entries<IEntityBase>();

        //    foreach (var data in datas)
        //    {
        //        if (data.State == EntityState.Added)
        //        {
        //            data.Entity.Id = Guid.NewGuid();
        //            data.Entity.Status = true;
        //            data.Entity.IsDeleted = false;
        //            data.Entity.CreatedDate = DateTime.Now;
        //            data.Entity.ModifyedDate = default(DateTime);
        //            //data.Entity.CreatUserId = 
        //        }

        //        if (data.State == EntityState.Modified)
        //        {
        //            data.Entity.ModifyedDate = DateTime.Now;

        //            //data.Entity.ModifyUserId =
        //        }
        //    }


        //    foreach (var data in baseDatas)
        //    {
        //        if (data.State == EntityState.Added)
        //        {
        //            data.Entity.Id = Guid.NewGuid();
        //            data.Entity.Status = true;
        //            data.Entity.IsDeleted = false;
        //            data.Entity.CreatedDate = DateTime.Now;
        //            data.Entity.ModifyedDate = default(DateTime);
        //        }

        //        if (data.State == EntityState.Modified)
        //        {
        //            data.Entity.ModifyedDate = DateTime.Now;
        //        }
        //    }

        //    return await base.SaveChangesAsync(cancellationToken);

        //}
        #endregion

        static void AddConfigurations(ModelBuilder builder)
        {
            //base
            builder.ApplyConfiguration(new AcademicYearConfig());
            builder.ApplyConfiguration(new AppUserConfig());
            builder.ApplyConfiguration(new BookletConfig());
            builder.ApplyConfiguration(new CompanyConfig());
            builder.ApplyConfiguration(new ExamConfig());
            builder.ApplyConfiguration(new ExamParameterConfig());
            builder.ApplyConfiguration(new GradeConfig());
            builder.ApplyConfiguration(new GroupConfig());
            builder.ApplyConfiguration(new PaymentSummaryConfig());
            builder.ApplyConfiguration(new QuestionConfig());
            builder.ApplyConfiguration(new QuestionLevelConfig());
            builder.ApplyConfiguration(new QuestionParameterConfig());
            builder.ApplyConfiguration(new QuestionTypeConfig());
            builder.ApplyConfiguration(new ResponseConig());
            builder.ApplyConfiguration(new SectionConfig());
            builder.ApplyConfiguration(new SubjectConfig());
            builder.ApplyConfiguration(new SubjectParameterConfig());
            builder.ApplyConfiguration(new TextConfig());
            builder.ApplyConfiguration(new UserTypeConfig());
            builder.ApplyConfiguration(new VariantConfig());
            builder.ApplyConfiguration(new AttachmentConfig());
            
            //simple 
            builder.ApplyConfiguration(new PaymentConfig());

            //combination
            builder.ApplyConfiguration(new QuestionAttahmentConfig());
            builder.ApplyConfiguration(new CombineRoleUrlConfig());
            builder.ApplyConfiguration(new CompanyUserConfig());
        }

    }


}
