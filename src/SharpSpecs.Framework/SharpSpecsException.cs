using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSpecs.Framework
{
    public class SharpSpecsException : Exception
    {
        public SharpSpecsException(string message, params string[] parameters)
            : base(string.Format(message, parameters))
        {
        }
    }
}
