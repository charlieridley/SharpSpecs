using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSpecs.Framework.Specs.Fakes
{
    [Feature]
    public class FeatureWithOneScenarioAndThreeSteps : FeatureWithOneScenarioAndThreeStepsSteps
    {
        Scenario I_have_a_scenario_with_3_steps()
        {
            return Given(I_have_a_given_step)
                .When(I_have_a_when_step)
                .Then(I_have_a_then_step);
        }        
    }

    public class FeatureWithOneScenarioAndThreeStepsSteps : Feature
    {
        protected void I_have_a_then_step()
        {
            this.ThenStepHasRun = true;
        }

        public bool ThenStepHasRun { get; private set; }

        protected void I_have_a_when_step()
        {
            this.WhenStepHasRun = true;
        }

        public bool WhenStepHasRun { get; private set; }

        protected void I_have_a_given_step()
        {
            this.GivenStepHasRun = true;
        }

        public bool GivenStepHasRun { get; private set; }
    }
}
