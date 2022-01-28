using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace CodingChallenges_Vol5
{
    class _3_FilterStudentsBySubject
    {
        static void Main()
        {
            Console.Write("Output the students who study a certain subject:\n");

            string[] records = File.ReadAllLines(@"StudentSubjects.txt");       // Reads ALL Lines into a string array

            Console.WriteLine("Please Enter the Subject you are looking for: ");
            string subject = Console.ReadLine();

            Console.WriteLine("The students who study {0} are as follows:", subject);

            foreach (string student in records)     // iterate through the array of students
            {
                if(student.Contains(subject))       // if that entry conatins the subject name somewhere, no given order
                {
                    int commaIndex = student.IndexOf(',');      // get the index of comma to split the name off.
                    Console.WriteLine(student.Substring(0, commaIndex));       // outputs each name from the array onto a new line.
                }
                
            }
        }
    }
}
