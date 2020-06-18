using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XXXIV_MilosPeric
{
    class BankAccount
    {
        public decimal Amount { get; }

        public BankAccount(decimal amount)
        {
            Amount = amount;
        }

        public void PrintAccountBalance()
        {
            Console.WriteLine("Acount balance: " + Amount);
        }
    }
}
