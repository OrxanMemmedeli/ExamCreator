using EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class QuestionLevel:BaseEntity
    {
        public string Name { get; set; }
        [Range(1,5)]
        public short Level { get; set; }
    }
}
