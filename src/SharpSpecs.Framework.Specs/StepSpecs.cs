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
        Because of = () => I_have_a_given_step(here_is_a_passing_dummy_step);
        It should_contain_the_step_name = () => step.Name.ShouldEqual("here is a passing dummy step");
        It should_be_in_a_not_run_state = () => step.State.ShouldEqual(StepState.NotRun);
        It should_not_have_any_exception = () => step.Exception.ShouldBeNull();
        It should_contain_the_step_prefix = () => step.Prefix.ShouldEqual("When");
        It should_contain_a_label = () => step.Label.ShouldEqual("When here is a passing dummy step");
    }

    [Subject(typeof(Step))]
    public class when_I_run_a_passing_step : with_step
    {
        Establish of = () => I_have_a_given_step(here_is_a_passing_dummy_step);
        Because I_run_the_step = () => step.RunStep();
        It should_execute_the_step = () => dummyStepHasExecuted.ShouldBeTrue();
        It should_pass = () => step.State.ShouldEqual(StepState.Passed);
    }

    [Subject(typeof(Step))]
    public class when_I_run_a_failing_given_step : with_step
    {
        Establish of = () => I_have_a_given_step(here_is_a_failing_dummy_step);
        Because I_run_the_step = () => step.RunStep();        
        It should_fail = () => step.State.ShouldEqual(StepState.Failed);
        It should_contain_the_exception_from_the_failed_step = () => step.Exception.ShouldEqual(exception);
        It should_have_a_scenario_in_a_failed_on_setup = () => step.Scenario.State.ShouldEqual(ScenarioState.FailedOnSetup);
    }

    [Subject(typeof(Step))]
    public class when_I_run_a_given_step_on_a_failed_on_setup_scenario : with_step
    {
        Establish of = () => I_have_a_given_step_with_a_failed_on_setup_scenario(here_is_a_failing_dummy_step);
        Because I_run_the_step = () => step.RunStep();
        It should_not_execute_the_step = () => dummyStepHasExecuted.ShouldBeFalse();
        It should_be_in_a_skipped_state = () => step.State.ShouldEqual(StepState.Skipped);
    }

    [Subject(typeof(Step))]
    public class when_I_run_a_when_step_on_a_failed_on_setup_scenario : with_step
    {
        Establish of = () => I_have_a_when_step_with_a_failed_on_setup_scenario(here_is_a_failing_dummy_step);
        Because I_run_the_step = () => step.RunStep();
        It should_not_execute_the_step = () => dummyStepHasExecuted.ShouldBeFalse();
        It should_be_in_a_skipped_state = () => step.State.ShouldEqual(StepState.Skipped);
    }

    [Subject(typeof(Step))]
    public class when_I_run_a_then_step_on_a_failed_on_setup_scenario : with_step
    {
        Establish of = () => I_have_a_then_step_with_a_failed_on_setup_scenario(here_is_a_failing_dummy_step);
        Because I_run_the_step = () => step.RunStep();
        It should_not_execute_the_step = () => dummyStepHasExecuted.ShouldBeFalse();
        It should_be_in_a_skipped_state = () => step.State.ShouldEqual(StepState.Skipped);
    }

    [Subject(typeof(Step))]
    public class when_I_run_a_given_step_on_a_failed_on_assertion_scenario : with_step
    {
        Establish of = () => I_have_a_given_step_with_a_failed_on_assertion_scenario(here_is_a_failing_dummy_step);
        Because I_run_the_step = () => step.RunStep();
        It should_not_execute_the_step = () => dummyStepHasExecuted.ShouldBeFalse();
        It should_be_in_a_skipped_state = () => step.State.ShouldEqual(StepState.Skipped);
    }

    [Subject(typeof(Step))]
    public class when_I_run_a_when_step_on_a_failed_on_assertion_scenario : with_step
    {
        Establish of = () => I_have_a_when_step_with_a_failed_on_assertion_scenario(here_is_a_failing_dummy_step);
        Because I_run_the_step = () => step.RunStep();
        It should_not_execute_the_step = () => dummyStepHasExecuted.ShouldBeFalse();
        It should_be_in_a_skipped_state = () => step.State.ShouldEqual(StepState.Skipped);
    }

    [Subject(typeof(Step))]
    public class when_I_run_a_then_step_on_a_failed_on_assertion_scenario : with_step
    {
        Establish of = () => I_have_a_then_step_with_a_failed_on_assertion_scenario(here_is_a_failing_dummy_step);
        Because I_run_the_step = () => step.RunStep();
        It should_not_execute_the_step = () => dummyStepHasExecuted.ShouldBeFalse();
        It should_be_in_a_failed_state = () => step.State.ShouldEqual(StepState.Failed);
    }

    [Subject(typeof(Step))]
    public class when_I_run_a_the_last_step_on_a_passing_scenario : with_step
    {
        Establish of = () => I_have_a_given_step(here_is_a_passing_dummy_step);
        Because I_run_the_step = () => step.RunStep();
        It should_put_the_scenario_in_a_passed_state = () => step.Scenario.State.ShouldEqual(ScenarioState.Passed);
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
        protected static void I_have_a_given_step(Action stepMethod)
        {
            dummyStepHasExecuted = false;
            step = new GivenStep(new Scenario(), stepMethod, StepPrefix.When);
        }

        protected static void I_have_a_then_step(Action stepMethod)
        {
            dummyStepHasExecuted = false;
            step = new ThenStep(new Scenario(), stepMethod, StepPrefix.When);
        }

        protected static void I_have_a_given_step_with_a_failed_on_setup_scenario(Action stepMethod)
        {
            dummyStepHasExecuted = false;
            step = new GivenStep(new Scenario{State = ScenarioState.FailedOnSetup}, stepMethod, StepPrefix.Given);
        }

        protected static void I_have_a_given_step_with_a_failed_on_assertion_scenario(Action stepMethod)
        {
            dummyStepHasExecuted = false;
            step = new GivenStep(new Scenario { State = ScenarioState.FailedOnAssertion }, stepMethod, StepPrefix.Given);
        }

        protected static void I_have_a_when_step_with_a_failed_on_setup_scenario(Action stepMethod)
        {
            dummyStepHasExecuted = false;
            step = new WhenStep(new Scenario { State = ScenarioState.FailedOnSetup }, stepMethod, StepPrefix.When);
        }

        protected static void I_have_a_when_step_with_a_failed_on_assertion_scenario(Action stepMethod)
        {
            dummyStepHasExecuted = false;
            step = new WhenStep(new Scenario { State = ScenarioState.FailedOnAssertion }, stepMethod, StepPrefix.When);
        }

        protected static void I_have_a_then_step_with_a_failed_on_setup_scenario(Action stepMethod)
        {
            dummyStepHasExecuted = false;
            step = new ThenStep(new Scenario { State = ScenarioState.FailedOnSetup }, stepMethod, StepPrefix.Then);
        }

        protected static void I_have_a_then_step_with_a_failed_on_assertion_scenario(Action stepMethod)
        {
            dummyStepHasExecuted = false;
            step = new ThenStep(new Scenario { State = ScenarioState.FailedOnAssertion }, stepMethod, StepPrefix.Then);
        }
    }
}
