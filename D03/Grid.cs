using System;
using System.Drawing;
using System.Text;

namespace D3
{
    class Grid
    {
        int rijen;
        int kolommen;
        String[,] speelveld;

        public Point startWaarde;
        public Grid(int aantalKolommen, int aantalRijen)
        {
            this.kolommen = aantalKolommen;
            this.rijen = aantalRijen;
            speelveld =  new String[rijen,kolommen];
            this.initialiseer();
            this.startWaarde = new Point( rijen/2, kolommen/2 );
            this.tekenStartWaarde();
        }
        public int berekenMahattenDsitance()
        {
            int manhattenDistance = Int16.MaxValue;
            for(int i = 0; i < rijen; i++)
            {
                for(int j = 0; j < kolommen; j++)
                {
                    if(speelveld[i,j] == tekenWaarde.Kruising())
                    {
                        manhattenDistance = Math.Min(manhattenDistance,Math.Abs(startWaarde.X - i) + Math.Abs(startWaarde.Y - j));
                    }
                }

            }
            return manhattenDistance;
        }
        public void tekenweg(string[] teBewandelenWeg)
        {
            Point huidgeWaarde = this.startWaarde;
            foreach(string Wandelstuk in teBewandelenWeg)
            {

                int afstand = Int32.Parse(Wandelstuk.Substring(1));
                switch (Wandelstuk[0])
                    {
                        case 'U':
                            for (int i = 1; i <= afstand; i++)
                            {
                                huidgeWaarde.X -= 1;
                                if(speelveld[huidgeWaarde.X, huidgeWaarde.Y] == tekenWaarde.leegte())
                                {
                                    speelveld[huidgeWaarde.X, huidgeWaarde.Y] = tekenWaarde.wegVerticaal();
                                }
                                else
                                {
                                    speelveld[huidgeWaarde.X, huidgeWaarde.Y] = tekenWaarde.Kruising();     
                                }
                                
                            }
                            break;
                        case 'D':
                            for (int i = 1; i <= afstand; i++)
                            {
                                huidgeWaarde.X += 1;
                                if(speelveld[huidgeWaarde.X, huidgeWaarde.Y] == tekenWaarde.leegte())
                                {
                                    speelveld[huidgeWaarde.X, huidgeWaarde.Y] = tekenWaarde.wegVerticaal();
                                }
                                else
                                {
                                    speelveld[huidgeWaarde.X, huidgeWaarde.Y] = tekenWaarde.Kruising();     
                                }
                            }
                            break;
                        case 'L':
                            for (int i = 1; i <= afstand; i++)
                            {
                                huidgeWaarde.Y -=  1;
                                if(speelveld[huidgeWaarde.X, huidgeWaarde.Y] == tekenWaarde.leegte())
                                {
                                    speelveld[huidgeWaarde.X, huidgeWaarde.Y] = tekenWaarde.wegHorizontaal();
                                }
                                else
                                {
                                    speelveld[huidgeWaarde.X, huidgeWaarde.Y] = tekenWaarde.Kruising();     
                                }
                            }                        
                            break;
                        case 'R':
                            for (int i = 1; i <= afstand; i++)
                            {
                                huidgeWaarde.Y += 1;
                                if(speelveld[huidgeWaarde.X, huidgeWaarde.Y] == tekenWaarde.leegte())
                                {
                                    speelveld[huidgeWaarde.X, huidgeWaarde.Y] = tekenWaarde.wegHorizontaal();
                                }
                                else
                                {
                                    speelveld[huidgeWaarde.X, huidgeWaarde.Y] = tekenWaarde.Kruising();     
                                }
                            }  
                            break;

                    }
                    speelveld[huidgeWaarde.X, huidgeWaarde.Y] = tekenWaarde.hoek();

            }
        }
        public void initialiseer()
        {
            for(int i = 0; i < rijen; i++)
            {
                for(int j = 0; j < kolommen; j++)
                {
                    speelveld[i,j] = tekenWaarde.leegte();
                }
            }
        }

        public void visualiseer()
        {
            String outputString = "";
            for(int i = 0; i < rijen; i++)
            {
                for(int j = 0; j < kolommen; j++)
                {
                    outputString += speelveld[i,j];
                }
                outputString += "\n";
            }
            Console.WriteLine(outputString);

        }
        public void verplaatsStartwaarde(int nieuweX, int nieuweY)
        {
            this.verwijderStartWaarde();
            startWaarde.X = nieuweX;
            startWaarde.Y = nieuweY;
            this.tekenStartWaarde();
        }
        public void verwijderStartWaarde()
        {
            speelveld[startWaarde.X,startWaarde.Y] = tekenWaarde.leegte();
        }

        public void tekenStartWaarde()
        {
            speelveld[startWaarde.X,startWaarde.Y] = tekenWaarde.beginwaarde();
        }
    }
}