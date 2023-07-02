using EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Org.BouncyCastle.Asn1.Ocsp;

namespace EntityLayer.Concrete
{
    public class SysException : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UserIP { get; set; }
        public string? UserName { get; set; }
        public string RequestPath { get; set; }
        public int StatusCode { get; set; }
        public string? StackTrace { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}
