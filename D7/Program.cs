using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace D7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inlezen IntCodes
            string inputFile = File.ReadAllText(@"..\OpdrachtGegevens\D7O1.txt");
            string[] stringIntCodeProgram = inputFile.Split(',');
            List<int> intCodeProgram = new List<int>();
            foreach(string intCode in stringIntCodeProgram)
            {
                intCodeProgram.Add(Int32.Parse(intCode));
            }

            List<int> PossibleStates = new List<int>(){0,1,2,3,4};

            IEnumerable<IEnumerable<int>> PossiblePermutations = GetPermutations(PossibleStates,PossibleStates.Count);

            int output = int.MinValue;
            int i = 0;
            foreach(IEnumerable<int> testInputTemp in PossiblePermutations)
            {
                List<int> testInput = testInputTemp.ToList();
                //Aanmaken intCodeComputers
                IntCodeComputer ampA = new IntCodeComputer(intCodeProgram,testInput[0]);
                IntCodeComputer ampB = new IntCodeComputer(intCodeProgram,testInput[1]);
                IntCodeComputer ampC = new IntCodeComputer(intCodeProgram,testInput[2]);
                IntCodeComputer ampD = new IntCodeComputer(intCodeProgram,testInput[3]);
                IntCodeComputer ampE = new IntCodeComputer(intCodeProgram,testInput[4]);

                //Berekeningen doen
                ampA.addInput(0);
                ampA.startBerekeningen();
                ampB.addInput(ampA.returnOutput());
                ampB.startBerekeningen();
                ampC.addInput(ampB.returnOutput());
                ampC.startBerekeningen();
                ampD.addInput(ampC.returnOutput());
                ampD.startBerekeningen();
                ampE.addInput(ampD.returnOutput());
                ampE.startBerekeningen();
                ampA.addInput(ampE.returnOutput());
                output = output < ampE.returnOutput() ? ampE.returnOutput() : output;
            }
            
            Console.WriteLine(output);
            //icc.setInput(5);
            //icc.startBerekeningen();
            //icc.printEersteWaarde();
        }

        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(o => !t.Contains(o)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
