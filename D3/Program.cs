using System;
//using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace D3
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            string[] inputFile = File.ReadAllLines(@"..\OpdrachtGegevens\D3O1.txt");
            List<string[]> wegen = new List<string[]>();
            
            //Verwerlomg
            foreach(string lijn in inputFile)
            {
                wegen.Add(lijn.Split(","));
            };
            
            //Lijst van alle af te leggen wegen
            List<Gridlijst> alleWegen = new List<Gridlijst>();


            foreach(String[] weg in wegen)
            {
                Gridlijst wegLijst = new Gridlijst();
                wegLijst.vulLijst(weg);
                alleWegen.Add(wegLijst);
            }
            List<Point> beginwaarde = new List<Point>(alleWegen[0].geefLijst());
            alleWegen.RemoveAt(0);

            // Voor elke lijst gaan wij nu af of er een punt is in de "hoofdlijst"
            List<Point> kruispunten = new List<Point>();
            foreach(Gridlijst gridje in alleWegen)
            {
                foreach(Point wegPunt in gridje.geefLijst())
                {
                    foreach(Point puntbegin in beginwaarde)
                    {
                        if(puntbegin.X == wegPunt.X && puntbegin.Y == wegPunt.Y)
                        {
                            //Console.WriteLine(wegPunt.X+" "+wegPunt.Y+" "+ (wegPunt.afstand + puntbegin.afstand) );
                            kruispunten.Add(new Point(wegPunt.X,wegPunt.Y, wegPunt.afstand + puntbegin.afstand ));
                        }
                    }
                }
                
            }
            int manhattenDistance = Int32.MaxValue;
            foreach(Point punt in kruispunten)
            {
                manhattenDistance = Math.Min(manhattenDistance,punt.afstand);
            }

            //output

            Console.WriteLine("De manhattenDistance bedraagt: "+ manhattenDistance);
            
        }
    }
}
