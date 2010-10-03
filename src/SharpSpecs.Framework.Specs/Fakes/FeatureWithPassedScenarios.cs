using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSpecs.Framework.Specs.Fakes
{
    public class FeatureWithPassedScenarios : Feature
    {
        Scenario PassedScenario1()
        {
            Scenario scenario = When(fake_step).Then(fake_step);
            scenario.State = ScenarioState.Passed;
            return scenario;
        }

        Scenario PassedScenario2()
        {
            Scenario scenario = When(fake_step).Then(fake_step);
            scenario.State = ScenarioState.Passed;
            return scenario;
        }

        private void fake_step(){}        
    }
}
