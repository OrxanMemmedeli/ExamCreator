using DataAccess.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ResponseManager : GenericManager<Response>
    {
        public ResponseManager(IGenericDal<Response> dal) : base(dal)
        {
        }
    }
}
