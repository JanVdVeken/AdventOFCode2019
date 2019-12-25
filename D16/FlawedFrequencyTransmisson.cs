using System;
using System.Collections.Generic;

namespace D16
{
    class FlawedFrequencyTransmission
    {
        List<int> RepeatingPattern;
        List<int> InputList;
        string OuputString = "0123456789";

        public FlawedFrequencyTransmission(List<int> input)
        {
            RepeatingPattern = new List<int>{0,1,0,-1};
            InputList = input;
        }
        public void calculatedPhases(int x)
        {
            //Hier komt de berekening van de volgende phases
        }

        public string getFirstEightOutput()
        {
            return OuputString.Substring(0,8);
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