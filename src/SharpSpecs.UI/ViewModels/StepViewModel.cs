using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpSpecs.Framework;

namespace SharpSpecs.UI.ViewModels
{
    public class StepViewModel : ViewModel
    {
        private string stepName;

        /// <summary>
        /// Initializes a new instance of the <see cref="StepViewModel"/> class.
        /// </summary>
        /// <param name="step">The step.</param>
        public StepViewModel(Step step)
        {
            this.StepName = step.Label;
        }

        /// <summary>
        /// Gets or sets the name of the step.
        /// </summary>
        /// <value>The name of the step.</value>
        public string StepName
        {
            get { return this.stepName; }
            set
            {
                this.stepName = value;
                this.OnNotifyPropertyChanged("StepName");
            }
        }
    }
}
