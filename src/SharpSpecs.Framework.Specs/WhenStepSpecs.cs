using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Moq;
using SharpSpecs.Framework.Specs.Fakes;
using It = Machine.Specifications.It;

namespace SharpSpecs.Framework.Specs.WhenStepSpecs
{
    [Subject(typeof(WhenStep))]
    public class when_I_create_an_instance : with_when_step
    {
        Establish context = I_have_a_scenario_container;
        Because I_create_a_given_condition = () => whenStep = new WhenStep(scenario, dummy_step, StepPrefix.When);
        It should_contain_the_scenario = () => whenStep.Scenario.ShouldEqual(scenario);
        It should_contain_the_step = () => whenStep.Method.ShouldEqual(dummy_step);
        It should_add_itself_to_the_scenario = () => scenario.AddStepHasBeenCalled.ShouldBeTrue();
    }

    public class with_when_step
    {
        protected static ScenarioMock scenario;
        protected static WhenStep whenStep;
        protected static void dummy_step(){}
        protected static void I_have_a_scenario_container()
        {
            scenario = new ScenarioMock();
        }        
    }
}
