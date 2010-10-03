using System;
using System.Collections.Generic;

namespace SharpSpecs.Framework
{
    public interface ISpecRunner
    {
        /// <summary>
        /// Loads from specified DLL name.
        /// </summary>
        /// <param name="dllName">Name of the DLL.</param>
        IEnumerable<Feature> Load(string dllName);

        /// <summary>
        /// Runs all features.
        /// </summary>
        void RunAllFeatures();

        /// <summary>
        /// Occurs when a feature starts to run
        /// </summary>
        event Action<Feature> FeatureBegin;

        /// <summary>
        /// Occurs when a scenario starts to run
        /// </summary>
        event Action<Scenario> ScenarioBegin;

        /// <summary>
        /// Occurs when a step starts to run
        /// </summary>
        event Action<Step> StepBegin;

        /// <summary>
        /// Occurs when a step finishes running
        /// </summary>
        event Action<Step> StepEnd;

        /// <summary>
        /// Occurs when the scenario finishes running
        /// </summary>
        event Action<Scenario> ScenarioEnd;

        /// <summary>
        /// Occurs when a feature finishes running
        /// </summary>
        event Action<Feature> FeatureEnd;
    }
}