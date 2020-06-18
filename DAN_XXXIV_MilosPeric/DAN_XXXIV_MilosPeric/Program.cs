using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_XXXIV_MilosPeric
{
    class Program
    {
        public static Random random = new Random();
        public static BankAccount racun = new BankAccount(10000);
        public static readonly object obj = new object();
        public static void ExecuteWithdrawal()
        {
            lock (obj)
            {
                    racun.MakeWithdrawal(random.Next(100, 10001));
                    racun.PrintAccountBalance();
            }

        }

        static void Main(string[] args)
        {
            Console.Write("Enter number of first client group: ");
            int firstGroupSize = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Enter number of second client group: ");
            int secondGroupSize = Convert.ToInt32(Console.ReadLine());
            int sum = firstGroupSize + secondGroupSize;

            List<Thread> threads = new List<Thread>();

            for (int i = 1; i <= firstGroupSize; i++)
            {
                Thread t = new Thread(new ThreadStart(ExecuteWithdrawal));
                t.Name = string.Format("First_ATM_Client_{0}", i);
                Console.WriteLine(t.Name + " created.");
                threads.Add(t);
            }
            for (int i = 1; i <= secondGroupSize; i++)
            {
                Thread t = new Thread(new ThreadStart(ExecuteWithdrawal));
                t.Name = string.Format("Second_ATM_Client_{0}", i);
                Console.WriteLine(t.Name + " created.");
                threads.Add(t);
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            Console.ReadKey();
        }
    }
}
