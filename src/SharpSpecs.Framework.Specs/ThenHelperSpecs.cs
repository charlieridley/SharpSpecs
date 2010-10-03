using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace SharpSpecs.Framework.Specs.ThenHelperSpecs
{
    [Subject(typeof(ThenHelper))]
    public class then_I_add_a_then_condition_to_a_when_condition : with_then_helper
    {
        Establish context = I_have_a_when_condition;
        Because I_add_a_then_condition = () => scenario = when.Then(dummy_step);
        It should_have_the_scenario = () => scenario.ShouldEqual(when.Scenario);
        It should_have_the_new_step = () => scenario.Steps.Last().Method.ShouldEqual(dummy_step);
        It should_contain_a_step_prefix_of_then = () => scenario.Steps.Last().Prefix.ShouldEqual("Then");
    }

    [Subject(typeof(ThenHelper))]
    public class then_I_add_another_then_condition_to_a_then_condition : with_then_helper
    {
        Establish context = I_have_a_then_condition;
        Because I_add_another_then_condition = () => scenario = then.Scenario.And(dummy_step);
        It should_have_the_scenario = () => scenario.ShouldEqual(then.Scenario);
        It should_have_the_new_step = () => scenario.Steps.Last().Method.ShouldEqual(dummy_step);
        It should_contain_a_step_prefix_of_and = () => scenario.Steps.Last().Prefix.ShouldEqual("And");
    }

    public class with_then_helper
    {
        protected static WhenStep when;
        protected static Scenario scenario;
        protected static ThenStep then;
        protected static void dummy_step() { }
        protected static void I_have_a_when_condition()
        {
            when = new WhenStep(new Scenario(), dummy_step, StepPrefix.When);
        }
        protected static void I_have_a_then_condition()
        {
            then = new ThenStep(new Scenario(), dummy_step, StepPrefix.Then);
        }
    }
}
