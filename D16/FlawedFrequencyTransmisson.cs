using System;
using System.Collections.Generic;

namespace D16
{
    class FlawedFrequencyTransmission
    {
        List<int> RepeatingPattern;
        List<int> InputList;
        string Outputstring = "";

        public FlawedFrequencyTransmission(List<int> input)
        {
            RepeatingPattern = new List<int>{0,1,0,-1};
            InputList = input;
        }
        public void calculatedPhases(int x)
        {
            
            for(int phase = 0; phase < x; phase++)
            {
                List<int> tempSolution = new List<int>();
                for(int k = 1; k<= InputList.Count;k++)
                {
                    //Opmaken van de lijst van de vermenigvuldiging. Deze lijst is gebaseerd op de 0 1 0 -1 lijst
                    //Het aantal keer dat een cijfer zich herhaalt wordt bepaald door iteratie (tussen 1 en k keer)
                    List<int> RepeatingPatternPhaseX = new List<int>();
                    int increment =0;
                    while(RepeatingPatternPhaseX.Count < InputList.Count+1)
                    {
                        
                        for(int temp = 0; temp < k;temp++)
                        {
                            RepeatingPatternPhaseX.Add(RepeatingPattern[increment]);
                        }
                        increment ++;
                        if (increment == 4) increment = 0;
                    }

                    //Eerste waarde moet verwijderd worden
                    RepeatingPatternPhaseX.RemoveAt(0);

                    //Dan per lijn alles optellen (lijn = horizontaal, zoals in voorbeeld)
                    int huidigeWaarde = 0;
                    for(int i = 0;i<=InputList.Count-1 ;i++)
                    {
                        huidigeWaarde = huidigeWaarde + (InputList[i]*RepeatingPatternPhaseX[i]);
                    }
                    tempSolution.Add(Math.Abs(huidigeWaarde)%10);
                }
                InputList = tempSolution;
            }
            foreach(int number in InputList)
            {
                Outputstring = Outputstring + number.ToString();
            }
        }

        public string getFirstEightOutput()
        {
            return (Outputstring + "        ").Substring(0,8);
        }

        public void SetRepeatingPatern(List<int> input)
        {
            RepeatingPattern = input;
        }
        public void SetInputList(List<int> input)
        {
            InputList = input;
        }
    }
}