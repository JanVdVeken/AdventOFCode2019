using System.Collections.Generic;

namespace D1
{
    class RuimteSchip
    {
        public List<RuimteModule> ruimteModullenLijst; 
        public RuimteSchip(){
            ruimteModullenLijst = new List<RuimteModule>();
        }
        public void voegModuleToe(RuimteModule ruimtemodule)
        {
            ruimteModullenLijst.Add(ruimtemodule);
        }

        public int aantalModules(){
            return ruimteModullenLijst.Count;
        }

        public int hoeveelheidBrandstof(){
            int BrandstofTotaal = 0;
            foreach(RuimteModule ruimteModule in ruimteModullenLijst)
            {
                BrandstofTotaal += ruimteModule.getBrandstof();
            };

            return BrandstofTotaal;
        }
    }
}