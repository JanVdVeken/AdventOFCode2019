using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace D16
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = File.ReadAllText(@"..\OpdrachtGegevens\D16O1.txt");           
            List<int> inputList = inputExtensions.GetIntList(inputFile);
            //Console.WriteLine(inputList[inputList.Count]);
            FlawedFrequencyTransmission FFT = new FlawedFrequencyTransmission(inputList);
            FFT.calculatedPhases(100);
            Console.WriteLine(FFT.getFirstEightOutput());
        }
    }


}
