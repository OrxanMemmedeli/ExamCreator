using DataAccess.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserTypeManager : GenericManager<UserType>
    {
        public UserTypeManager(IGenericDal<UserType> dal) : base(dal)
        {
        }
    }
}
