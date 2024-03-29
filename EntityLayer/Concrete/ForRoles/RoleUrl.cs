﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete.Base;

namespace EntityLayer.Concrete.ForRoles
{
    public class RoleUrl : IEntity
    {
        public RoleUrl()
        {
            this.CombineRoleUrls = new HashSet<CombineRoleUrl>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Url { get; set; }

        public ICollection<CombineRoleUrl> CombineRoleUrls { get; set; }

    }
}
