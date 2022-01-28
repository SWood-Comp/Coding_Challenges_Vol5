using System;
using System.IO;

namespace CodingChallenges_Vol5
{
    class _0_EncryptionProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 - Encrypt \n2 - Decrypt \n3 - Brute Force");
            Console.WriteLine("Enter your choice below:");

            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
                StartCaesar();
            else if (choice == 2)
                StartDecryption();
        }

        // -------------------------- ENCRYPTION -------------------------------------
        static void StartCaesar()
        {
            string plainText = "", cipherText = "";
            int key = 0;

            Console.WriteLine("Please input the filename you want to Encrypt: ");
            string filename = Console.ReadLine();

            string filepath = @"H:\Teaching\Computer Science (7517)\01 - Year 1 - AS\Assessment\Programming Challenges\Vol 5 - Text Files\" + filename + ".txt";

            StreamReader rFile;
            bool FileOK = true;

            try
            {
                rFile = new StreamReader(filepath);
                plainText = rFile.ReadToEnd();
                rFile.Close();

                Console.WriteLine(plainText);

                // Encrypt below...
                Console.WriteLine("Please input a key to Encrypt with (1-50): ");
                key = int.Parse(Console.ReadLine());

                cipherText = Caesar(plainText, key);

                Console.WriteLine("Encrypted Message below: \n{0}", cipherText);
            }
            catch
            {
                FileOK = false;
            }

            if (!FileOK)
                Console.WriteLine("File could not be opened.");

        }

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
                else if(numASCII == 13)
                {
                    newChar = '\n';
                }
                else                    // add the ASCII number to the offset factor.
                {
                    newNum = numASCII + Key;

                    if (newNum > 126)   // IF off the end of readable ASCII table
                    {
                        newNum = newNum - 94;       // subtract 94, to go back to start of readable characters.
                        newChar = (char)newNum;     // convert to character from calculated number.
                    }
                    else
                        newChar = (char)newNum;
                }
                // insert the newly encrypted character into the 'Encrypted' string.
                cipheredText += newChar;
            }

            Console.WriteLine("Encryption COMPLETE... \n");

            return cipheredText;
        }

        //--------------------------- DECRYPTION -------------------------------------------------------

        static void StartDecryption()
        {
            string plainText = "", cipherText = "";
            int decryptkey = 0;

            Console.WriteLine("Please input a string you want to Decrypt: ");
            string filename = Console.ReadLine();

            string filepath = @"H:\Teaching\Computer Science (7517)\01 - Year 1 - AS\Assessment\Programming Challenges\Vol 5 - Text Files\" + filename + ".txt";

            StreamReader rFile;
            bool FileOK = true;

            try
            {
                rFile = new StreamReader(filepath);
                cipherText = rFile.ReadToEnd();
                rFile.Close();

                Console.WriteLine("Please input a key to Decrypt with (1 to 50): ");
                decryptkey = int.Parse(Console.ReadLine());

                plainText = DecryptCaesar(cipherText, decryptkey);     // pass decryptkey (negative)

                Console.WriteLine("Decrypted Message below: \n{0}", plainText);
            }
            catch
            {
                FileOK = false;
            }

            if (!FileOK)
                Console.WriteLine("File could not be opened.");

        }

        static string DecryptCaesar(string Text, int Key)
        {
            string plainText = "";
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
                else if (numASCII == 13)
                {
                    newChar = '\n';
                }
                else                    // add the ASCII number to the offset factor.
                {
                    newNum = numASCII - Key;    // SUBTRACT the key when decrypting.

                    if (newNum < 33)   // IF off the end of readable ASCII table
                    {
                        newNum = newNum + 94;       // add 94, to go back to end of readable characters.
                        newChar = (char)newNum;     // convert to character from calculated number.
                    }
                    else
                        newChar = (char)newNum;
                }
                // insert the newly encrypted character into the 'Encrypted' string.
                plainText = plainText + newChar;
            }

            Console.WriteLine("Encryption COMPLETE... \n");

            return plainText;
        }
    }
}
