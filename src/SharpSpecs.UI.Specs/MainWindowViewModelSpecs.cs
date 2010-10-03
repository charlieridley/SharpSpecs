using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpSpecs.Framework;
using SharpSpecs.UI.ViewModels;

namespace SharpSpecs.UI.Specs
{
    [Feature]
    public class MainWindowViewModelSpecs : MainWindowViewModelSteps
    {
        Scenario creating_an_instance()
        {
            return When(I_create_an_instance)
                .Then(I_should_have_an_instantiated_features_collection);
        }        
    }

    public class MainWindowViewModelSteps : Feature
    {
        private MainWindowViewModel viewModel;
        protected void I_create_an_instance()
        {
            viewModel = new MainWindowViewModel();
        }

        protected void I_should_have_an_instantiated_features_collection()
        {
            viewModel.Features.ShouldNotBeNull();
        }
    }
}
