using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpSpecs.Framework;

namespace SharpSpecs.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var specRunner = new SpecRunner();
            specRunner.Load(args[0]);
            specRunner.FeatureBegin += f => System.Console.WriteLine("Feature:" + f.GetFeatureName());
            specRunner.FeatureEnd += f => System.Console.WriteLine("Feature finished");
            specRunner.ScenarioBegin += s => System.Console.WriteLine("Scenario: " + s.Name);
            specRunner.ScenarioEnd += s => System.Console.WriteLine(string.Format("Scenario finshed: {0} step passed, {1} step failed, {2} steps skipped", s.PassedStepCount, s.FailedStepCount, s.SkippedStepCount));
            specRunner.StepBegin += s => System.Console.WriteLine(s.Prefix + " " + s.GetStepName());
            specRunner.StepEnd += StepEnd;
            specRunner.RunAllFeatures();
        }

        private static void StepEnd(Step step)
        {
            if (step.State == StepState.Failed)
            {
                System.Console.WriteLine("Failed: " + step.Exception.Message);
            }
            else
            {
                System.Console.WriteLine(Enum.GetName(typeof(StepState), step.State));
            }
        }       
    }
}
