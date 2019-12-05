using System;

namespace D4
{
    class Program
    {
        static void Main(string[] args)
        {
            EigenRNG pwdGenerator = new EigenRNG("136760-595730");
            Console.WriteLine($"Inputvalue: {pwdGenerator.minVal} - {pwdGenerator.maxVal}");
            pwdGenerator.berekenMogelijkePwds();
            Console.WriteLine($"Aantal mogelijke Passwords: {pwdGenerator.getPwds()}");
            Console.ReadLine();
        }
    }
}
