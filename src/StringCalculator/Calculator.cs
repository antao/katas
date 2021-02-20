using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public sealed class Calculator
    {
        public int Add(string numbers)
        {
            if (numbers == string.Empty) return 0;

            var delimiters = new List<string> { ",", "\n" };
			if (numbers.StartsWith("//"))
			{
				var lines = numbers.Split('\n');
                numbers = lines[1];
                delimiters.Add(lines[0][2..].Replace("[", string.Empty).Replace("]", string.Empty));
            }

            var array = numbers.Split(delimiters.ToArray(), StringSplitOptions.None);
            var integers = array.Select(int.Parse).Where(w => w <= 1000);
            var negatives = integers.Where(w => w < 0);
            if (negatives.Any())
            {
                throw new ArgumentOutOfRangeException(nameof(numbers), $"negatives not allowed: {string.Join(",", negatives)}");
            }

            return integers.Sum();
        }
    }
}
