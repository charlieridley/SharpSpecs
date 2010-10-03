using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace SharpSpecs.Framework.Specs
{
    [Subject(typeof(Step))]
    public class when_I_create_a_step : with_step
    {
        Because of = () => I_have_a_step(here_is_a_passing_dummy_step);
        It should_contain_the_step_name = () => step.GetStepName().ShouldEqual("here is a passing dummy step");
        It should_be_in_a_not_run_state = () => step.State.ShouldEqual(StepState.NotRun);
        It should_not_have_any_exception = () => step.Exception.ShouldBeNull();
        It should_contain_the_step_prefix = () => step.Prefix.ShouldEqual("When");
    }

    [Subject(typeof(Step))]
    public class when_I_run_a_passing_step : with_step
    {
        Establish of = () => I_have_a_step(here_is_a_passing_dummy_step);
        Because I_run_the_step = () => step.RunStep();
        It should_execute_the_step = () => dummyStepHasExecuted.ShouldBeTrue();
        It should_pass = () => step.State.ShouldEqual(StepState.Passed);
    }

    [Subject(typeof(Step))]
    public class when_I_run_a_failing_step : with_step
    {
        Establish of = () => I_have_a_step(here_is_a_failing_dummy_step);
        Because I_run_the_step = () => step.RunStep();        
        It should_fail = () => step.State.ShouldEqual(StepState.Failed);
        It should_contain_the_exception_from_the_failed_step = () => step.Exception.ShouldEqual(exception);
        It should_have_a_scenario_in_a_failed_state = () => step.Scenario.State.ShouldEqual(ScenarioState.Failed);
    }

    [Subject(typeof(Step))]
    public class when_I_run_a_step_on_a_failed_scenario : with_step
    {
        Establish of = () => I_have_a_step_with_a_failed_scenario(here_is_a_failing_dummy_step);
        Because I_run_the_step = () => step.RunStep();
        It should_not_execute_the_step = () => dummyStepHasExecuted.ShouldBeFalse();
        It should_be_in_a_skipped_state = () => step.State.ShouldEqual(StepState.Skipped);
    }

    public class with_step
    {
        protected static Step step;
        protected static bool dummyStepHasExecuted;
        protected static Exception exception;
        protected static void here_is_a_passing_dummy_step() { dummyStepHasExecuted = true; }
        protected static void here_is_a_failing_dummy_step()
        {
            exception = new Exception("Step failed");
            throw exception;
        }
        protected static void I_have_a_step(Action stepMethod)
        {
            dummyStepHasExecuted = false;
            step = new GivenStep(new Scenario(), stepMethod, StepPrefix.When);
        }

        protected static void I_have_a_step_with_a_failed_scenario(Action stepMethod)
        {
            dummyStepHasExecuted = false;
            step = new GivenStep(new Scenario{State = ScenarioState.Failed}, stepMethod, StepPrefix.When);
        }
    }
}
