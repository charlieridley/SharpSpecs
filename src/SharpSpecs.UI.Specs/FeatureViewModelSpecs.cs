using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpSpecs.Framework;
using SharpSpecs.UI.ViewModels;

namespace SharpSpecs.UI.Specs
{
    [Feature]
    public class FeatureViewModelSpecs : FeatureViewModelSteps
    {
        Scenario creating_an_instance()
        {
            return Given(I_have_a_feature)
                .When(I_create_an_instance)
                .Then(it_should_have_reference_to_the_feature)
                .And(it_should_contain_a_collection_of_scenario_view_models)
                .And(the_view_model_should_show_a_not_running_icon)
                .And(it_should_have_the_feature_name);
        }        
    }

    public class FeatureViewModelSteps : Feature
    {
        private Feature feature;
        private FeatureViewModel viewModel;
        protected void I_have_a_feature()
        {
            feature = new FeatureViewModelSpecs();
        }

        protected void I_create_an_instance()
        {
            viewModel = new FeatureViewModel(feature);
        }

        protected void it_should_have_reference_to_the_feature()
        {
            viewModel.Feature.ShouldEqual(feature);
        }

        protected void the_view_model_should_show_a_not_running_icon()
        {
            viewModel.StateIcon.ShouldEqual("Images/notrun.gif");
        }

        protected void it_should_contain_a_collection_of_scenario_view_models()
        {
            viewModel.Scenarios.Count.ShouldEqual(feature.Scenarios.Count());
        }

        protected void it_should_have_the_feature_name()
        {
            viewModel.FeatureName.ShouldEqual(feature.Name);
        }
    }
}
