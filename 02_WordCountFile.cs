using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace CodingChallenges_Vol5
{
    class _2_WordCountFile
    {
        static void Main()
        {
            Console.Write("Count the total number of words in a file :\n");

            string fileText = File.ReadAllText(@"Gettysburg.txt");

            int count = 0;
            
            for(int i = 0; i < fileText.Length - 1; i++)        // loop till end of string
            {
                // check whether the current character is white space or new line or tab character
                if (fileText[i] == ' ')
                {
                    count++;
                }
            }

            Console.Write("Total number of words in the string is : {0}\n", count);

        }
    }
}
