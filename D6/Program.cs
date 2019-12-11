using System;
using System.IO;
using System.Collections.Generic;

namespace D6
{
    class Program
    {
        static void Main(string[] args)
        {           
             //input
            string[] inputFile = File.ReadAllLines(@"..\OpdrachtGegevens\D6O1_test.txt");
            List<SpaceObject> spaceObjects = new List<SpaceObject>();
            
            //Verwerlomg
            foreach(string lijn in inputFile)
            {
                var inputLijn = lijn.Split(")");

            };        
        
           
        }
    }
}
