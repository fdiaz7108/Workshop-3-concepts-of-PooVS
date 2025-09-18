using System;
using System.Linq;

namespace LaVigaMasResistente
{  
    public class BeamValidator
    {
        public bool Validate(string beamString)
        {
            if (string.IsNullOrEmpty(beamString))
            {
                return false;
            }

            char firstChar = beamString[0];
            if (firstChar != '%' && firstChar != '&' && firstChar != '#')
            {
                return false;
            }

            string restOfBeam = beamString.Substring(1);

            if (restOfBeam.Any(c => c != '=' && c != '*'))
            {
                return false;
            }

            if (restOfBeam.Length > 0 && restOfBeam[0] != '=')
            {
                return false;
            }
            
            if (restOfBeam.Contains("**"))
            {
                return false;
            }

            return true;
        }
    }
}