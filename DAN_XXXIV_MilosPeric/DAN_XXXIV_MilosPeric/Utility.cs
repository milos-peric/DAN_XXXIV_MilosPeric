using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XXXIV_MilosPeric
{
    static class Utility
    {
        /// <summary>
        /// Allows user to enter number of clients.
        /// </summary>
        /// <returns>Number of clients per group</returns>
        public static int EnterNumberOfClients()
        {
            int GroupSize = CheckInputData();
            return GroupSize; 
        }

        /// <summary>
        /// Checks if input is a number, and loops until user enters number
        /// or presses X to skip to advance program.
        /// </summary>
        /// <returns>Validated number of clients.</returns>
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
                    Console.WriteLine("Please enter a number or press X to skip.");
                    if (Console.ReadKey().Key == ConsoleKey.X)
                    {
                        Console.WriteLine("\nInput skipped...");
                        break;
                    }
                }
                else
                {
                    if (value > 0)
                    {
                        numericalValue = value;
                        isNotCorrectInput = false;
                    }
                    else
                    {
                        Console.WriteLine("Number must be greather than zero");
                    }
                }
            } while (isNotCorrectInput);
            return numericalValue;
        }
    }
}
