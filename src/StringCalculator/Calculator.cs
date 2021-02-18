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
            
            if (array.Length is 1)
            {
                return int.Parse(array[0]);
            }

            return int.Parse(array[0]) + int.Parse(array[1]);
        }
    }
}
