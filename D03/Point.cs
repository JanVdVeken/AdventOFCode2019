using System;
//using System.Drawing;

namespace D3
{
    class Point
    {
        public int X;
        public int Y;
        public int afstand;
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public Point(int x, int y, int gewicht)
        {
            this.X = x;
            this.Y = y;
            this.afstand = gewicht;
        }
    }
}