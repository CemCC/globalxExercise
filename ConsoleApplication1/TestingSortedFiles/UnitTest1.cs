using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Linq;

namespace TestingSortedFiles
{
    [TestClass]
    public class ApplicationExerciseTest
    {
        public string GetFileHash(string filename)
        {
            var hash = new SHA1Managed();
            var clearBytes = File.ReadAllBytes(filename);
            var hashedBytes = hash.ComputeHash(clearBytes);
            return ConvertBytesToHex(hashedBytes);
        }

        public string ConvertBytesToHex(byte[] bytes)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x"));
            }
            return sb.ToString();
        }

        static void SortingFile(string FileName, string OutputFile) //sorting function by LinQ /*For some Reason It cannot see this function from the reference, I think it's about Test Settings*/
        {
            var lines = File.ReadLines(FileName)
                .Select(x => x.Split(',').ToArray()) //Make the list
                .OrderBy(x => x[0])
                .ThenBy(x => x[1])
                .Select(x => string.Join(",", x)); //sorted depending on Surname Name..!! //It does the job for Testing

            Console.WriteLine("sort-names c:\\names.txt");

            foreach (string line in lines) // Printing
            {
                Console.WriteLine(line);
            }

            File.CreateText(OutputFile).Close(); //Creating file

            File.WriteAllLines(OutputFile, lines); // Writing Sorted Values
        }



        [TestMethod]
        public void CompareSortedFiles() //Aim is comparing Same string values in the 2 different texts. RamdomNames.txt(manually Created) has got same names, but they are in different order. If the original sorted file ("C:\\names-sorted.txt") equals to "D:\\RandomSortedNames.txt", Sorting function is working
        {   //Arrange
            //Call your random file
           SortingFile("D:\\RandomNames.txt", "D:\\RandomSortedNames.txt"); /* As I mentioned above for some reason VS doesn's recognise my SortingFile()*/
                                                                             // If it's recognised, Code should be ;

            //SortFile.SortingFile("D:\\RandomNames.txt", "D:\\RandomSortedNames.txt");
           
            const string originalFile = "C:\\names-sorted.txt"; //comperasion of File elements 
            const string copiedFile = "D:\\RandomSortedNames.txt";
            //Act
            var originalHash = GetFileHash(originalFile);
            var copiedHash = GetFileHash(copiedFile);
            //assert
            Assert.AreEqual(copiedHash, originalHash);
        }
    }
}
