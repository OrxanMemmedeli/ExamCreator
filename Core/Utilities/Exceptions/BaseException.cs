﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Utilities.Exceptions
{
    public partial class BaseException : Exception
    {
        public BaseException() : base() { }
        public BaseException(string? message) : base(message) { }
        public BaseException(string? message, Exception? innerException) : base(message, innerException) { }
        protected BaseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
