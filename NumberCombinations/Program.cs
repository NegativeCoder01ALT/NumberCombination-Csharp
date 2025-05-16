using System;

namespace numbers
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.Write("Enter the number of digits in the combination (1 to 18): ");
                if (!int.TryParse(Console.ReadLine(), out int digits) || digits < 1 || digits > 18)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 18.");
                    return;
                }

                long max = (long)Math.Pow(10, digits);

                for (long i = 0; i < max; i++)
                {
                    Console.WriteLine(i.ToString().PadLeft(digits, '0'));
                }
            }
        }
    }
}
