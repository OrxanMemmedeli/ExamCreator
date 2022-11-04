﻿using DataAccess.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class QuestionLevelManager : GenericManager<QuestionLevel>
    {
        public QuestionLevelManager(IGenericDal<QuestionLevel> dal) : base(dal)
        {
        }
    }
}
