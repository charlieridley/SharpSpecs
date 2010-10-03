using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpSpecs.Framework;

namespace Calculator.Specs
{
    /// <summary>
    /// In order to avoid silly mistakes
    /// As a maths idiot
    /// I want to be told the sum of two numbers
    /// </summary>
    [Feature]
    public class Addition : CalculatorSteps
    {
        Scenario Add_two_numbers()
        {
            return Given(I_have_entered_50_into_the_calculator)
                   .And(I_have_entered_70_into_the_calculator)
                   .When(I_press_add)
                   .Then(the_result_should_be_120_on_the_screen);
        }        
    }

    /// <summary>
    /// In order to avoid silly mistakes
    /// As a maths idiot
    /// I want to be told the difference of two numbers
    /// </summary>
    [Feature]
    public class Subtraction : CalculatorSteps
    {
        Scenario Subtract_a_number()
        {
            return Given(I_have_entered_70_into_the_calculator)
                   .And(I_have_entered_50_into_the_calculator)
                   .When(I_press_subtract)
                   .Then(the_result_should_be_20_on_the_screen);
        }        
    }

    public class CalculatorSteps : Feature
    {
        private readonly MyCalculator calculator = new MyCalculator();
        protected void I_have_entered_50_into_the_calculator()
        {
            calculator.EnterNumber(50);
        }

        protected void I_have_entered_70_into_the_calculator()
        {
            calculator.EnterNumber(70);
        }

        protected void I_press_add()
        {
            calculator.Add();
        }

        public void I_press_subtract()
        {
            calculator.Subtract();
        }

        protected void the_result_should_be_120_on_the_screen()
        {
            calculator.Result.ShouldEqual(120);
        }

        protected void the_result_should_be_20_on_the_screen()
        {
            calculator.Result.ShouldEqual(20);
        }
    }
}
