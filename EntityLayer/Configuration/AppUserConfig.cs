﻿using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Configuration
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasOne(x => x.UserType)
                .WithMany(x => x.AppUsers)
                .HasForeignKey(x => x.UserTypeId)
                .OnDelete(DeleteBehavior.ClientCascade);



            builder.HasMany(x => x.AcademicYears)
                .WithOne(x => x.CreatUser)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(x => x.AcademicYearsM)
                .WithOne(x => x.ModifyUser)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);


            builder.HasMany(x => x.Grades)
                .WithOne(x => x.CreatUser)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(x => x.GradesM)
                .WithOne(x => x.ModifyUser)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);


            builder.HasMany(x => x.Questions)
                .WithOne(x => x.CreatUser)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(x => x.QuestionsM)
                .WithOne(x => x.ModifyUser)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);


            builder.HasMany(x => x.QuestionLevels)
                .WithOne(x => x.CreatUser)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(x => x.QuestionLevelsM)
                .WithOne(x => x.ModifyUser)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);


            builder.HasMany(x => x.QuestionTypes)
                .WithOne(x => x.CreatUser)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(x => x.QuestionTypesM)
                .WithOne(x => x.ModifyUser)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);


            builder.HasMany(x => x.Responses)
                .WithOne(x => x.CreatUser)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(x => x.ResponsesM)
                .WithOne(x => x.ModifyUser)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);


            builder.HasMany(x => x.Subjects)
                .WithOne(x => x.CreatUser)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(x => x.SubjectsM)
                .WithOne(x => x.ModifyUser)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);


            builder.HasMany(x => x.Sections)
                .WithOne(x => x.CreatUser)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(x => x.SectionsM)
                .WithOne(x => x.ModifyUser)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);


            builder.HasMany(x => x.Companies)
                .WithOne(x => x.CreatUser)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(x => x.CompaniesM)
                .WithOne(x => x.ModifyUser)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);


            builder.HasMany(x => x.Exams)
                .WithOne(x => x.CreatUser)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(x => x.ExamsM)
                .WithOne(x => x.ModifyUser)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);


            builder.HasMany(x => x.SubjectParameters)
                .WithOne(x => x.CreatUser)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(x => x.SubjectParametersM)
                .WithOne(x => x.ModifyUser)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);


            builder.HasMany(x => x.ExamParameters)
                .WithOne(x => x.CreatUser)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(x => x.ExamParametersM)
                .WithOne(x => x.ModifyUser)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);


            builder.HasMany(x => x.Texts)
                .WithOne(x => x.CreatUser)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(x => x.TextsM)
                .WithOne(x => x.ModifyUser)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);


            builder.HasMany(x => x.Variants)
                .WithOne(x => x.CreatUser)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(x => x.VariantsM)
                .WithOne(x => x.ModifyUser)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);


            builder.HasMany(x => x.QuestionParameters)
                .WithOne(x => x.CreatUser)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(x => x.QuestionParametersM)
                .WithOne(x => x.ModifyUser)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);


            builder.HasMany(x => x.Booklets)
                .WithOne(x => x.CreatUser)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(x => x.BookletsM)
                .WithOne(x => x.ModifyUser)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);


            builder.HasMany(x => x.Groups)
                .WithOne(x => x.CreatUser)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(x => x.GroupsM)
                .WithOne(x => x.ModifyUser)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
