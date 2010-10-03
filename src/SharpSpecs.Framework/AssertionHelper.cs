using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSpecs.Framework
{
    public static class AssertionHelper
    {
        /// <summary>
        /// Asserts that the two values are equal
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        public static void ShouldEqual<T>(this T actual, T expected)            
        {
            if (!actual.Equals(expected))
            {
                throw new SharpSpecsException("Should equal {0} but equals {1}", expected.ToString(), actual.ToString());
            }
        }
    }
}
