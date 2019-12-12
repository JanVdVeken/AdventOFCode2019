using System;
using System.Collections.Generic;
using System.Linq;

namespace D6
{
    class SpaceObject
    {
        public string Orbit { get; set; }
        public string Center { get; set; }
        public SpaceObject(string name)
        {
            var split = name.Split(")");
            Center = split.First();
            Orbit = split.Last();
            
        }

    }
}
