using System;
using System.Transactions;

namespace hexateArea
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter the edge length: ");
            double edgeLength = Convert.ToDouble(Console.ReadLine());

            double eqOne = Math.Pow(edgeLength, 4);
            double eqTwo = 14*Math.Pow(edgeLength, 3);

            double totalArea = eqOne+eqTwo/Math.Sqrt(2);

            Console.WriteLine($"The total area of the Hexate is: {totalArea} cm⁴");
        }
    }
}