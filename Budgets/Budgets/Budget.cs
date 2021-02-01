using System;
using System.Collections.Generic;

namespace AV.ProgrammingWithCSharp.Budgets
{
    class Budget
    {
        private List<double> transactions;
        private string name;

        public Budget(string name)
        {
            transactions = new List<double>();
            this.name = name;
        }


        public void AddTransaction(double transaction)
        {
            transactions.Add(transaction);
        }

        public void ShowStatistics()
        {           
            var result = 0.0;
            var highestTransaction = 0.0;
            var lowestTransaction = 9999.99;

            foreach (double transaction in transactions)
            {
                highestTransaction = Math.Max(transaction, highestTransaction);
                lowestTransaction = Math.Min(transaction, lowestTransaction);
                result += transaction;
            }
            result /= transactions.Count;
            Console.WriteLine($"The average transaction is ${result:N2}");
            Console.WriteLine($"The lowest transaction is ${lowestTransaction} and the highest is ${highestTransaction}.");
        }
    }
}
