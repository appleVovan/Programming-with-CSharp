using System;
using System.Collections.Generic;

namespace AV.ProgrammingWithCSharp.Budgets
{
    class Program
    {
        static void Main(string[] args)
        {
            var transactions = new List<double> { 27.3, 4.8, 384.486 };
            var result = transactions[0];
            result += transactions[1];
            result += transactions[2];
            Console.WriteLine(result);
        }
    }
}
