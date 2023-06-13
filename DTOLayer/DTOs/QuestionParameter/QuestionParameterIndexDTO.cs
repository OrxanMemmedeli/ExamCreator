﻿using DTOLayer.DTOs.BaseFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.QuestionParameter
{
    public class QuestionParameterIndexDTO : BaseFieldsForList
    {
        public int StartQuestionNumber { get; set; }
        public int EndQuestionNumber { get; set; }
    }
}
