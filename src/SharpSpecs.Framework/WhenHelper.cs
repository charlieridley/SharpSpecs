using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSpecs.Framework
{
    public static class WhenHelper
    {
        /// <summary>
        /// Adds a when condition to the scenario
        /// </summary>
        /// <param name="givenStep">The given condition.</param>
        /// <param name="step">The step.</param>
        /// <returns></returns>
        public static WhenStep When(this GivenStep givenStep, Action step)
        {
            return new WhenStep(givenStep.Scenario, step, StepPrefix.When);
        }

        /// <summary>
        /// Adds another when condition to the scenario
        /// </summary>
        /// <param name="whenStep">The when step.</param>
        /// <param name="step">The step.</param>
        /// <returns></returns>
        public static WhenStep And(this WhenStep whenStep, Action step)
        {
            return new WhenStep(whenStep.Scenario, step, StepPrefix.And);
        }
    }
}
