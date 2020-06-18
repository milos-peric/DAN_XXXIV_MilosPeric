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
            Console.WriteLine("Current Account balance: {0:C}", Balance);
        }

        public void MakeWithdrawal(int withdrawalAmount)
        {
            if (Balance - withdrawalAmount < 0)
            {
                Console.WriteLine("{0} has failed to withdraw amount: {1:C}. Insufficient funds.", Thread.CurrentThread.Name, withdrawalAmount);
            }
            else
            {
                Balance -= withdrawalAmount;
                Console.WriteLine("{0} has withdrawn money successfully. Amount raised: {1:C}.", Thread.CurrentThread.Name, withdrawalAmount);
            }
        }

    }
}
