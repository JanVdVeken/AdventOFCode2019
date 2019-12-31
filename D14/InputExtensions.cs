using System;
using System.Collections.Generic;

namespace D14
{
    class InputExtensions
    {
        public static void Overzicht(Dictionary<string, string[]> input)
        {
             foreach(string OutputOfReaction in input.Keys)
             {
                 Console.WriteLine("Voor " + OutputOfReaction + " zijn volgende producten nodig:");
                 foreach(string InputOfReaction in input[OutputOfReaction])
                 {
                     Console.WriteLine("\t" + InputOfReaction);
                 }
             }
        } 
    }
    
}