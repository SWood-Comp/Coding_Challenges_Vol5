using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace CodingChallenges_Vol5
{
    class _4_WritingPrimesFile
    {
        public static void Main()
        {
            Console.Write("Prime Number Checker: output to a file.\n");
            Console.Write("--------------------------------------------------\n");

            Console.Write("Input Minimum number of range: ");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Minimum number of range: ");
            int max = Convert.ToInt32(Console.ReadLine());

            // Set up a StreamWriter (FileMode is set to Create).
            StreamWriter writeFile = new StreamWriter(File.Open(@"PrimeNumbers.txt", FileMode.Create));

            for (int num = min; num < max; num++)   // iterate over number range entered.
            {
                if (checkPrime(num))    // if checkPrime is TRUE
                {
                    Console.WriteLine("{0} is a prime number", num);  // check output
                    writeFile.Write(num);
                    writeFile.Write("\n");
                }
            }

            writeFile.Close();
        }

        public static bool checkPrime(int num)
        {
            // FOR loop to iterate and check each number we have.
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        
    }
}
