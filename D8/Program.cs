using System;
using System.IO;
using System.Collections.Generic;

namespace D8
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputFile = File.ReadAllLines(@"..\OpdrachtGegevens\D8O1.txt");
            ImageFile password = new ImageFile(inputFile[0]);
            password.printLayers();
            Console.WriteLine("layer met minste 0: 1 * 2 = {0}",password.calcFewestZeros());
            password.calcFinalImage();
            
        }
    }
}
