using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using SharpSpecs.Framework;
using SharpSpecs.UI.Controllers;

namespace SharpSpecs.UI.Specs
{
    [Feature]
    public class MainWindowControllerSpecs : MainWindowSteps
    {
        Scenario I_load_a_dll_for_testing()
        {
            return Given(I_have_an_instance_of_the_window)
                    .And(I_have_selected_a_file_to_load)
                    .When(I_press_load)
                    .Then(it_should_show_the_features_on_the_screen);
        }    
    
        Scenario I_run_all_the_features()
        {
            return Given(I_have_an_instance_of_the_window)
                    .And(I_have_selected_a_file_to_load)
                    .And(I_press_load)
                    .When(I_press_run_specs)
                    .Then(it_should_run_all_the_features);
        }
    }

    public class MainWindowSteps : Feature
    {
        private MainWindowController controller;
        private Mock<ISpecRunner> specRunner;
        private IEnumerable<Feature> features;
        protected void I_have_an_instance_of_the_window()
        {
            features = new List<Feature> {this};
            specRunner = new Mock<ISpecRunner>();
            specRunner.Setup(x => x.Load("specs.dll")).Returns(features);
            controller = new MainWindowController(specRunner.Object);
        }                

        protected void I_have_selected_a_file_to_load()
        {
            controller.ViewModel.SelectedFile = "specs.dll";
        }

        protected void I_press_load()
        {
            controller.ViewModel.LoadCommand.Execute(null);
        }

        protected void it_should_show_the_features_on_the_screen()
        {
            controller.ViewModel.Features.ShouldContainOnly(features);
        }

        protected void I_press_run_specs()
        {
            controller.ViewModel.RunAllFeaturesCommand.Execute(null);
        }

        protected void it_should_run_all_the_features()
        {
            specRunner.Verify(x => x.RunAllFeatures());
        }
    }
}
