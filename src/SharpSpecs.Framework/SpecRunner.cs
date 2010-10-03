using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSpecs.Framework
{
    public class SpecRunner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecRunner"/> class.
        /// </summary>
        public SpecRunner() : this(new FeatureLoader()) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecRunner"/> class.
        /// </summary>
        /// <param name="featureLoader">The feature loader.</param>
        internal SpecRunner(IFeatureLoader featureLoader)
        {
            this.FeatureLoader = featureLoader;
        }

        /// <summary>
        /// Gets or sets the feature loader.
        /// </summary>
        /// <value>The feature loader.</value>
        private IFeatureLoader FeatureLoader { get; set; }

        /// <summary>
        /// Gets or sets the features.
        /// </summary>
        /// <value>The features.</value>
        public IEnumerable<Feature> Features { get; private set; }

        /// <summary>
        /// Loads from specified DLL name.
        /// </summary>
        /// <param name="dllName">Name of the DLL.</param>
        public void Load(string dllName)
        {
            this.Features = this.FeatureLoader.GetFeaturesFromDll(dllName);
        }

        /// <summary>
        /// Runs all features.
        /// </summary>
        public void RunAllFeatures()
        {
            foreach (Feature feature in this.Features)
            {
                this.OnFeatureBegin(feature);
                foreach (Scenario scenario in feature.GetScenarios())
                {
                    this.OnScenarioBegin(scenario);
                    foreach (Step step in scenario.Steps)
                    {
                        this.OnStepBegin(step);
                        step.RunStep();
                        this.OnStepEnd(step);
                    }
                    this.OnScenarioEnd(scenario);
                }
                this.OnFeatureEnd(feature);
            }
        }

        /// <summary>
        /// Called when the step ends
        /// </summary>
        /// <param name="step">The step.</param>
        private void OnStepEnd(Step step)
        {
            if (this.StepEnd != null)
            {
                this.StepEnd(step);
            }
        }

        /// <summary>
        /// Called when the step begins
        /// </summary>
        /// <param name="step">The step.</param>
        private void OnStepBegin(Step step)
        {
            if(this.StepBegin != null)
            {
                this.StepBegin(step);
            }
        }

        /// <summary>
        /// Called when a scenario ends
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        private void OnScenarioEnd(Scenario scenario)
        {
            if (this.ScenarioEnd != null)
            {
                this.ScenarioEnd(scenario);
            }
        }

        /// <summary>
        /// Called when a scenario begins
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        private void OnScenarioBegin(Scenario scenario)
        {
            if(this.ScenarioBegin !=null)
            {
                this.ScenarioBegin(scenario);
            }
        }

        /// <summary>
        /// Called when a feature ends
        /// </summary>
        /// <param name="feature">The feature.</param>
        private void OnFeatureEnd(Feature feature)
        {
            if(this.FeatureEnd != null)
            {
                this.FeatureEnd(feature);
            }
        }

        /// <summary>
        /// Called when a feature begins.
        /// </summary>
        /// <param name="feature">The feature.</param>
        private void OnFeatureBegin(Feature feature)
        {
            if(this.FeatureBegin != null)
            {
                this.FeatureBegin(feature);
            }
        }

        /// <summary>
        /// Occurs when a feature starts to run
        /// </summary>
        public event Action<Feature> FeatureBegin;

        /// <summary>
        /// Occurs when a scenario starts to run
        /// </summary>
        public event Action<Scenario> ScenarioBegin;

        /// <summary>
        /// Occurs when a step starts to run
        /// </summary>
        public event Action<Step> StepBegin;

        /// <summary>
        /// Occurs when a step finishes running
        /// </summary>
        public event Action<Step> StepEnd;

        /// <summary>
        /// Occurs when the scenario finishes running
        /// </summary>
        public event Action<Scenario> ScenarioEnd;

        /// <summary>
        /// Occurs when a feature finishes running
        /// </summary>
        public event Action<Feature> FeatureEnd;
    }
}
