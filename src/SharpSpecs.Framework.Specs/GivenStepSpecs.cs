using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Moq;
using SharpSpecs.Framework.Specs.Fakes;
using It = Machine.Specifications.It;

namespace SharpSpecs.Framework.Specs.GivenStepSpecs
{
    [Subject(typeof(GivenStep))]
    public class when_I_create_an_instance : with_given_step
    {
        Establish context = I_have_a_scenario_container;
        Because I_create_a_given_condition = () => givenStep = new GivenStep(scenario, dummy_step, StepPrefix.Given);
        It should_contain_the_scenario = () => givenStep.Scenario.ShouldEqual(scenario);
        It should_contain_the_step = () => givenStep.Method.ShouldEqual(dummy_step);
        It should_add_itself_to_the_scenario = () => scenario.AddStepHasBeenCalled.ShouldBeTrue();
    }

    public class with_given_step
    {
        protected static ScenarioMock scenario;
        protected static GivenStep givenStep;
        protected static void dummy_step(){}
        protected static void I_have_a_scenario_container()
        {
            scenario = new ScenarioMock();
        }        
    }
}
