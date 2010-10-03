using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSpecs.Framework
{
    public static class ThenHelper
    {
        /// <summary>
        /// Adds a then condition to the scenario
        /// </summary>
        /// <param name="whenStep">The when condition.</param>
        /// <param name="step">The step.</param>
        /// <returns></returns>
        public static Scenario Then(this WhenStep whenStep, Action step)
        {
            return new ThenStep(whenStep.Scenario, step, StepPrefix.Then).Scenario;
        }

        /// <summary>
        /// Adds another then condition to the scenario
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <param name="step">The step.</param>
        /// <returns></returns>
        public static Scenario And(this Scenario scenario, Action step)
        {
            return new ThenStep(scenario, step, StepPrefix.And).Scenario;
        }
    }
}
