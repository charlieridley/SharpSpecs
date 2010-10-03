using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSpecs.Framework
{
    public class Scenario
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Scenario"/> class.
        /// </summary>
        internal Scenario()
        {
            this.Steps = new List<Step>();
            this.State = ScenarioState.NotRun;
        }

        /// <summary>
        /// Gets or sets the steps.
        /// </summary>
        /// <value>The steps.</value>
        public List<Step> Steps { get; private set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public ScenarioState State { get; internal set; }

        /// <summary>
        /// Gets or sets the passed step count.
        /// </summary>
        /// <value>The passed step count.</value>
        public int PassedStepCount
        {
            get { return this.Steps.Count(x => x.State == StepState.Passed); }
        }

        /// <summary>
        /// Gets or sets the failed step count.
        /// </summary>
        /// <value>The failed step count.</value>
        public int FailedStepCount
        {
            get { return this.Steps.Count(x => x.State == StepState.Failed); }
        }

        /// <summary>
        /// Gets or sets the skipped step count.
        /// </summary>
        /// <value>The skipped step count.</value>
        public int SkippedStepCount
        {
            get { return this.Steps.Count(x => x.State == StepState.Skipped); }
        }

        /// <summary>
        /// Adds a step.
        /// </summary>
        /// <param name="givenStep">The given step.</param>
        internal virtual void AddStep(Step givenStep)
        {
            this.Steps.Add(givenStep);
        }
    }
}
