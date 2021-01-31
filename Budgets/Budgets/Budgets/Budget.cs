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
    }
}
