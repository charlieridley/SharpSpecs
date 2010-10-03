using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SharpSpecs.UI.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Called when the property changes
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void OnNotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
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
