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

            if (numbers == string.Empty) return 0;

            var array = numbers.Split(delimiters.ToArray(), StringSplitOptions.None);
            var negatives = array.Select(int.Parse).Where(w => w < 0);
            if (negatives.Any())
            {
                throw new ArgumentOutOfRangeException(nameof(numbers), $"negatives not allowed: {string.Join(",", negatives)}");
            }

            return array.Sum(int.Parse);
        }
    }
}
