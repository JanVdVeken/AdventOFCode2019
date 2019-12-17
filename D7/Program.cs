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

            //Aanmaken intCodeComputer
            IntCodeComputer icc = new IntCodeComputer(intCodeProgram);
            icc.setInput(5);
            icc.startBerekeningen();
            //icc.printEersteWaarde();
        }
    }
}
