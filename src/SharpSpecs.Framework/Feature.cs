using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SharpSpecs.Framework
{
    public abstract class Feature
    {
        private IEnumerable<Scenario> scenarios;
        /// <summary>
        /// Starts a new scenario
        /// </summary>
        /// <param name="step">The step.</param>
        /// <returns></returns>
        protected GivenStep Given(Action step)
        {
            return new GivenStep(new Scenario(), step, StepPrefix.Given);
        }

        /// <summary>
        /// Whens the specified step.
        /// </summary>
        /// <param name="step">The step.</param>
        /// <returns></returns>
        protected WhenStep When(Action step)
        {
            return new WhenStep(new Scenario(), step, StepPrefix.When);
        }

        /// <summary>
        /// Gets the scenarios for this feature.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Scenario> Scenarios
        {
            get { return scenarios ?? (scenarios = this.LoadScenarios()); }
        }

        /// <summary>
        /// Loads the scenarios.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Scenario> LoadScenarios()
        {
            IEnumerable<MethodInfo> methods = this.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).Where(x => x.ReturnType == typeof(Scenario));
                return methods.Select(methodInfo =>
                {
                    var scenario = (Scenario)methodInfo.Invoke(this, null);
                    scenario.Name = methodInfo.Name.Replace('_', ' ');
                    return scenario;
                });
            
        }

        /// <summary>
        /// Gets the name of the feature.
        /// </summary>
        public string Name
        {
            get { return this.GetType().Name; }
        }

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>The state.</value>
        public FeatureState State
        {
            get
            {
                if (this.Scenarios.All(s => s.State == ScenarioState.Passed))
                {
                    return FeatureState.Passed;
                }
                
                if (this.Scenarios.Any(s => s.State == ScenarioState.FailedOnAssertion || s.State == ScenarioState.FailedOnSetup))
                {
                    return FeatureState.Failed;
                }

                return FeatureState.NotRun;
            }
        }
    }
}
