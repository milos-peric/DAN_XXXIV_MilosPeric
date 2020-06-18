using System;
using System.Collections.Concurrent;
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
        static void Main(string[] args)
        {
            BankThreadFactory.SetTotalBalance(10000);
            Console.WriteLine("Please enter number of clients for first ATM.");
            BankThreadFactory.CreateThreads("ATM_1", Utility.EnterNumberOfClients());
            Console.WriteLine("Please enter number of clients for second ATM.");
            BankThreadFactory.CreateThreads("ATM_2", Utility.EnterNumberOfClients());
            BankThreadFactory.StartThreadsParallel();
            Console.ReadKey();
        }

    }
}
