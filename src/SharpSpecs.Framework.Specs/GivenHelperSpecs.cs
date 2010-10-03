using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace SharpSpecs.Framework.Specs.GivenHelperSpecs
{
    [Subject(typeof(GivenHelper))]
    public class when_I_add_another_given_step : with_given_helper
    {
        Establish context = I_have_a_given_condition;
        Because I_add_another_given_condition = () => newGivenStep = given.And(dummy_step);
        It should_have_the_scenario = () => newGivenStep.Scenario.ShouldEqual(given.Scenario);
        It should_have_the_new_step = () => newGivenStep.Method.ShouldEqual(dummy_step);
        It should_contain_a_step_prefix_of_and = () => newGivenStep.Prefix.ShouldEqual("And");
    }

    public class with_given_helper
    {
        protected static GivenStep given;
        protected static GivenStep newGivenStep;
        protected static void dummy_step() { }
        protected static void I_have_a_given_condition()
        {
            given = new GivenStep(new Scenario(), dummy_step, StepPrefix.Given);
        }        
    }
}
