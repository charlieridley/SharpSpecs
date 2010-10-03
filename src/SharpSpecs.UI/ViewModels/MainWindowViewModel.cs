using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using SharpSpecs.Framework;

namespace SharpSpecs.UI.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private string selectedFile;
        public MainWindowViewModel()
        {
            this.Features = new ObservableCollection<FeatureViewModel>();
        }

        /// <summary>
        /// Gets or sets the selected file.
        /// </summary>
        /// <value>The selected file.</value>
        public string SelectedFile
        {
            get { return this.selectedFile; }
            set
            {
                this.selectedFile = value;
                this.OnNotifyPropertyChanged("SelectedFile");
            }
        }

        /// <summary>
        /// Gets or sets the load command.
        /// </summary>
        /// <value>The load command.</value>
        public ICommand LoadCommand { get; set; }

        /// <summary>
        /// Gets or sets the features.
        /// </summary>
        /// <value>The features.</value>
        public ObservableCollection<FeatureViewModel> Features { get; private set; }

        /// <summary>
        /// Gets or sets the run all specs command.
        /// </summary>
        /// <value>The run all specs command.</value>
        public ICommand RunAllFeaturesCommand { get; set; }        
    }
}
