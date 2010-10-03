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
    public class when_I_start_a_scenario : with_feature
    {
        Establish I_have_a_feature = () => startScenarioTestFeature = new StartScenarioTestFeature();
        Because I_start_a_scenario = () => givenStep = startScenarioTestFeature.GivenTest();
        It should_create_a_given_conditon_with_a_step = () => givenStep.Method.ShouldEqual(startScenarioTestFeature.I_have_a_test);        
    }

    [Subject(typeof(Feature))]
    public class when_I_have_a_feature_with_two_private_scenarios : with_feature
    {
        Establish context = () => featureWithTwoPrivateScenarios = new FeatureWithTwoPrivateScenarios();
        Because I_get_the_scenarios = () => scenarios = featureWithTwoPrivateScenarios.GetScenarios();
        It should_return_two_scenarios = () => scenarios.Count().ShouldEqual(2);
        It should_populate_the_scenario_name = () => scenarios.ElementAt(0).Name.ShouldEqual("first scenario");
        It should_contain_the_feature_name = () => featureWithTwoPrivateScenarios.GetFeatureName().ShouldEqual("FeatureWithTwoPrivateScenarios");
    }

    [Subject(typeof(Feature))]
    public class when_I_have_a_feature_with_two_private_scenarios_and_two_public_scenarios : with_feature
    {
        Establish context = () => featureWithPrivateAndPublicScenarios = new FeatureWithPrivateAndPublicScenarios();
        Because I_get_the_scenarios = () => scenarios = featureWithPrivateAndPublicScenarios.GetScenarios();
        It should_return_two_scenarios = () => scenarios.Count().ShouldEqual(4);
    }

    public class with_feature
    {
        protected static StartScenarioTestFeature startScenarioTestFeature;
        protected static FeatureWithTwoPrivateScenarios featureWithTwoPrivateScenarios;
        protected static FeatureWithPrivateAndPublicScenarios featureWithPrivateAndPublicScenarios;
        protected static GivenStep givenStep;
        protected static IEnumerable<Scenario> scenarios;
    }
}
