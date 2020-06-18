using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_XXXIV_MilosPeric
{
    static class BankThreadFactory
    {
        private static Random random = new Random();
        private static BankAccount bankAccount = new BankAccount();
        private static readonly object obj = new object();
        public static List<Thread> threads = new List<Thread>();

        /// <summary>
        /// Allows user to set Total Balance on Bank Account instance.
        /// </summary>
        /// <param name="balance">Total Balance amount.</param>
        public static void SetTotalBalance(int balance)
        {
            bankAccount.Balance = balance;
        }

        /// <summary>
        /// Thread safe version of method which withdraws random (100-10000) amount from Bank Account instance.
        /// Object obj prevents multiple threads from entering a critical section.
        /// </summary>
        public static void ExecuteWithdrawal()
        {
            lock (obj)
            {
                bankAccount.MakeWithdrawal(random.Next(100, 10001));
                bankAccount.PrintAccountBalance();
            }
        }
        
        /// <summary>
        /// Creates threads, generates their names and adds them to local List of threads.
        /// </summary>
        /// <param name="GroupSize">Allows user to specify how many threads per Thread group create.</param>
        /// <param name="terminalName">Allows user to specify terminal name which is used as part of Thread name.</param>
        public static void CreateThreads(string terminalName, int GroupSize)
        {
            for (int i = 1; i <= GroupSize; i++)
            {
                Thread t = new Thread(new ThreadStart(ExecuteWithdrawal));
                t.Name = string.Format("{0}_Client_{1}", terminalName, i);
                threads.Add(t);
            }
        }

        /// <summary>
        /// Starts each thread in local List of threads.
        /// Used for purposes of executing threads as much at same time as possible.
        /// </summary>
        public static void StartThreads()
        {
            foreach (var thread in threads)
            {
                thread.Start();
            }
        }

        /// <summary>
        /// Same as above StartThreads method, the only difference is this one uses
        /// Parralel.For loop instead of foreach.
        /// </summary>
        public static void StartThreadsParallel()
        {
            Parallel.For(0, threads.Count,
                index => {
                    threads.ElementAt(index).Start();
                });
        }


    }
}
