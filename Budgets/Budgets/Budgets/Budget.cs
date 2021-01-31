using System.Collections.Generic;

namespace AV.ProgrammingWithCSharp.Budgets
{
    class Budget
    {
        List<double> transactions;

        public Budget()
        {
            transactions = new List<double>();
        }


        public void AddTransaction(double transaction)
        {
            transactions.Add(transaction);
        }
    }
}
