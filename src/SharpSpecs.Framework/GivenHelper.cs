using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSpecs.Framework
{
    public static class GivenHelper
    {
        /// <summary>
        /// Adds another given condition to the scenario
        /// </summary>
        /// <param name="givenStep">The given condition.</param>
        /// <param name="step">The step.</param>
        /// <returns></returns>
        public static GivenStep And(this GivenStep givenStep, Action step)
        {
            return new GivenStep(givenStep.Scenario, step, StepPrefix.And);
        }
    }
}
