using System;
using System.IO;
using System.Collections.Generic;

namespace D5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inlezen IntCodes
            string inputFile = File.ReadAllText(@"..\OpdrachtGegevens\D2O1.txt");
            string[] stringIntCodeProgram = inputFile.Split(',');
            List<int> intCodeProgram = new List<int>();
            foreach(string intCode in stringIntCodeProgram)
            {
                intCodeProgram.Add(Int32.Parse(intCode));
            }

            //Aanmaken intCodeComputer
            IntCodeComputer icc = new IntCodeComputer(intCodeProgram);
            icc.zetSpecifiekeWaarde(1,12);
            icc.zetSpecifiekeWaarde(2,2);
            icc.startBerekeningen();
            icc.printEersteWaarde();
        }
    }
}
