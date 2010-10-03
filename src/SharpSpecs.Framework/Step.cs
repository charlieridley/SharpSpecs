using System;

namespace SharpSpecs.Framework
{
    public class Step
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Step"/> class.
        /// </summary>
        /// <param name="scenario">The scenario container.</param>
        /// <param name="step">The step.</param>
        /// <param name="prefix"></param>
        public Step(Scenario scenario, Action step, StepPrefix prefix)
        {
            this.Scenario = scenario;
            this.Method = step;
            this.SetStepPrefix(prefix);
            this.State = StepState.NotRun;
        }

        /// <summary>
        /// Sets the step prefix.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        private void SetStepPrefix(StepPrefix prefix)
        {
            this.Prefix = Enum.GetName(typeof (StepPrefix), prefix);
        }

        /// <summary>
        /// Gets or sets the step.
        /// </summary>
        /// <value>The step.</value>
        internal Action Method { get; private set; }

        /// <summary>
        /// Gets or sets the scenario container.
        /// </summary>
        /// <value>The scenario container.</value>
        public Scenario Scenario { get; private set; }

        /// <summary>
        /// Returns true if passed, false if failed or null if the condition has not been run
        /// </summary>
        /// <value>The has passed.</value>
        public StepState State { get; private set; }

        /// <summary>
        /// Gets the exception from a failed step
        /// </summary>
        /// <value>The exception.</value>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Gets or sets the prefix.
        /// </summary>
        /// <value>The prefix.</value>
        public string Prefix { get; private set; }

        /// <summary>
        /// Gets the name of the step.
        /// </summary>
        /// <returns></returns>
        public string GetStepName()
        {
            return Method.Method.Name.Replace('_', ' ');
        }

        /// <summary>
        /// Runs the step.
        /// </summary>
        internal void RunStep()
        {
            if(this.Scenario.State == ScenarioState.Failed)
            {
                this.State = StepState.Skipped;
                return;
            }

            try
            {
                this.Method();
                this.State = StepState.Passed;
            }
            catch(Exception ex)
            {
                this.State = StepState.Failed;
                this.Exception = ex;
                this.Scenario.State = ScenarioState.Failed;
            }            
        }
    }
}