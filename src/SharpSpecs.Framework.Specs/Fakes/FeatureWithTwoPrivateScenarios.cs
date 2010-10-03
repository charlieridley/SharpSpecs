using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSpecs.Framework.Specs.Fakes
{
    public class FeatureWithTwoPrivateScenarios : FeatureWithTwoScenariosSteps
    {
        Scenario first_scenario()
        {
            return Given(I_have_a_first_step)
                .When(I_have_a_second_step)
                .Then(I_have_a_third_step);
        }

        Scenario second_scenario()
        {
            return Given(I_have_a_forth_step)
                .When(I_have_a_fifth_step)
                .Then(I_have_a_sixth_step);
        }        
    }

    public class FeatureWithTwoScenariosSteps : Feature
    {
        public bool FirstStepRun { get; private set; }
        public bool SecondStepRun { get; private set; }
        public bool ThirdStepRun { get; private set; }
        public bool ForthStepRun { get; private set; }
        public bool FifthStepRun { get; private set; }
        public bool SixthStepRun { get; private set; }
        public void I_have_a_third_step()
        {
            this.FirstStepRun = true;
        }

        public void I_have_a_second_step()
        {
            this.SecondStepRun = true;
        }

        public void I_have_a_first_step()
        {
            this.ThirdStepRun = true;
        }

        protected void I_have_a_sixth_step()
        {
            this.SixthStepRun = true;
        }


        protected void I_have_a_fifth_step()
        {
            this.FifthStepRun = true;
        }

        protected void I_have_a_forth_step()
        {
            this.ForthStepRun = true;
        }

        
    }
}
