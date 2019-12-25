using System;
using System.Text;

namespace D1
{
    class RuimteModule
    {
        int gewicht;
        int nodigeBrandstof;
        
        public RuimteModule(int hoeveelheid){
            this.gewicht = hoeveelheid;
            this.nodigeBrandstof = BerekenWerkelijkeBrandstof(this.gewicht);
        }

        //Dit is deel 1 van dag 1
        public static int BerekenBrandstof(int gewicht){
            
            int brandstof = ((int) Math.Floor(gewicht / 3.0)) - 2;
            
            return brandstof;
        }

        //Dit is deel 2 van dag 1
        public static int BerekenWerkelijkeBrandstof(int gewicht){
            
            int totaalBrandstof = 0;
            int extraBrandstof = RuimteModule.BerekenBrandstof(gewicht);
            while (extraBrandstof > 0)
            {
                totaalBrandstof += extraBrandstof;
                extraBrandstof = RuimteModule.BerekenBrandstof(extraBrandstof);
            }

            return totaalBrandstof;
          
            
        }


        public int getBrandstof(){
            return this.nodigeBrandstof;
        }

    }
}