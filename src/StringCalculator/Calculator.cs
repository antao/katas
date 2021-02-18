using System.Linq;

namespace StringCalculator
{
    public sealed class Calculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            var array = numbers.Split(',');
            
            return array.Length is 1 ? int.Parse(array[0]) : array.Sum(int.Parse);
        }
    }
}
