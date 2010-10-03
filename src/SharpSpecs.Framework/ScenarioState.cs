using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSpecs.Framework
{
    public enum ScenarioState
    {
        Passed,
        FailedOnSetup,
        FailedOnAssertion,
        NotRun
    }
}
