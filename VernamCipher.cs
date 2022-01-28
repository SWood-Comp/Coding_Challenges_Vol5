using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace CodingChallenges_Vol5
{
    class _03_VernamCipher
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ONE TIME PAD - VERNAM CIPHER - PROGRAM\n");
            Console.Write("Enter sentence to encrypt: ");
            string message = Console.ReadLine();

            string key = "";
            Random rnd = new Random();
            int keyCode;

            for (int x = 1; x < message.Length; x++)      // generate a key as long as the original message
            {
                keyCode = rnd.Next(65, 122);
                key += (char)keyCode;
            }

            Console.WriteLine("Key generated is: \n{0}", key);

            string vernam = VernamMessage(message.ToUpper(), key);

            WriteFile(vernam);
            WriteKey(key);

            Console.WriteLine("Done!");     // return here when done.
        }

        static string VernamMessage(string message, string key)
        {
            string cipherText = "";
            char cipherChar, messageChar, keyChar;
            int cipherNum, messageNum, keyNum;

            for (int y = 0; y < message.Length - 1; y++)
            {
                // get the characters
                messageChar = message[y];
                keyChar = key[y];
                // cast to integer form
                messageNum = (int)messageChar;
                keyNum = (int)keyChar;
                // XOR the two integers.
                cipherNum = messageNum ^ keyNum;        // the ^ symbol in C# means XOR. this is where the two characters are XOR'ed.
                // cast back to a usable character
                cipherChar = (char)cipherNum;

                cipherText += cipherChar;
                // now repeat for all remaining characters in the message and key.
            }

            Console.WriteLine("CipherText is: {0}", cipherText);

            return cipherText;
        }

        static void WriteFile(string message)
        {
            string filepath = @"H:\Teaching\Computer Science (7517)\01 - Year 1 - AS\Assessment\Programming Challenges\Vol 5 - Text Files\Code4-Vernam.txt";

            StreamWriter wFile;
            bool FileOK = true;

            try
            {
                wFile = new StreamWriter(File.Open(filepath, FileMode.Create));
                wFile.Write(message);
                wFile.Close();
            }
            catch
            {
                FileOK = false;
            }

            if (!FileOK)
                Console.WriteLine("File could not be opened.");
        }
        static void WriteKey(string key)
        {
            string filepath = @"H:\Teaching\Computer Science (7517)\01 - Year 1 - AS\Assessment\Programming Challenges\Vol 5 - Text Files\Code4-key.txt";

            StreamWriter wFile;
            bool FileOK = true;

            try
            {
                wFile = new StreamWriter(File.Open(filepath, FileMode.Create));
                wFile.Write(key);
                wFile.Close();
            }
            catch
            {
                FileOK = false;
            }

            if (!FileOK)
                Console.WriteLine("File could not be opened.");
        }
    }
}
