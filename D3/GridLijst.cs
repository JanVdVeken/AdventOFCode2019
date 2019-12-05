using System;
//using System.Drawing;
using System.Collections.Generic;

namespace D3
{
    class Gridlijst
    {
        List<Point> puntenLijst;
        public  Gridlijst()
        {
            puntenLijst = new List<Point>();
            zetBeginPunt(0,0);
        }

        public void zetBeginPunt(int x, int y){
            puntenLijst.Add(new Point(x,y));
        }

        public void vulLijst(string[] teBewandelenWeg)
        {
            int gewicht = 1;
            foreach(string Wandelstuk in teBewandelenWeg)
            {
                int afstand = Int32.Parse(Wandelstuk.Substring(1));
                Point huidigPunt = puntenLijst[puntenLijst.Count - 1];
                switch (Wandelstuk[0])
                    {
                        
                        case 'U':
                            for (int i = 1; i <= afstand; i++)
                            {
                                
                                puntenLijst.Add(new Point(huidigPunt.X,huidigPunt.Y - 1,gewicht));
                                huidigPunt = puntenLijst[puntenLijst.Count - 1];

                                gewicht ++;
                            }
                            break;
                        case 'D':
                            for (int i = 1; i <= afstand; i++)
                            {
                                puntenLijst.Add(new Point(huidigPunt.X,huidigPunt.Y + 1,gewicht));
                                huidigPunt = puntenLijst[puntenLijst.Count - 1];
                                gewicht ++;
                            }
                            break;
                        case 'L':
                            for (int i = 1; i <= afstand; i++)
                            {
                                puntenLijst.Add(new Point(huidigPunt.X - 1,huidigPunt.Y,gewicht));
                                huidigPunt = puntenLijst[puntenLijst.Count - 1];
                                gewicht ++;
                            }                        
                            break;
                        case 'R':
                            for (int i = 1; i <= afstand; i++)
                            {
                                puntenLijst.Add(new Point(huidigPunt.X + 1,huidigPunt.Y,gewicht));
                                huidigPunt = puntenLijst[puntenLijst.Count - 1];
                                gewicht ++;
                            }  
                            break;

                    }

            }

            puntenLijst.RemoveAt(0);
        }
        
        public List<Point> geefLijst()
        {
            return puntenLijst;
        }

    }
}
