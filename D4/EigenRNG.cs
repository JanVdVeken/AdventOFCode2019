using System;
using System.Collections.Generic;

namespace D4
{
    class EigenRNG
    {
        public int minVal;
        public int maxVal;
        int aantal;
        
        public EigenRNG(string inputString)
        {
            string[] inputSplit = inputString.Split("-");
            minVal = Int32.Parse(inputSplit[0]);
            maxVal = Int32.Parse(inputSplit[1]);
        }
        public void berekenMogelijkePwds()
        {

            for(int i = minVal; i <= maxVal; i++)
            {
                if(
                    this.sixDigit(i) &&
                    this.withinRange(i) &&
                    this.adjacentdigits(i) &&
                    this.verhogen(i)
                )
                {
                    this.aantal ++;
                }
            }
        }
        private bool verhogen(int testValue)
        {
            List<int> intList = new List<int>();

            while(testValue > 0)
            {
                intList.Add(testValue % 10);
                testValue /=  10;
            }
            intList.Reverse();

            for(int i = 0; i < intList.Count - 1;i++)
            {
                if(intList[i] > intList[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
        private bool adjacentdigits(int testValue)
        {
            char[] testString = testValue.ToString().ToCharArray();
            bool temp = false;
            for(int i = 0; i < testString.Length - 1 ;i++)
            {
                if(testString[i] == testString[i + 1])
                {
                    temp = true;
                    if(i != 0 &&  testString[i-1] == testString[i])
                    {
                        temp = false;
                    }
                    if(i != testString.Length - 2 && testString[i+1] == testString[i+2])
                    {
                        temp = false;
                    }
                    if(temp)
                    {
                        return true;
                    }
                }
            }
            return temp;
        }
        private bool withinRange(int testValue)
        {
            if(minVal <= testValue && testValue <= maxVal)
            {
                return true;
            }
            return false;
        }
        private bool sixDigit(int testValue)
        {
            if(Math.Floor(Math.Log10(testValue) + 1) > 6)
            {
                return false;
            }
            return true;
        }

        public int getPwds()
        {
            return aantal;
        }
    }
}