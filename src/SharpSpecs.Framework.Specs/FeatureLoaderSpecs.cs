using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace SharpSpecs.Framework.Specs.FeatureLoaderSpecs
{
    [Subject(typeof(FeatureLoader))]
    public class when_I_load_a_dummy_dll_with_2_features : with_feature_loader
    {
        Because I_load_the_featueres_from_the_dll = () => features = new FeatureLoader().GetFeaturesFromDll("Calculator.Specs.dll");
        It should_return_a_collection_of_two_features = () => features.Count().ShouldEqual(2);
    }

    public class with_feature_loader
    {
        protected static IEnumerable<Feature> features;
    }
}
