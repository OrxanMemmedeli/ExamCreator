using EntityLayer.Concrete;
using EntityLayer.Concrete.Base;
using EntityLayer.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Context
{
    public class ECContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=161.97.166.102; Database=HilalDemoSecond; User Id=orxan; password=Ov!tBg@A2g2jA@Z; Trusted_Connection=False; MultipleActiveResultSets=true;");
        }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionLevel> QuestionLevels { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new QuestionConfig());
            builder.ApplyConfiguration(new ResponseConig());
            builder.ApplyConfiguration(new SectionConfig());
            builder.ApplyConfiguration(new BaseEntityConfig());

            // For Table Per Type
            builder.Entity<Grade>().ToTable("Grades");
            builder.Entity<Question>().ToTable("Questions");
            builder.Entity<QuestionLevel>().ToTable("QuestionLevels");
            builder.Entity<QuestionType>().ToTable("QuestionTypes");
            builder.Entity<Response>().ToTable("Responses");
            builder.Entity<Section>().ToTable("Sections");
            builder.Entity<Subject>().ToTable("Subjects");
            builder.Entity<UserType>().ToTable("UserTypes");

            base.OnModelCreating(builder);

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                if (data.State == EntityState.Added)
                {
                    data.Entity.Id = Guid.NewGuid();
                    data.Entity.Status = true;
                    data.Entity.IsDeleted = false;
                    data.Entity.CreatedDate = DateTime.Now;
                    data.Entity.CreatedDate = default(DateTime);
                    //data.Entity.CreatUserId = 
                }
                else if (data.State == EntityState.Modified)
                {
                    data.Entity.ModifyedDate = DateTime.Now;
                    //data.Entity.ModifyUserId =
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
