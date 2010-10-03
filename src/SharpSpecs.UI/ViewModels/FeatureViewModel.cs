using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SharpSpecs.Framework;

namespace SharpSpecs.UI.ViewModels
{
    public class FeatureViewModel : ViewModel
    {
        private string stateIcon;
        private string featureName;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureViewModel"/> class.
        /// </summary>
        /// <param name="feature">The feature.</param>
        public FeatureViewModel(Feature feature)
        {
            this.Feature = feature;
            this.StateIcon = "Images/notrun.gif";
            this.Scenarios = new ObservableCollection<ScenarioViewModel>(feature.Scenarios.Select(s => new ScenarioViewModel(s)));
            this.FeatureName = feature.Name;
        }

        /// <summary>
        /// Gets or sets the feature.
        /// </summary>
        /// <value>The feature.</value>
        public Feature Feature { get; private set; }        

        /// <summary>
        /// Gets or sets the state icon.
        /// </summary>
        /// <value>The state icon.</value>
        public string StateIcon
        {
            get { return this.stateIcon; }
            set
            {
                this.stateIcon = value;
                this.OnNotifyPropertyChanged("StateIcon");
            }
        }

        /// <summary>
        /// Gets or sets the scenarios.
        /// </summary>
        /// <value>The scenarios.</value>
        public ObservableCollection<ScenarioViewModel> Scenarios { get; private set; }

        /// <summary>
        /// Gets or sets the name of the feature.
        /// </summary>
        /// <value>The name of the feature.</value>
        public string FeatureName
        {
            get { return this.featureName; }
            set
            {
                this.featureName = value;
                this.OnNotifyPropertyChanged("FeatureName");
            }
        }
    }
}
