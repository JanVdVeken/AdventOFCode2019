using System;
using System.IO;
using System.Collections.Generic;

namespace D7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inlezen IntCodes
            string inputFile = File.ReadAllText(@"..\OpdrachtGegevens\D5O1.txt");
            string[] stringIntCodeProgram = inputFile.Split(',');
            List<int> intCodeProgram = new List<int>();
            foreach(string intCode in stringIntCodeProgram)
            {
                intCodeProgram.Add(Int32.Parse(intCode));
            }

            List<int> PossiblePermutations = new List<int>(){0,1,2,3,4};

            //Aanmaken intCodeComputer
            IntCodeComputer icc = new IntCodeComputer(intCodeProgram,1);
            //icc.setInput(5);
            //icc.startBerekeningen();
            //icc.printEersteWaarde();
        }
    }
}
