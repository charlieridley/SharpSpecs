using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace SharpSpecs.Framework.Specs.WhenHelperSpecs
{
    [Subject(typeof(WhenHelper))]
    public class when_I_add_a_when_condition_to_a_given_condition : with_when_helper
    {
        Establish context = I_have_a_given_condition;
        Because I_add_a_when_condition = () => newWhenStep = given.When(dummy_step);
        It should_have_the_scenario = () => newWhenStep.Scenario.ShouldEqual(given.Scenario);
        It should_have_the_new_step = () => newWhenStep.Method.ShouldEqual(dummy_step);
        It should_contain_a_step_prefix_of_when = () => newWhenStep.Prefix.ShouldEqual("When");
    }

    [Subject(typeof(WhenHelper))]
    public class when_I_add_another_when_condition_to_a_when_condition : with_when_helper
    {
        Establish context = I_have_a_when_condition;
        Because I_add_another_when_condition = () => newWhenStep = when.And(dummy_step);
        It should_have_the_scenario = () => newWhenStep.Scenario.ShouldEqual(when.Scenario);
        It should_have_the_new_step = () => newWhenStep.Method.ShouldEqual(dummy_step);
        It should_contain_a_step_prefix_of_and = () => newWhenStep.Prefix.ShouldEqual("And");
    }

    public class with_when_helper
    {
        protected static GivenStep given;
        protected static WhenStep newWhenStep;
        protected static WhenStep when;
        protected static void dummy_step() { }
        protected static void I_have_a_given_condition()
        {
            given = new GivenStep(new Scenario(), dummy_step, StepPrefix.Given);
        }
        protected static void I_have_a_when_condition()
        {
            when = new WhenStep(new Scenario(), dummy_step, StepPrefix.When);
        }
    }
}
