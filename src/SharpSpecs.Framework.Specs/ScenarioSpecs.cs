using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using SharpSpecs.Framework.Specs.Fakes;

namespace SharpSpecs.Framework.Specs.ScenarioSpecs
{
    [Subject(typeof(Scenario))]
    public class when_I_have_a_scenario : with_scenario
    {
        Establish context = I_have_a_scenario;
        It should_contain_an_empty_collection_of_conditions = () => scenario.Steps.ShouldBeEmpty();
        It should_be_in_a_not_run_state = () => scenario.State.ShouldEqual(ScenarioState.NotRun);
    }

    [Subject(typeof(Scenario))]
    public class when_I_have_a_failing_scenario : with_scenario
    {
        Establish context = I_have_a_failing_scenario;
        Because I_run_the_scenario = run_the_scenario;
        It should_report_2_passed_steps = () => scenario.PassedStepCount.ShouldEqual(2);
        It should_report_1_failed_steps = () => scenario.FailedStepCount.ShouldEqual(1);
        It should_report_1_skipped_steps = () => scenario.SkippedStepCount.ShouldEqual(1);
    }

    public class with_scenario
    {
        protected static Scenario scenario;
        protected static void I_have_a_scenario()
        {
            scenario = new Scenario();
        }

        protected static void I_have_a_failing_scenario()
        {
            scenario = new FeatureWithFailingScenario().GetScenarios().First();
        }

        protected static void run_the_scenario()
        {
            foreach (Step step in scenario.Steps)
            {
                step.RunStep();
            }
        }
    }    
}
