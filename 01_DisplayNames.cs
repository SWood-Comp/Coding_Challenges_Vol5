using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace CodingChallenges_Vol5
{
    class _1_DisplayNames
    {
        static void Main()
        {
            Console.Write("Display the comma separated names in a file :\n");

            string fileText = File.ReadAllText(@"Students.txt");

            string[] names = fileText.Split(',');   // splits the 'fileText' whenever a ',' is found (becomes a new element in the Array)

            foreach(string n in names)
            {
                Console.WriteLine(n);       // outputs each name from the array onto a new line.
            }
           
        }
    }
}
