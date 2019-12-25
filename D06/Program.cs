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
            string[] inputFile = File.ReadAllLines(@"..\OpdrachtGegevens\D6O2.txt");
            List<SpaceObject> spaceObjects = new List<SpaceObject>();

            //Verwerlomg
            foreach(string lijn in inputFile)
            {
                 spaceObjects.Add(new SpaceObject(lijn));   
            };

            SpaceObject myPosition = spaceObjects.First(x => x.Orbit == "YOU");
            SpaceObject sanPosition = spaceObjects.First(x => x.Orbit == "SAN");
            List<SpaceObject> myPlanets = new List<SpaceObject>();
            List<SpaceObject> sanPlanets = new List<SpaceObject>();

            //Search for route to Com for YOU
            while(myPosition.Center != "COM")
            {
                myPosition = spaceObjects.First(x => x.Orbit == myPosition.Center);
                myPlanets.Add(myPosition);
            };

            //Search for route to Com for SAN
            while(sanPosition.Center != "COM")
            {
                sanPosition = spaceObjects.First(x => x.Orbit == sanPosition.Center);
                sanPlanets.Add(sanPosition);
            };          
            
            //Look for common intersection
            SpaceObject intersectionObject = sanPlanets.Intersect(myPlanets,new MyEqualityComparer()).First();
            //Console.WriteLine(intersectionObject.Orbit);

            //Look for distances to the intersection from both sides
            int Totaal = 0;
            myPosition = spaceObjects.First(x => x.Orbit == "YOU");
            sanPosition = spaceObjects.First(x => x.Orbit == "SAN");
            while(myPosition.Center != intersectionObject.Orbit)
            {
                myPosition = spaceObjects.First(x => x.Orbit == myPosition.Center);
                Totaal ++;
            };
             while(sanPosition.Center != intersectionObject.Orbit)
            {
                sanPosition = spaceObjects.First(x => x.Orbit == sanPosition.Center);
                Totaal ++;
            }; 
            Console.WriteLine(Totaal);
        
        }

        public class MyEqualityComparer : IEqualityComparer<SpaceObject>
        {
            public bool Equals(SpaceObject x, SpaceObject y)
            {
                return (x.Center == y.Center && x.Orbit == y.Orbit);
            }

            public int GetHashCode(SpaceObject obj)
            {
                                var hash = 17;
                hash = hash * 23 + obj.Center.GetHashCode();
                hash = hash * 23 + obj.Orbit.GetHashCode();

                return hash;
            }
        }
    }
}
