using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SharpSpecs.Framework;

namespace SharpSpecs.UI.ViewModels
{
    public class ScenarioViewModel : ViewModel
    {
        private string scenarioName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioViewModel"/> class.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        public ScenarioViewModel(Scenario scenario)
        {
            this.Scenario = scenario;
            this.ScenarioName = scenario.Name;
            this.Steps = new ObservableCollection<StepViewModel>(scenario.Steps.Select(s => new StepViewModel(s)));
        }

        /// <summary>
        /// Gets or sets the scenario.
        /// </summary>
        /// <value>The scenario.</value>
        public Scenario Scenario { get; private set; }

        /// <summary>
        /// Gets or sets the name of the scenario.
        /// </summary>
        /// <value>The name of the scenario.</value>
        public string ScenarioName
        {
            get { return this.scenarioName; }
            private set
            {
                this.scenarioName = value;
                this.OnNotifyPropertyChanged("ScenarioName");
            }
        }

        /// <summary>
        /// Gets or sets the steps.
        /// </summary>
        /// <value>The steps.</value>
        public ObservableCollection<StepViewModel> Steps { get; private set; }
    }
}
