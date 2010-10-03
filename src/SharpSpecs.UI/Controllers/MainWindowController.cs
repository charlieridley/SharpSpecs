using System;
using System.Collections.Generic;
using System.Linq;
using SharpSpecs.Framework;
using SharpSpecs.UI.Helpers;
using SharpSpecs.UI.ViewModels;

namespace SharpSpecs.UI.Controllers
{
    public class MainWindowController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowController"/> class.
        /// </summary>
        public MainWindowController()
            : this(new SpecRunner())
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowController"/> class.
        /// </summary>
        /// <param name="specRunner">The spec runner.</param>
        public MainWindowController(ISpecRunner specRunner)
        {
            this.SpecRunner = specRunner;
            this.ViewModel = new MainWindowViewModel();
            this.SetCommands();
            this.WireUpEvents();
        }

        /// <summary>
        /// Wires up events.
        /// </summary>
        private void WireUpEvents()
        {
            this.SpecRunner.FeatureBegin += f => this.ViewModel.Features.First(x => x.Feature == f).StateIcon = "Images/running.gif";
            this.SpecRunner.FeatureEnd += f => this.ViewModel.Features.First(x => x.Feature == f).StateIcon = f.State == FeatureState.Passed ? "Images/passed.gif" : "Images/failed.gif";
            
        }

        /// <summary>
        /// Sets the commands.
        /// </summary>
        private void SetCommands()
        {
            this.ViewModel.LoadCommand = new RelayCommand(x => this.Load());
            this.ViewModel.RunAllFeaturesCommand = new RelayCommand(x => this.RunAllFeatures());
        }

        /// <summary>
        /// Runs all specs.
        /// </summary>
        private void RunAllFeatures()
        {
            this.SpecRunner.RunAllFeatures();
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        private void Load()
        {
            IEnumerable<Feature> features = this.SpecRunner.Load(this.ViewModel.SelectedFile);
            this.ViewModel.Features.Clear();
            this.ViewModel.Features.AddRange(features.Select(f => new FeatureViewModel(f)));
        }

        /// <summary>
        /// Gets or sets the spec runner.
        /// </summary>
        /// <value>The spec runner.</value>
        private ISpecRunner SpecRunner { get; set; }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        /// <value>The view model.</value>
        public MainWindowViewModel ViewModel { get; set; }
    }
}
