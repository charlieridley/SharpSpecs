using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Moq;
using SharpSpecs.Framework.Specs.Fakes;
using It = Machine.Specifications.It;

namespace SharpSpecs.Framework.Specs.SpecRunnerSpecs
{
    [Subject(typeof(SpecRunner))]
    public class when_I_load_the_spec_runner : with_spec_runner
    {
        Establish context = I_have_an_instance;
        Because I_load_the_spec_runner = () => loadedFeatures = specRunner.Load("specs.dll");
        It should_load_the_features = () => featureLoader.Verify(x => x.GetFeaturesFromDll("specs.dll"));
        It should_have_the_loaded_features = () => loadedFeatures.ShouldContainOnly(features);
    }

    [Subject(typeof(SpecRunner))]
    public class when_I_run_all_features : with_spec_runner
    {
        Establish context = I_have_a_loaded_instance_containing_1_feature_and_1_scenario;
        Because I_run_all_features = () => specRunner.RunAllFeatures();
        It should_report_that_a_feature_starts_to_run = () => featureBeginResult.ShouldEqual(feature);
        It should_report_that_a_scenario_starts_to_run = () => scenarioBeginResult.ShouldNotBeNull();
        It should_report_that_a_given_step_starts_to_run = () => beginningSteps[0].ShouldBe(typeof(GivenStep));
        It should_report_that_a_given_step_finishes_running = () => endingSteps[0].ShouldBe(typeof(GivenStep));
        It should_report_that_a_when_step_starts_to_runn = () => beginningSteps[1].ShouldBe(typeof(WhenStep));
        It should_report_that_a_when_step_finishes_running = () => endingSteps[1].ShouldBe(typeof(WhenStep));
        It should_report_that_a_then_step_starts_to_runn = () => beginningSteps[2].ShouldBe(typeof(ThenStep));
        It should_report_that_a_then_step_finishes_running = () => endingSteps[2].ShouldBe(typeof(ThenStep));
        It should_report_that_a_scenario_finishes_running = () => scenarioEndResult.ShouldNotBeNull();
        It should_report_that_a_feature_finishes_running = () => featureEndResult.ShouldEqual(feature);
        It should_have_run_the_given_step = () => feature.GivenStepHasRun.ShouldBeTrue();
        It should_have_run_the_when_step = () => feature.WhenStepHasRun.ShouldBeTrue();
        It should_have_run_the_then_step = () => feature.ThenStepHasRun.ShouldBeTrue();
    }

    public class with_spec_runner
    {
        protected static Mock<IFeatureLoader> featureLoader;
        protected static SpecRunner specRunner;
        protected static IEnumerable<Feature> features;
        protected static FeatureWithOneScenarioAndThreeSteps feature;
        protected static Feature featureBeginResult;
        protected static Scenario scenarioBeginResult;
        protected static List<Step> beginningSteps;
        protected static List<Step> endingSteps;
        protected static Scenario scenarioEndResult;
        protected static Feature featureEndResult;
        protected static IEnumerable<Feature> loadedFeatures;
        protected static void I_have_an_instance()
        {
            features = new List<Feature> {new FeatureWithPrivateAndPublicScenarios(), new FeatureWithPrivateAndPublicScenarios()};
            featureLoader = new Mock<IFeatureLoader>();
            featureLoader.Setup(x => x.GetFeaturesFromDll("specs.dll")).Returns(features);
            specRunner = new SpecRunner(featureLoader.Object);
        }

        protected static void I_have_a_loaded_instance_containing_1_feature_and_1_scenario()
        {
            feature = new FeatureWithOneScenarioAndThreeSteps();
            features = new List<Feature> { feature };
            featureLoader = new Mock<IFeatureLoader>();
            featureLoader.Setup(x => x.GetFeaturesFromDll("specs.dll")).Returns(features);
            specRunner = new SpecRunner(featureLoader.Object);
            specRunner.Load("specs.dll");
            SetEvents();
        }

        private static void SetEvents()
        {
            beginningSteps = new List<Step>();
            endingSteps = new List<Step>();
            specRunner.FeatureBegin += f => featureBeginResult = f;
            specRunner.ScenarioBegin += s => scenarioBeginResult = s;
            specRunner.StepBegin += s => beginningSteps.Add(s);
            specRunner.StepEnd += s => endingSteps.Add(s);
            specRunner.ScenarioEnd += s => scenarioEndResult = s;
            specRunner.FeatureEnd += f => featureEndResult = f;
        }
    }
}
