using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace CodingChallenges_Vol5
{
    class _01_EncryptFiles
    {
        static void Main(string[] args)
        {
            string plainText, cipherText;
            int key = 0;

            Console.WriteLine("Fetching text to Encrypt: ");
            plainText = ReadPlainFile();

            Console.WriteLine("Please input a key to Encrypt with (0-25): ");
            key = int.Parse(Console.ReadLine());

            cipherText = Caesar(plainText, key);

            WriteCipherFile(cipherText);

            Console.WriteLine("Encrypted Message below written to file.");

        }
        //--------------------------- READ FILES -------------------------------------
        static string ReadPlainFile()
        {
            Console.WriteLine("Please input the filename you want to Encrypt: ");
            string filename = Console.ReadLine();

            string filepath = @"H:\Teaching\Computer Science (7517)\01 - Year 1 - AS\Assessment\Programming Challenges\Vol 5 - Text Files\" + filename + ".txt";

            bool FileOK = true;
            string plainText = "";

            try
            {
                plainText = File.ReadAllText(filepath);
            }
            catch
            {
                FileOK = false;
            }

            if (FileOK == false)
            {
                Console.WriteLine("File could not be opened.");
            }

            return plainText;
        }

        // -------------------------- ENCRYPTION -------------------------------------
        static string Caesar(string Text, int Key)
        {
            string cipheredText = "";
            int numASCII = 0;
            int newNum = 0;
            char newChar;

            foreach (char c in Text)
            {
                numASCII = (int)c;      // convert char to ASCII value.

                if (numASCII == 32)     // if the ASCII value is 32, it is a[space] so keep it the same.
                {
                    newChar = c;        // keep it as it is a space.
                }
                else                    // add the ASCII number to the offset factor.
                {
                    newNum = numASCII + Key;

                    if (newNum > 90)   // IF off the end of readable uppercase ASCII table
                    {
                        newNum = newNum - 26;       // subtract 26, to go back to start of uppercase characters.
                        newChar = (char)newNum;     // convert to character from calculated number.
                    }
                    else
                        newChar = (char)newNum;
                }
                // insert the newly encrypted character into the 'Encrypted' string.
                cipheredText = cipheredText + newChar;
            }

            Console.WriteLine("Encryption COMPLETE... \n");

            return cipheredText;
        }

        static void WriteCipherFile(string cipherText)
        {
            Console.WriteLine("Please input the filename you want to save: ");
            string filename = Console.ReadLine();

            string filepath = @"H:\Teaching\Computer Science (7517)\01 - Year 1 - AS\Assessment\Programming Challenges\Vol 5 - Text Files\" + filename + ".txt";

            StreamWriter wFile;
            string FirstLine = "Encrypted Message below:";

            wFile = new StreamWriter(File.Open(filepath, FileMode.Create));
            wFile.WriteLine(FirstLine);
            wFile.WriteLine();
            wFile.WriteLine(cipherText);
            wFile.Close();

            Console.WriteLine("File Written.");

        }
    }
}
