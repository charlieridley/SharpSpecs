using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace SharpSpecs.Framework.Specs.AssertionHelperSpecs
{
    public class when_I_assert_two_integers_of_the_same_value_are_equal : with_assertion_helper
    {
        Because I_assert_two_same_value_integers_are_equal = () => AssertAreEqual(2, 2);
        It should_not_throw_an_exception = () => exception.ShouldBeNull();
    }

    public class with_assertion_helper
    {
        protected static Exception exception;
        protected static void AssertAreEqual<T>(T value1, T value2)
        {
            exception = null;
            try
            {
                value1.ShouldEqual(value2);
            }
            catch(Exception ex)
            {
                exception = ex;
            }
        }
    }
}
