using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpSpecs.Framework;
using SharpSpecs.UI.ViewModels;

namespace SharpSpecs.UI.Specs
{
    [Feature]
    public class ScenarioViewModelSpecs : ScenarioViewModelSteps
    {
        Scenario creating_an_instance()
        {
            return When(I_create_an_instance)
                .Then(it_should_have_a_reference_to_the_scenario)
                .And(it_should_have_the_scenario_name)
                .And(it_should_contain_the_steps);
        }        
    }

    public class ScenarioViewModelSteps : Feature
    {
        private ScenarioViewModel viewModel;
        private Scenario scenario;
        private void test_when() { }
        private void test_then() { }
        private Scenario TestScenario()
        {
            return When(test_when).Then(test_then);
        }

        protected void I_create_an_instance()
        {
            scenario = TestScenario();
            scenario.Name = "Test scenario";
            viewModel = new ScenarioViewModel(scenario);
        }

        protected void it_should_have_a_reference_to_the_scenario()
        {
            viewModel.Scenario.ShouldEqual(scenario);
        }        

        protected void it_should_have_the_scenario_name()
        {
            viewModel.ScenarioName.ShouldEqual(scenario.Name);
        }

        protected void it_should_contain_the_steps()
        {
            viewModel.Steps.Count.ShouldEqual(scenario.Steps.Count);
        }
    }
}