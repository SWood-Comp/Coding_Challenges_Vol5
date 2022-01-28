using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace CodingChallenges_Vol5
{
    class _5_FibonacciFile
    {
        // create a function to display the fibNum number Fibonacci sequence

        public static int[] Fibo(int fiboNum)
        {
            int[] fibArray = new int[fiboNum];
            fibArray[0] = 0;
            fibArray[1] = 1;

            for (int i = 2; i < fiboNum; i++)
            {
                fibArray[i] = fibArray[i - 1] + fibArray[i - 2];
            }
            return fibArray;
        }

        public static void Main()
        {
            Console.Write("\n\nFunction : To display the fibNum number Fibonacci series :\n");
            Console.Write("------------------------------------------------------------\n");
            Console.Write("Input number of Fibonacci Series wanted: ");
            int fibNum = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("The Fibonacci series of {0} numbers is: ", fibNum);

            int[] numbers = Fibo(fibNum);

            // Set up a StreamWriter (FileMode is set to Create).
            StreamWriter writeFile = new StreamWriter(File.Open(@"Fibonacci.txt", FileMode.Create));

            foreach (int x in numbers)   // iterate over number range entered.
            {
                Console.Write("{0}, ", x);
                writeFile.Write("{0}, ", x);
            }

            writeFile.Close();

            Console.WriteLine();
        }
    }
}
