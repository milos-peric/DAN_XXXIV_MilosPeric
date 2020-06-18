using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_XXXIV_MilosPeric
{
    class BankAccount
    {
        public int Balance { get; set; }

        public BankAccount(int balance)
        {
            Balance = balance;
        }

        public void PrintAccountBalance()
        {
            Console.WriteLine("Current Account balance: " + Balance);
        }

        public void MakeWithdrawal(int withdrawalAmount)
        {
            if (Balance - withdrawalAmount < 0)
            {
                Console.WriteLine("{1} attempted to raise amount: {0}. Failed to raise desired ammount. Insufficient funds.", withdrawalAmount, Thread.CurrentThread.Name);
            }
            else
            {
                Balance -= withdrawalAmount;
                Console.WriteLine("{0} raised money successfully. Amount raised: {1}.", Thread.CurrentThread.Name, withdrawalAmount);
            }
        }
    }
}
