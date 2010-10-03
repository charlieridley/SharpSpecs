using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSpecs.Framework.Specs.Fakes
{
    public class FeatureWithFailingScenario : FeatureWithFailingScenarioSteps
    {
        Scenario a_failing_scenario()
        {
            return Given(I_have_a_step_which_works_just_fine)
                   .When(I_do_something_perfectly_acceptable)
                   .Then(I_go_and_spoil_it_all_by_saying_something_stupid_like)
                   .And(now_this_step_wont_run);
        }        
    }

    public class FeatureWithFailingScenarioSteps : Feature
    {
        protected void I_have_a_step_which_works_just_fine()
        {
            
        }

        protected void I_do_something_perfectly_acceptable()
        {
            
        }

        protected void I_go_and_spoil_it_all_by_saying_something_stupid_like()
        {
            throw new StackOverflowException("I love you");
        }

        protected void now_this_step_wont_run()
        {
            
        }
    }
}
