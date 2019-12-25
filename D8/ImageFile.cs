using System;
using System.Drawing;
using System.Text;
using System.Collections.Generic;

namespace D8
{
    class ImageFile
    {
        private int breedte = 25;
        private int hoogte = 6;

        List<int[,]> layerLijst = new List<int[,]>();
        public ImageFile(string input)
        {
            List<int> inputIntList = new List<int>();
            foreach(char c in input)
            {
                inputIntList.Add(int.Parse(c.ToString()));
            }
            

            for(int i = 0; i < inputIntList.Count -1;i++)
            {
                int[,] layer =  new int[hoogte,breedte];
                for (int k = 0; k < layer.GetLength(0); k++)
                {
                    for (int l = 0; l < layer.GetLength(1); l++)
                    {
                        layer[k, l] = inputIntList[i];
                        if(i < inputIntList.Count - 1)i ++;
                    }
                }
                i--;
                layerLijst.Add(layer);
            }

        }


        public void printLayers()
        {
            int i = 1;
            foreach(int[,] layer in layerLijst)
            {
                Console.WriteLine("layer {0}: ", i);
                printLayer(layer);
                i ++;
            }
        }
        public void printLayer(int[,] layer)
        {
            for (int k = 0; k < layer.GetLength(0); k++)
            {
                Console.Write("\t");
                for (int l = 0; l < layer.GetLength(1); l++)
                {
                    Console.Write(" {0}",layer[k,l]);
                }
                Console.WriteLine();                    
            }
        }

        public int calcFewestZeros()
        {
            int amountZeros = int.MaxValue;
            int[,] layerFewestZeros =  new int[hoogte,breedte];
            
            foreach(int[,] layer in layerLijst)
            {
                int currentAmountZeros = 0;
                for (int k = 0; k < layer.GetLength(0); k++)
                {
                    for (int l = 0; l < layer.GetLength(1); l++)
                    {
                        if(layer[k,l] == 0) currentAmountZeros++;
                    }                
                }
                if(currentAmountZeros < amountZeros)
                {
                    layerFewestZeros = layer; 
                    amountZeros = currentAmountZeros;
                } 
            }

            int amountOnes = 0;
            int amountTwos = 0;
            for (int k = 0; k < layerFewestZeros.GetLength(0); k++)
                {
                    for (int l = 0; l < layerFewestZeros.GetLength(1); l++)
                    {
                        if(layerFewestZeros[k,l] == 1) amountOnes++;
                        if(layerFewestZeros[k,l] == 2) amountTwos++;
                    }                
                }
            return amountOnes*amountTwos;
        }

        public void calcFinalImage()
        {
            int[,] outputLayer =  new int[hoogte,breedte];
            int transparant = 2;
            for (int k = 0; k < outputLayer.GetLength(0); k++)
            {
                for (int l = 0; l < outputLayer.GetLength(1); l++)
                {
                    outputLayer[k,l] = transparant;
                }                
            }

            foreach(int[,] layer in layerLijst)
            {
                for (int k = 0; k < layer.GetLength(0); k++)
                {
                    for (int l = 0; l < layer.GetLength(1); l++)
                    {
                        if(outputLayer[k,l] == 2) outputLayer[k,l] = layer[k,l];
                    }                
                }
            }
            Console.WriteLine("Outputimage: ");
            printLayer(outputLayer);

        }
    }
}