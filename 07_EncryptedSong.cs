using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace CodingChallenges_Vol5
{
    class _7_EncryptedSong
    {
        static void Main(string[] args)
        {
            string[] cipherLines;
            string decrypted = "";
            Console.WriteLine("Fetching text to Decrypt: ");
            cipherLines = ReadCipherFile();

            for (int key = 0; key <= 25; key++)
            {
                Console.WriteLine("Key used: {0}", key);
                decrypted = Caesar(cipherLines, key);
                Console.WriteLine(decrypted);
            }
            //WriteDecryptFile(cipherText);
            //Console.WriteLine("Decrypted Message below written to file.");

        }
        //--------------------------- READ FILES -------------------------------------
        static string[] ReadCipherFile()
        {
            bool FileOK;
            string[] cipherText = { };
            do
            {
                Console.WriteLine("Please input the filename you want to Decrypt: ");
                string filename = Console.ReadLine();
                string filepath = @"Encrypted Files\" + filename + ".txt";
                FileOK = true;
                
                try
                {
                    cipherText = File.ReadAllLines(filepath);
                }
                catch
                {
                    FileOK = false;
                }

                if (FileOK == false)
                {
                    Console.WriteLine("File could not be opened.");
                }
            } while (FileOK == false);

            return cipherText;
        }

        // -------------------------- DECRYPTION - Line by Line -------------------------------------
        static string Caesar(string[] Text, int Key)
        {
            string plainText = "";
            int numASCII = 0;
            int newNum = 0;
            char newChar;
            foreach (string line in Text)
            {
                foreach (char c in line)
                {
                    numASCII = (int)c;      // convert char to ASCII value.

                    if (numASCII == 32)     // if the ASCII value is 32, it is a[space] so keep it the same.
                    {
                        newChar = c;        // keep it as it is a space.
                    }
                    else                    // subtract the key from the ASCII number to offset and decrypt.
                    {
                        newNum = numASCII - Key;

                        if (newNum < 65)   // IF off the start of readable ASCII table
                        {
                            newNum = newNum + 26;       // add 26, to go back to start of uppercase characters.
                            newChar = (char)newNum;     // convert to character from calculated number.
                        }
                        else if (newNum > 72 && newNum < 97)   // IF off the start of readable ASCII table
                        {
                            newNum = newNum + 26;       // add 26, to go back to start of uppercase characters.
                            newChar = (char)newNum;     // convert to character from calculated number.
                        }
                        else
                            newChar = (char)newNum;
                    }
                    // insert the newly decrypted character into the 'Decrypted' string.
                    plainText = plainText + newChar;
                }
                plainText = plainText + "\n";
            }

            Console.WriteLine("Decryption COMPLETE... \n");

            return plainText;
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
