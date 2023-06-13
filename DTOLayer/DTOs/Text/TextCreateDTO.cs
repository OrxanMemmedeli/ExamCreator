using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.Text
{
    public class TextCreateDTO
    {
        public string Name { get; set; }
        public string Title { get; set; } = "Mətni oxuyun və {0} – {1} nömrəli tapşırıqları mətnə uyğun cavablayın.";
        public string Content { get; set; }
    }
}
