using System;
using System.IO;
using System.Collections.Generic;

namespace D09
{
    class Program
    {
            static void Main(string[] args)
            {
                //Inlezen IntCodes
                string inputFile = File.ReadAllText(@"..\OpdrachtGegevens\D9O1_test.txt");
                string[] stringIntCodeProgram = inputFile.Split(',');
                List<long> intCodeProgram = new List<long>();
                foreach(string intCode in stringIntCodeProgram)
                {
                    intCodeProgram.Add(Int32.Parse(intCode));
                }
                for(int i = 0; i < 12000;i++) intCodeProgram.Add(0);

                //Aanmaken intCodeComputer
                IntCodeComputer icc = new IntCodeComputer(intCodeProgram);
                icc.setInput(1);
                icc.startBerekeningen();
                //icc.printEersteWaarde();
            }
    }
    
}
