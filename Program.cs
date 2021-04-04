using System;
using System.Diagnostics;
using System.IO;

namespace DuplicateFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            //get the path
            Console.WriteLine("Please introduce the path for search for duplicates");
            string pathFile = Console.ReadLine();

            //Get files on the path
            String[] filePath = Directory.GetFiles(@pathFile);
            Debug.Print(filePath.Length.ToString());
            
            
            // String b is a aux variable since with the array sort we are sorting the items if the string of the current element in b is iqual to the next element in b then the item is repeated
            string b = null;

            // n is a aux variable to insert elements in the variable repeat without using a fori cicle
            int n = 0;

            // the next 2 variable are use to inicialize with the size of the folder in analize
            int filepathsize = filePath.Length;
            string[] repeat = new string[filepathsize];

            Console.WriteLine("The path in analize have " + filepathsize + " files.");

            try
            {
                foreach (string name in filePath)
                {

                    FileInfo info = new FileInfo(name);
                    repeat[n] = info.Length.ToString();
                    n++;

                }
                Array.Sort(repeat, StringComparer.Ordinal);

                n = 0;

                for (int i = 0; i < filepathsize; i++)
                {


                    if (b == repeat[i] && i != 0)
                    {

                        Console.WriteLine(" The file with " + repeat[i] + " bytes is repeated");
                        n++;            
                        //debug just for testing
                        //Debug.Print(repeat[i]);
                    }
                    else
                    {
                        b = repeat[i];
                       
                    }

                }

                if (n == 0)
                {
                    Console.WriteLine("The Path dont have any repeated file.");
                }

            }
            catch (Exception wqe)
            {
                Debug.Print(wqe.Message);
            }
        }
    }
}
