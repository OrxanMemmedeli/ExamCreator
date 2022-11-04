using DataAccess.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class QuestionTypeManager : GenericManager<QuestionType>
    {
        public QuestionTypeManager(IGenericDal<QuestionType> dal) : base(dal)
        {
        }
    }
}
