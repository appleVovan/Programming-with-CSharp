using System;
using System.Collections.Generic;

namespace AV.ProgrammingWithCSharp.Budgets
{
    class Program
    {
        static void Main(string[] args)
        {
            var transactions = new List<double>();
            transactions.Add(27.3);
            transactions.Add(4.8);
            transactions.Add(384.486);
            var result = transactions[0];
            result = result + transactions[1];
            result = result + transactions[2];
            Console.WriteLine(result);
        }
    }
}
