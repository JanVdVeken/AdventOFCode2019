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
        int inputWaarde = 1;
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
            /*
            *   Na dag 2 staat alles in positiemodus (modus 0)
            *   Maw: alle waardes die aan intructie zijn meegegeven zijn de posities waarop waardes moeten opgehaald/geplaatst worden
            *
            *   Hier komt nog bij: immediate mode (modus 1)=> niet als locatie, maar echt als waarde
            *
            *   Deze parametes worden meegegeven met de opCode
            */
            pointer = 0;
            Boolean verderdoen = true;
            while (verderdoen)
            {
                /*
                *   We willen de input opsplitsen in parameters en in de werkelijke opCode
                *   Dit kan op volgende manier:
                */

                //Geeft de rest bij deling honderd => Laatste 2 cijfers
                int opCode = programma[pointer] % 100;            

                //De overige cijfers zijn de parameters
                List<int> parameters = getParameters(programma[pointer]/100); 
               //Hier hebben we dus de opcode en de parameters.

                List<int> inputPerCode = new List<int>(3);
                for(int i = 0; i < parameters.Count; i++)
                {
                    //try en catch omdat het anders kan zijn dat we verder gaan dan onze laatste waarde
                    try{
                        if(parameters[i] == 1)
                        {
                            inputPerCode.Add(pointer + i + 1);
                        }
                        else
                        {
                            inputPerCode.Add(programma[pointer+i + 1]);
                        }
                    }
                    catch{};

                }

               
               switch (opCode)
                {
                    case 99:
                        verderdoen = false;
                        break;
                    case 1:
                        instructie1(inputPerCode[0],inputPerCode[1],inputPerCode[2]);
                        break;
                    case 2:
                        instructie2(inputPerCode[0],inputPerCode[1],inputPerCode[2]);
                        break;
                    case 3:
                        instructie3(inputPerCode[0]);
                        break;
                    case 4:
                        instructie4(inputPerCode[0]);
                        break;  
                    case 5:
                        instructie5(inputPerCode[0],inputPerCode[1]);
                        break; 
                    case 6:
                        instructie6(inputPerCode[0],inputPerCode[1]);
                        break; 
                    case 7:
                        instructie7(inputPerCode[0],inputPerCode[1],inputPerCode[2]);
                        break; 
                    case 8:
                        instructie8(inputPerCode[0],inputPerCode[1],inputPerCode[2]);
                        break; 
                }
            }
        }   
        public void instructie8(int input1, int input2, int input3)
        {
            if(programma[input1] == programma[input2])
            {
                programma[input3] = 1;
            }
            else
            {
                programma[input3] = 0;
            }
            pointer += 4;
        } 
        public void instructie7(int input1, int input2, int input3)
        {
            if(programma[input1] < programma[input2])
            {
                programma[input3] = 1;
            }
            else
            {
                programma[input3] = 0;
            }
            pointer += 4;
        }  
        public void instructie6(int input1, int input2)
        {
            if(programma[input1] == 0)
            {
                pointer = programma[input2];
            }
            else
            {
                pointer += 3;
            }
        }
        public void instructie5(int input1, int input2)
        {
            if(programma[input1] != 0)
            {
                pointer = programma[input2];
            }
            else
            {
                pointer += 3;
            }
        }
        public void instructie4(int input1)
        {
            Console.WriteLine(programma[input1]);
            pointer += 2;
        }
        public void instructie3(int input1)
        {
            programma[input1] = inputWaarde;
            pointer += 2;
        }
        public void instructie2(int input1, int input2, int input3 )
        {
            programma[input3] = programma[input1] * programma[input2];
            pointer += 4;
        }
        public void instructie1(int input1, int input2, int input3 )
        {
            programma[input3] = programma[input1] + programma[input2];
            pointer += 4;
        }

        public void printProgramma()
        {
            foreach(int code in programma)
            {
                Console.WriteLine(code);
            }
        }
        
        public  List<int> getParameters(int input)
        {
            List<int> parameters = new List<int>();
            while(input > 0)
            {
                parameters.Add(input % 10);
                input /= 10;
            }
            while(parameters.Count < 3)
            {
                parameters.Add(0);
            }
            return parameters;
        }
        public void printEersteWaarde()
        {
            Console.WriteLine(programma[0]);
        }

        public void setInput(int input)
        {
            inputWaarde = input;
        }

    }
}
