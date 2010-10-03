using System;

namespace SharpSpecs.Framework
{
    public class GivenStep : Step
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GivenStep"/> class.
        /// </summary>
        /// <param name="scenario">The scenario container.</param>
        /// <param name="step">The step.</param>
        /// <param name="prefix">The prefix.</param>
        internal GivenStep(Scenario scenario, Action step, StepPrefix prefix)
            : base(scenario, step, prefix)
        {
            this.Scenario.AddStep(this);            
        }        
    }
}
