using DataAccess.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class QuestionManager : GenericManager<Question>
    {
        public QuestionManager(IGenericDal<Question> dal) : base(dal)
        {
        }
    }
}
