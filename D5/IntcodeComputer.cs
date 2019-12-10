using System;
using System.Drawing;
using System.Text;
using System.Collections.Generic;

namespace D5
{
    class IntCodeComputer
    {
        List<int> programma;
        int pointer;
        public IntCodeComputer(List<int> intCodes)
        {
            this.programma = intCodes;
        }
        public void zetSpecifiekeWaarde(int positie, int waarde)
        {
            programma[positie] = waarde;
        }

        public void startBerekeningen()
        {
            pointer = 0;
            Boolean verderdoen = true;
            while (verderdoen)
            {
               switch (programma[pointer])
                {
                    case 99:
                        verderdoen = false;
                        break;
                    case 1:
                        instructie1(programma[pointer+1],programma[pointer+2],programma[pointer+3]);
                        break;
                    case 2:
                        instructie2(programma[pointer+1],programma[pointer+2],programma[pointer+3]);
                        break;
                }
            }
        }
        public void printEersteWaarde()
        {
            Console.WriteLine(programma[0]);
        }

        public void instructie1(int input1, int input2, int output )
        {
            programma[output] = programma[input1] + programma[input2];
            pointer += 4;
        }
        public void instructie2(int input1, int input2, int output )
        {
            programma[output] = programma[input1] * programma[input2];
            pointer += 4;
        }

        public void printProgramma()
        {
            foreach(int code in programma)
            {
                Console.WriteLine(code);
            }
        }

    }
}
