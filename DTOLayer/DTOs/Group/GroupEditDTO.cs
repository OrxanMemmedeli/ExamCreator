﻿using DTOLayer.DTOs.BaseFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.Group
{
    public class GroupEditDTO : BaseFieldsForEdit
    {
        public string Name { get; set; }
    }
}
