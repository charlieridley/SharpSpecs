using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SharpSpecs.Framework
{
    public abstract class Feature
    {
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
        /// Gets the scenarios for this feature.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Scenario> GetScenarios()
        {
            IEnumerable<MethodInfo> methods = this.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).Where(x => x.ReturnType == typeof(Scenario));
            return methods.Select(methodInfo =>
            {
                var scenario = (Scenario) methodInfo.Invoke(this, null);
                scenario.Name = methodInfo.Name.Replace('_', ' ');
                return scenario;
            });
        }

        /// <summary>
        /// Gets the name of the feature.
        /// </summary>
        public string GetFeatureName()
        {
            return this.GetType().Name;
        }
    }
}
