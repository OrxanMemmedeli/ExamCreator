﻿using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Configuration
{
    public class SubjectParameterConfig : IEntityTypeConfiguration<SubjectParameter>
    {
        public void Configure(EntityTypeBuilder<SubjectParameter> builder)
        {
            builder.HasOne(x => x.Subject)
                .WithMany(x => x.SubjectParameters)
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.ExamParameter)
                .WithMany(x => x.SubjectParameters)
                .HasForeignKey(x => x.ExamParameterId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.CreatUser)
                .WithMany(x => x.SubjectParameters)
                .HasForeignKey(x => x.CreatUserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.ModifyUser)
                .WithMany(x => x.SubjectParametersM)
                .HasForeignKey(x => x.ModifyUserId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
