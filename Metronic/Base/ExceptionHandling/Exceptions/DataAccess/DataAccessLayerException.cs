﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ponera.Base.ExceptionHandling.Exceptions.DataAccess
{
    [Serializable]
    public class DataAccessLayerException : BaseException
    {
        public DataAccessLayerException()
        {
        }

        public DataAccessLayerException(string message) : base(message)
        {
        }

        public DataAccessLayerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
