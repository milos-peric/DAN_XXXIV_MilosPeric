﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_XXXIV_MilosPeric
{
    class Program
    {
        private static Random random = new Random();
        private static BankAccount bankAccount = new BankAccount(10000);
        private static readonly object obj = new object();
        private static List<Thread> threads = new List<Thread>();

        public static void ExecuteWithdrawal()
        {
            lock (obj)
            {
                bankAccount.MakeWithdrawal(random.Next(100, 10001));
                bankAccount.PrintAccountBalance();
            }
        }

        static void Main(string[] args)
        {
            EnterNumberOfClients();

            Console.ReadKey();
        }

        public static void EnterNumberOfClients()
        {
            Utility.EnterNumberOfClients();
            Utility.StartExecution();
        }
    }
}
