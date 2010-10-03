using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Moq;
using SharpSpecs.Framework.Specs.Fakes;
using It = Machine.Specifications.It;

namespace SharpSpecs.Framework.Specs.ThenStepSpecs
{
    [Subject(typeof(ThenStep))]
    public class then_I_create_an_instance : with_then_step
    {
        Establish context = I_have_a_scenario_container;
        Because I_create_a_given_condition = () => thenStep = new ThenStep(scenario, dummy_step, StepPrefix.Then);
        It should_contain_the_scenario = () => thenStep.Scenario.ShouldEqual(scenario);
        It should_contain_the_step = () => thenStep.Method.ShouldEqual(dummy_step);
        It should_add_itself_to_the_scenario = () => scenario.AddStepHasBeenCalled.ShouldBeTrue();
    }

    public class with_then_step
    {
        protected static ScenarioMock scenario;
        protected static ThenStep thenStep;
        protected static void dummy_step(){}
        protected static void I_have_a_scenario_container()
        {
            scenario = new ScenarioMock();
        }        
    }
}
