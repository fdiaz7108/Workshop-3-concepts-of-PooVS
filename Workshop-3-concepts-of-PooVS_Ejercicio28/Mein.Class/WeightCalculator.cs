using System;
using System.Collections.Generic;

namespace LaVigaMasResistente
{
  
    public class WeightCalculator
    {
        
        public int CalculateTotalWeight(string beamString)
        {
           
            int baseResistance = GetBaseResistance(beamString[0]);

            
            string restOfBeam = beamString.Substring(1);
            if (string.IsNullOrEmpty(restOfBeam))
            {
                return 0;
            }

            List<string> tokens = TokenizeBeam(restOfBeam);

            
            return CalculateWeightFromTokens(tokens);
        }

      
        private int GetBaseResistance(char baseChar)
        {
            switch (baseChar)
            {
                case '%':
                    return 10;
                case '&':
                    return 30;
                case '#':
                    return 90; 
                default:
                    return 0;
            }
        }

        private List<string> TokenizeBeam(string beamPart)
        {
            List<string> tokens = new List<string>();
            int i = 0;

            while (i < beamPart.Length)
            {
                if (beamPart[i] == '=')
                {
                    int count = 0;
                    while (i < beamPart.Length && beamPart[i] == '=')
                    {
                        count++;
                        i++;
                    }
                    tokens.Add(new string('=', count));
                }
                else if (beamPart[i] == '*')
                {
                    tokens.Add("*");
                    i++;
                }
            }

            return tokens;
        }

        private int CalculateWeightFromTokens(List<string> tokens)
        {
            int totalWeight = 0;
            int lastBeamWeight = 0;

            for (int j = 0; j < tokens.Count; j++)
            {
                string token = tokens[j];
                if (token[0] == '=')
                {
                    
                    int n = token.Length;
                    int segmentWeight = n * (n + 1) / 2;
                    totalWeight += segmentWeight;
                    lastBeamWeight = segmentWeight;
                }
                else if (token == "*")
                {
                   
                    if (j < tokens.Count - 1)
                    {
                        int connectionWeight = 2 * lastBeamWeight;
                        totalWeight += connectionWeight;
                    }
                }
            }

            return totalWeight;
        }

        public int GetBaseResistanceFromChar(char baseChar)
        {
            return GetBaseResistance(baseChar);
        }
    }
}