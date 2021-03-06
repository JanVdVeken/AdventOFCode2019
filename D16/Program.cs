﻿using System;
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
            List<int> inputListO2 = new List<int>();
            for(int i = 0; i < 10000 ;i++)
            {
                inputListO2.AddRange(inputList);
            }
            //Console.WriteLine(inputList[inputList.Count]);
            FlawedFrequencyTransmission FFT = new FlawedFrequencyTransmission(inputListO2);
            FFT.calculatedPhases(100);
            using (System.IO.StreamWriter file = 
            new System.IO.StreamWriter(@"..\OpdrachtGegevens\D16O2_oplossing.txt", true))
                {
                    file.WriteLine(FFT.getEightOutput(Convert.ToInt64(inputFile.Substring(1,7))));
                }
        }
    }


}
