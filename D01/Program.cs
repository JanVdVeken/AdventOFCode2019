using System;
using System.IO;

namespace D1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputFile = File.ReadAllLines(@"..\OpdrachtGegevens\D1O1.txt");
            RuimteSchip schipSanta = new RuimteSchip();
            foreach (string s in inputFile)
            {
                schipSanta.voegModuleToe(new RuimteModule(Int32.Parse(s)));
            }
            
            Console.WriteLine("Aantal modules: " + schipSanta.aantalModules());
            Console.WriteLine("Totale hoeveelheid brandstof: " + schipSanta.hoeveelheidBrandstof());
        }
    }
}
