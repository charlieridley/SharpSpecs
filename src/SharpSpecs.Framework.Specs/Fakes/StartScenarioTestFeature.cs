namespace SharpSpecs.Framework.Specs.Fakes
{
    public class StartScenarioTestFeature : Feature
    {
        public GivenStep GivenTest()
        {
            return Given(I_have_a_test);
        }

        public WhenStep WhenTest()
        {
            return When(I_have_a_test);
        }

        public void I_have_a_test()
        {

        }
    }
}