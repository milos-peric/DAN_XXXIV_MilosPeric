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
        private static BankAccount bankAccount = new BankAccount(10000);
        private static readonly object obj = new object();
        public static List<Thread> threads = new List<Thread>();

        public static void ExecuteWithdrawal()
        {
            lock (obj)
            {
                bankAccount.MakeWithdrawal(random.Next(100, 10001));
                bankAccount.PrintAccountBalance();
            }
        }

        public static void StartThreads(List<Thread> threadList)
        {
            foreach (var thread in threads)
            {
                thread.Start();
            }
        }

        public static void CreateThreads(int firstGroupSize, string terminalName)
        {
            for (int i = 1; i <= firstGroupSize; i++)
            {
                Thread t = new Thread(new ThreadStart(ExecuteWithdrawal));
                t.Name = string.Format("{0}_Client_{1}", terminalName, i);
                threads.Add(t);
            }
        }

    }
}
