using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSpecs.Framework.Specs.Fakes
{
    public class FeatureWithAFailedOnAssertScenario : Feature
    {
        Scenario PassedScenario()
        {
            Scenario scenario = When(fake_step).Then(fake_step);
            scenario.State = ScenarioState.Passed;
            return scenario;
        }

        Scenario FailedScenario()
        {
            Scenario scenario = When(fake_step).Then(fake_step);
            scenario.State = ScenarioState.FailedOnSetup;
            return scenario;
        }

        private void fake_step(){}        
    }
}
