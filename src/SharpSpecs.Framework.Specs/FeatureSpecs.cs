using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using SharpSpecs.Framework.Specs.Fakes;
using SharpSpecs.Framework.Specs;

namespace SharpSpecs.Framework.SpecificationSpecs
{
    [Subject(typeof(Feature))]
    public class when_I_start_a_scenario_with_given : with_feature
    {
        Establish I_have_a_feature = () => startScenarioTestFeature = new StartScenarioTestFeature();
        Because I_start_a_scenario_with_given = () => givenStep = startScenarioTestFeature.GivenTest();
        It should_create_a_given_step_with_a_step = () => givenStep.Method.ShouldEqual(startScenarioTestFeature.I_have_a_test);
        It should_be_prefixed_with_given = () => givenStep.Prefix.ShouldEqual("Given");
    }

    [Subject(typeof(Feature))]
    public class when_I_start_a_scenario_with_when : with_feature
    {
        Establish I_have_a_feature = () => startScenarioTestFeature = new StartScenarioTestFeature();
        Because I_start_a_scenario_with_when = () => whenStep = startScenarioTestFeature.WhenTest();
        It should_create_a_when_step_with_a_step = () => whenStep.Method.ShouldEqual(startScenarioTestFeature.I_have_a_test);
        It should_be_prefixed_with_when = () => whenStep.Prefix.ShouldEqual("When");
    }

    [Subject(typeof(Feature))]
    public class when_I_have_a_feature_with_two_private_scenarios : with_feature
    {
        Establish context = () => featureWithTwoPrivateScenarios = new FeatureWithTwoPrivateScenarios();
        Because I_get_the_scenarios = () => scenarios = featureWithTwoPrivateScenarios.Scenarios;
        It should_return_two_scenarios = () => scenarios.Count().ShouldEqual(2);
        It should_populate_the_scenario_name = () => scenarios.ElementAt(0).Name.ShouldEqual("first scenario");
        It should_contain_the_feature_name = () => featureWithTwoPrivateScenarios.Name.ShouldEqual("FeatureWithTwoPrivateScenarios");
    }

    [Subject(typeof(Feature))]
    public class when_I_have_a_feature_with_two_private_scenarios_and_two_public_scenarios : with_feature
    {
        Establish context = () => featureWithPrivateAndPublicScenarios = new FeatureWithPrivateAndPublicScenarios();
        Because I_get_the_scenarios = () => scenarios = featureWithPrivateAndPublicScenarios.Scenarios;
        It should_return_two_scenarios = () => scenarios.Count().ShouldEqual(4);
    }

    [Subject(typeof(Feature))]
    public class when_I_have_a_feature_with_passed_scenarios : with_feature
    {
        Establish context = () => featureWithPassedScenarios = new FeatureWithPassedScenarios();
        It should_be_in_a_passed_state = () => featureWithPassedScenarios.State.ShouldEqual(FeatureState.Passed);
    }

    [Subject(typeof(Feature))]
    public class when_I_have_a_feature_with_a_failed_on_assert_scenario : with_feature
    {
        Establish context = () => featureWithAFailedOnAssertScenario = new FeatureWithAFailedOnAssertScenario();
        It should_be_in_a_failed_state = () => featureWithAFailedOnAssertScenario.State.ShouldEqual(FeatureState.Failed);
    }

    [Subject(typeof(Feature))]
    public class when_I_have_a_feature_with_a_failed_on_setup_scenario : with_feature
    {
        Establish context = () => featureWithAFailedOnSetupScenario = new FeatureWithAFailedOnSetupScenario();
        It should_be_in_a_failed_state = () => featureWithAFailedOnSetupScenario.State.ShouldEqual(FeatureState.Failed);
    }

    [Subject(typeof(Feature))]
    public class when_I_have_a_feature_with_scenarios_which_havent_been_run : with_feature
    {
        Establish context = () => featureWithScenariosWhichHaventBeenRun = new FeatureWithScenariosWhichHaventBeenRun();
        It should_be_in_a_not_run_state = () => featureWithScenariosWhichHaventBeenRun.State.ShouldEqual(FeatureState.NotRun);
    }

    public class with_feature
    {
        protected static StartScenarioTestFeature startScenarioTestFeature;
        protected static FeatureWithTwoPrivateScenarios featureWithTwoPrivateScenarios;
        protected static FeatureWithPrivateAndPublicScenarios featureWithPrivateAndPublicScenarios;
        protected static GivenStep givenStep;
        protected static WhenStep whenStep;
        protected static IEnumerable<Scenario> scenarios;
        protected static FeatureWithPassedScenarios featureWithPassedScenarios;
        protected static FeatureWithAFailedOnAssertScenario featureWithAFailedOnAssertScenario;
        protected static FeatureWithAFailedOnSetupScenario featureWithAFailedOnSetupScenario;
        protected static FeatureWithScenariosWhichHaventBeenRun featureWithScenariosWhichHaventBeenRun;
    }
}
