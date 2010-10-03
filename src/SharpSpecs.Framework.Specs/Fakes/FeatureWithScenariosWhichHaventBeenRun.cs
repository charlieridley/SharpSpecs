using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSpecs.Framework.Specs.Fakes
{
    public class FeatureWithScenariosWhichHaventBeenRun : Feature
    {
        Scenario NotRunScenario1()
        {
            Scenario scenario = When(fake_step).Then(fake_step);
            scenario.State = ScenarioState.NotRun;
            return scenario;
        }

        Scenario NotRunScenario2()
        {
            Scenario scenario = When(fake_step).Then(fake_step);
            scenario.State = ScenarioState.NotRun;
            return scenario;
        }

        private void fake_step(){}        
    }
}
