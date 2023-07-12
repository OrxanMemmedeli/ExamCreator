using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs
{
    public class GenericUpdateRangeModel<T> where T : class
    {
        public T t { get; set; }
        public Action<EntityEntry<T>> rules { get; set; }
    }
}
