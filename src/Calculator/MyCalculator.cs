using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    public class MyCalculator
    {
        private readonly List<int> numberList = new List<int>();
        public void EnterNumber(int number)
        {
            numberList.Add(number);
        }

        public void Add()
        {
            int total = numberList.Sum();
            this.Result = total;
        }

        public int Result { get; private set; }

        public void Subtract()
        {
            throw new NotImplementedException();
        }
    }
}
