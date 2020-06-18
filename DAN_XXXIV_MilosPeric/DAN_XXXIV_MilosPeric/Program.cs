using System;
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
            Utility.EnterNumberOfClients();
            BankThreadFactory.StartThreads();
            Console.ReadKey();
        }

    }
}
