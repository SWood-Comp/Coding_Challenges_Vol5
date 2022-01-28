using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace CodingChallenges_Vol5
{
    class _6_BinaryFileUsingStructs
    {
        /*
        Name: Dave Jones
        Car Reg: FF19 STG
        Date: 19/01/2019
        Location: Leeds
        Vehicles: 4
        */
        public struct ClaimDetails
        {
            public string ClaimantName;
            public string CarReg;
            public string AccidentDate;
            public string Location;
            public int NumVehicles;

        }

        public static void Main()
        {
            Console.Write("Create a Binary File to store details using a STRUCT:\n");

            ClaimDetails myClaim = SetUpClaimDetails();     // Populate the Struct ClaimDetails elsewhere

            writeBinaryFile(myClaim);   // call subroutine to do the writing of the file.
        }

        public static ClaimDetails SetUpClaimDetails()
        {
            ClaimDetails myClaim = new ClaimDetails();

            Console.Write("Please enter your Full Name:  ");
            myClaim.ClaimantName = Console.ReadLine();
            Console.Write("Please enter your Vehicle Registration:  ");
            myClaim.CarReg = Console.ReadLine();
            Console.Write("Please enter the Date of the Accident:  ");
            myClaim.AccidentDate = Console.ReadLine();
            Console.Write("Please enter the Location that the accident took place:  ");
            myClaim.Location = Console.ReadLine();
            Console.Write("Please enter the Number of Vehicles involved in the accident:  ");
            myClaim.NumVehicles = int.Parse(Console.ReadLine());

            return myClaim;
        }

        public static void writeBinaryFile(ClaimDetails myClaim)
        {
            string binaryFilepath = @"Claim_Details.bin";       // set filepath
            BinaryWriter writeBinFile = new BinaryWriter(File.Open(binaryFilepath, FileMode.Create));   // write bin file setup

            writeBinFile.Write("Claimant Name:");
            writeBinFile.Write(myClaim.ClaimantName);
            writeBinFile.Write("Car Registration:");
            writeBinFile.Write(myClaim.CarReg);
            writeBinFile.Write("Accident Date:");
            writeBinFile.Write(myClaim.AccidentDate);
            writeBinFile.Write("Location of Accident:");
            writeBinFile.Write(myClaim.Location);
            writeBinFile.Write("Number of Vehicles:");
            writeBinFile.Write(myClaim.NumVehicles);

            writeBinFile.Close();                      // close the BinaryWriter when done.

            Console.WriteLine("Binary File Written.");
        }
    }
}
