using System;
using System.Collections.Generic;

namespace AV.ProgrammingWithCSharp.Budgets
{
    class Program
    {
        static void Main(string[] args)
        {
            var transactions = new List<double> { 27.3, 4.8, 384.486 };

            var result = 0.0;

            foreach (double transaction in transactions)
            {
                result += transaction;
            }
            result /= transactions.Count;
            Console.WriteLine($"The average transaction is ${result:N2}");
        }
    }
}
