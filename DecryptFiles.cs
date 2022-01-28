using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace CodingChallenges_Vol5
{
    class _02_DecryptFiles
    {
        static void Main(string[] args)
        {
            string cipherText;
            int key = 0;

            Console.WriteLine("Fetching text to Decrypt: ");
            cipherText = ReadCipherFile();

            Console.WriteLine("Please input the key used to Encrypt with (0-25): ");
            key = int.Parse(Console.ReadLine());

            cipherText = Caesar(cipherText, key);

            WriteDecryptFile(cipherText);

            Console.WriteLine("Decrypted Message below written to file.");

        }
        //--------------------------- READ FILES -------------------------------------
        static string ReadCipherFile()
        {
            Console.WriteLine("Please input the filename you want to Decrypt: ");
            string filename = Console.ReadLine();

            string filepath = @"H:\Teaching\Computer Science (7517)\01 - Year 1 - AS\Assessment\Programming Challenges\Vol 5 - Text Files\" + filename + ".txt";

            bool FileOK = true;
            string cipherText = "";

            try
            {
                cipherText = File.ReadAllText(filepath);
            }
            catch
            {
                FileOK = false;
            }

            if (FileOK == false)
            {
                Console.WriteLine("File could not be opened.");
            }

            return cipherText;
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
                else                    // subtract the key from the ASCII number to offset and decrypt.
                {
                    newNum = numASCII - Key;

                    if (newNum < 33)   // IF off the start of readable ASCII table
                    {
                        newNum = newNum + 26;       // subtract 26, to go back to start of uppercase characters.
                        newChar = (char)newNum;     // convert to character from calculated number.
                    }
                    else
                        newChar = (char)newNum;
                }
                // insert the newly encrypted character into the 'Encrypted' string.
                cipheredText = cipheredText + newChar;
            }

            Console.WriteLine("Decryption COMPLETE... \n");

            return cipheredText;
        }

        static void WriteDecryptFile(string message)
        {
            Console.WriteLine("Please input the filename you want to save: ");
            string filename = Console.ReadLine();

            string filepath = @"H:\Teaching\Computer Science (7517)\01 - Year 1 - AS\Assessment\Programming Challenges\Vol 5 - Text Files\" + filename + ".txt";

            StreamWriter wFile;
            string FirstLine = "Decrypted Message below:";

            wFile = new StreamWriter(File.Open(filepath, FileMode.Create));
            wFile.WriteLine(FirstLine);
            wFile.WriteLine();
            wFile.WriteLine(message);
            wFile.Close();

            Console.WriteLine("File Written.");

        }
    }
}
