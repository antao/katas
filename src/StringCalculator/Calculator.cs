using System;
using System.Linq;

namespace StringCalculator
{
    public sealed class Calculator
    {
        public int Add(string numbers)
        {
            var array = numbers.Split(new[] { ",", "\n" }, StringSplitOptions.None);
            return array.First() == string.Empty ? 0 : array.Sum(int.Parse);
        }
    }
}
