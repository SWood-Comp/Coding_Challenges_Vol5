using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace CodingChallenges_Vol5
{
    class _04_DecryptVernam
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ONE TIME PAD - VERNAM CIPHER - PROGRAM\n");

            Console.Write("Enter filename to decrypt: ");
            string filename = Console.ReadLine();

            string filepath = @"H:\Teaching\Computer Science (7517)\01 - Year 1 - AS\Assessment\Programming Challenges\Vol 5 - Text Files\" + filename + ".txt";

            string vernamText = "";

            try
            {
                vernamText = File.ReadAllText(filepath);
            }
            catch
            {
                Console.WriteLine("File could not be opened.");
            }

            Console.Write("Enter the key file used to decrypt: ");
            string keyfile = Console.ReadLine();

            string keyfilepath = @"H:\Teaching\Computer Science (7517)\01 - Year 1 - AS\Assessment\Programming Challenges\Vol 5 - Text Files\" + keyfile + ".txt";

            string key = "";

            try
            {
                key = File.ReadAllText(filepath);
            }
            catch
            {
                Console.WriteLine("File could not be opened.");
            }

            // -----------------------------------------------------

            string plain = DecryptVernamMessage(vernamText, key);

            WriteFile(plain);
            Console.WriteLine(plain);

            Console.WriteLine("Done!");     // return here when done.
        }

        static string DecryptVernamMessage(string message, string key)
        {
            string decryptText = "";
            char decryptChar, messageChar, keyChar;
            int decryptNum, messageNum, keyNum;

            Console.WriteLine((char)((int)message[0] ^ (int)key[0]));

            for (int y = 0; y < message.Length - 1; y++)
            {
                // get the characters
                messageChar = message[y];
                keyChar = key[y];
                // cast to integer form
                messageNum = (int)messageChar;
                keyNum = (int)keyChar;
                // XOR the two integers.
                decryptNum = messageNum ^ keyNum;        // the ^ symbol in C# means XOR. this is where the two characters are XOR'ed.
                // cast back to a usable character
                decryptChar = (char)decryptNum;

                decryptText += decryptChar;
                Console.WriteLine("CipherText is: {0}", decryptText);
                // now repeat for all remaining characters in the message and key.
            }

            Console.WriteLine("CipherText is: {0}", decryptText);

            return decryptText;
        }

        static void WriteFile(string message)
        {
            string filepath = @"H:\Teaching\Computer Science (7517)\01 - Year 1 - AS\Assessment\Programming Challenges\Vol 5 - Text Files\Code4-Decrypt.txt";

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
    }
}
