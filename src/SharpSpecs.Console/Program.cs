using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using SharpSpecs.Framework;

namespace SharpSpecs.Console
{
    class Program
    {
        private static IntPtr hConsole;
        static void Main(string[] args)
        {
            uint STD_OUTPUT_HANDLE = 0xfffffff5;
            hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
            var specRunner = new SpecRunner();
            specRunner.Load(args[0]);
            specRunner.FeatureBegin += f => WriteLine("Feature:" + f.Name, 009);
            specRunner.ScenarioBegin += s => WriteLine("Scenario: " + s.Name, 011);
            specRunner.ScenarioEnd += s => WriteLine(string.Format("Scenario finished: {0} step(s) passed, {1} step(s) failed, {2} step(s) skipped", s.PassedStepCount, s.FailedStepCount, s.SkippedStepCount), 031);
            specRunner.StepBegin += s => WriteLine(s.Label,015);
            specRunner.StepEnd += StepEnd;
            specRunner.RunAllFeatures();
            
        }

        private static void StepEnd(Step step)
        {
            switch (step.State)
            {
                case StepState.Failed:                    
                    WriteLine("Failed: " + step.Exception.Message, 012);
                    break;
                case StepState.Passed:
                    WriteLine(Enum.GetName(typeof(StepState), step.State), 010);
                    break;
                case StepState.Skipped:
                    WriteLine(Enum.GetName(typeof(StepState), step.State), 014);
                    break;
            }            
        }       

        private static void WriteLine(string message, int colourCode)
        {
            SetConsoleTextAttribute(hConsole, colourCode);
            System.Console.Write(message);
            SetConsoleTextAttribute(hConsole, 007);
            System.Console.WriteLine("");
        }

        [DllImport("kernel32.dll")]
        public static extern bool SetConsoleTextAttribute(IntPtr hConsoleOutput, int wAttributes);
        
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetStdHandle(uint nStdHandle);
    }
}
