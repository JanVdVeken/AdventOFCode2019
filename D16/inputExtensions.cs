using System;
using System.Collections.Generic;

namespace D16
{
    class inputExtensions
    {
        public static List<int> GetIntList(String numString)
        {
            List<int> listOfInts = new List<int>();
            for(int i = 0; i < numString.Length ; i++)
            {
                listOfInts.Add( (int)char.GetNumericValue(numString[i]));
            }
            return listOfInts;
        }
    }
}