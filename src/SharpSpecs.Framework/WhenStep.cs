using System;
namespace SharpSpecs.Framework
{
    public class WhenStep : Step
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhenStep"/> class.
        /// </summary>
        /// <param name="scenario">The scenario container.</param>
        /// <param name="step">The step.</param>
        /// <param name="prefix"></param>
        internal WhenStep(Scenario scenario, Action step, StepPrefix prefix)
            : base(scenario, step, prefix)
        {
            this.Scenario.AddStep(this);
        }
    }
}