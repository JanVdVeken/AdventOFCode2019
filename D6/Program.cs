using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace D6
{
    class Program
    {
        static void Main(string[] args)
        {           
             //input
            string[] inputFile = File.ReadAllLines(@"..\OpdrachtGegevens\D6O1.txt");
            List<SpaceObject> spaceObjects = new List<SpaceObject>();

            //Verwerlomg
            foreach(string lijn in inputFile)
            {
                 spaceObjects.Add(new SpaceObject(lijn));   
            };
            int Totaal = 0;
            foreach(SpaceObject objectSpace in spaceObjects)
            {
                Totaal ++;
                String Center = objectSpace.Center;
                while(Center != "COM")
                {
                    Totaal ++;
                    SpaceObject temp = spaceObjects.First(x => x.Orbit == Center);
                    Center = temp.Center;
                };                
                
            }

            Console.WriteLine(Totaal);
        
           
        }
    }
}
