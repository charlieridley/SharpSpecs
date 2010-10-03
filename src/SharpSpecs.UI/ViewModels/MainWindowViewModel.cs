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
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string selectedFile;
        public MainWindowViewModel()
        {
            this.Features = new ObservableCollection<Feature>();
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
        public ObservableCollection<Feature> Features { get; private set; }

        /// <summary>
        /// Gets or sets the run all specs command.
        /// </summary>
        /// <value>The run all specs command.</value>
        public ICommand RunAllFeaturesCommand { get; set; }

        /// <summary>
        /// Called when the property changes
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void OnNotifyPropertyChanged(string propertyName)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
