using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public sealed class Calculator
    {
        public int Add(string numbers)
        {
            var delimiters = new List<string> { ",", "\n" };
			if (numbers.StartsWith("//"))
			{
				var lines = numbers.Split('\n');
                numbers = lines[1];
                delimiters.Add(lines[0][2..]);
            }

            var array = numbers.Split(delimiters.ToArray(), StringSplitOptions.None);
            return array.First() == string.Empty ? 0 : array.Sum(int.Parse);
        }
    }
}
