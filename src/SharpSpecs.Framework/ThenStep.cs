using System;

namespace SharpSpecs.Framework
{
    public class ThenStep : Step
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThenStep"/> class.
        /// </summary>
        /// <param name="scenario">The scenario container.</param>
        /// <param name="step">The step.</param>
        /// <param name="prefix"></param>
        internal ThenStep(Scenario scenario, Action step, StepPrefix prefix) 
            : base(scenario, step, prefix)
        {
            this.Scenario.AddStep(this);
        }
    }
}