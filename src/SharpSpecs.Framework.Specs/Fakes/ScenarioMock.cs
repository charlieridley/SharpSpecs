using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSpecs.Framework.Specs.Fakes
{
    public class ScenarioMock : Scenario
    {
        public bool AddStepHasBeenCalled { get; private set; }
        internal override void AddStep(Step givenStep)
        {
            this.AddStepHasBeenCalled = true;
        }         
    }
}
