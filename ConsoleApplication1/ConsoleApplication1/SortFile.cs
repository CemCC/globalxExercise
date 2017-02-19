using System;
using System.IO;
using System.Linq;

namespace ApplicationExercise
{
    class SortFile
    {
        static void Main(string[] args)
        {
            SortingFile("C:\\names.txt", "C:\\names-sorted.txt");




            Console.WriteLine("Finished: created names-sorted.txt"); // Keep the Console
            Console.ReadLine();


        }

        static void SortingFile(string FileName, string OutputFile) //sorting function by LinQ
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










    }


}


