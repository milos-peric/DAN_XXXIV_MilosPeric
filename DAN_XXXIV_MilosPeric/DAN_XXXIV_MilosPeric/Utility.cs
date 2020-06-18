using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XXXIV_MilosPeric
{
    static class Utility
    {
        public static void EnterNumberOfClients()
        {
            Console.Write("Enter number of first client group: ");
            int firstGroupSize = CheckInputData();
            Console.WriteLine();
            Console.Write("Enter number of second client group: ");
            int secondGroupSize = CheckInputData();
            BankThreadFactory.CreateThreads(firstGroupSize, "ATM_1");
            BankThreadFactory.CreateThreads(secondGroupSize, "ATM_2");
        }

        public static int CheckInputData()
        {
            int numericalValue = 0;
            bool isNotCorrectInput = true;
            do
            {
                string input = Console.ReadLine();
                bool isANumber = Int32.TryParse(input, out int value);
                if (isANumber == false)
                {
                    Console.WriteLine("Please enter a number.");
                }
                else
                {
                    numericalValue = value;
                    isNotCorrectInput = false;
                }
            } while (isNotCorrectInput);
            return numericalValue;
        }
    }
}
