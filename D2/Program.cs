using System;
using System.Collections.Generic;

namespace D2
{
    class Program
    {
        static void Main(string[] args)
        {
            int noun = 0;
            int verb = 0;
            while(noun <= 99)
            {
                //Console.WriteLine("noun: " + noun);
                while(verb <= 99)
                {
                    //Console.WriteLine("     verb: " + verb);
                    int[] arrayCode = 
                    {
                        1,0,0,3,1,1,2,3,1,3,4,
                        3,1,5,0,3,2,1,10,19,1,19,
                        6,23,2,23,13,27,1,27,5,31,
                        2,31,10,35,1,9,35,39,1,39,
                        9,43,2,9,43,47,1,5,47,51,2,
                        13,51,55,1,55,9,59,2,6,59,63,
                        1,63,5,67,1,10,67,71,1,71,10,
                        75,2,75,13,79,2,79,13,83,1,5,
                        83,87,1,87,6,91,2,91,13,95,1,
                        5,95,99,1,99,2,103,1,103,6,0,
                        99,2,14,0,0
                    };

                    arrayCode[1] = noun;
                    arrayCode[2] = verb;        
                                
                    int i = 0;
                    bool Verderdoen = true;
                    while(i < arrayCode.Length && Verderdoen)
                    {
                        switch (arrayCode[i])
                            {
                                case 99:
                                    Verderdoen = false;
                                    break;
                                case 1:
                                    arrayCode[arrayCode[i+3]] = arrayCode[arrayCode[i+2]] + arrayCode[arrayCode[i+1]];
                                    i = i + 3;
                                    break;
                                case 2:
                                    arrayCode[arrayCode[i+3]] = arrayCode[arrayCode[i+2]] * arrayCode[arrayCode[i+1]];
                                    i = i + 3;
                                    break;
                            }
                        i ++;
                    }
                    if(arrayCode[0] == 19690720)
                    {
                        Console.WriteLine(noun*100 + verb);
                    }
                    verb ++;
                }
                verb = 0;
                noun ++;
            }
        }
    }
}
