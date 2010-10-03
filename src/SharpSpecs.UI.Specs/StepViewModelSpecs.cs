using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpSpecs.Framework;
using SharpSpecs.UI.ViewModels;

namespace SharpSpecs.UI.Specs
{
    [Feature]
    public class StepViewModelSpecs : StepViewModelSteps
    {
        Scenario creating_an_instance()
        {
            return When(I_create_an_instance)
                .Then(it_should_have_the_step_name);
        }        
    }

    public class StepViewModelSteps : Feature
    {
        private Step step;
        private StepViewModel viewModel;
        private void test_step(){}
        protected void I_create_an_instance()
        {
            step = GetDummyStep();
            viewModel = new StepViewModel(step);
        }

        protected void it_should_have_the_step_name()
        {
            viewModel.StepName.ShouldEqual(step.Label);
        }

        private Step GetDummyStep()
        {
            return When(test_step).Then(test_step).Steps[0];
        }
    }
}
