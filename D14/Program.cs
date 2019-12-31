using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace D14
{
    class Program
    {
        static void Main(string[] args)
        {

             string[] inputFile = File.ReadAllLines(@"..\OpdrachtGegevens\D14O1_test.txt");

             Dictionary<string, string[]> reactions = new Dictionary<string, string[]>();
             Dictionary<string, int> components = new Dictionary<string, int>();
             

             foreach(string inputline in inputFile)
             {
                string[] splitInput = inputline.Split("=> ");
                string [] InputsOfReaction = splitInput[0].Split(", ");
                reactions.Add(splitInput[1],InputsOfReaction);
             }
            
            //InputExtensions.Overzicht(reactions);
            string endKey = reactions.Keys.First(x => x.Contains("FUEL"));
            int amount = int.Parse(endKey.Split(" ")[0]);
            string component = endKey.Split(" ")[1];
            string[] temp = reactions[endKey];
            foreach(string test in temp)
            {
                string[] splitsing = test.Split(" ");
                if(components.ContainsKey(splitsing[1]))
                {
                    components[splitsing[1]] += int.Parse(splitsing[0]);
                }
                else
                {
                    components.Add(splitsing[1],int.Parse(splitsing[0]));
                }
                
            }

            Console.WriteLine(components["AB"]);
        }
    }
}
