using System;
using System.Collections.Generic;
using System.Linq;

namespace CosechandoACaballo
{
    
    public class ChessBoard
    {
        
        private List<Knight> knights;

       
        public ChessBoard()
        {
            knights = new List<Knight>();
        }

        
        public void AddKnight(Knight knight)
        {
            knights.Add(knight);
        }

        
        public void AddKnightsFromInput(string input)
        {
            if (string.IsNullOrEmpty(input))
                return;


            string[] positions = input.Split(',');

            foreach (string pos in positions)
            {
                try
                {
                    string cleanedPos = pos.Trim();
                    if (!string.IsNullOrEmpty(cleanedPos))
                    {
                        Position position = Position.FromString(cleanedPos);
                        Knight knight = new Knight(position);
                        knights.Add(knight);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al procesar la posición '{pos}': {ex.Message}");
                }
            }
        }

      
        public void AnalyzeConflicts()
        {
            foreach (var knight in knights)
            {
               
                var conflictingKnights = knight.FindConflicts(knights);

                
                Console.Write($"Analizando Caballo en {knight.Position} => ");

                if (conflictingKnights.Any())
                {
                   
                    var conflictPositions = conflictingKnights.Select(k => k.Position.ToString());
                    Console.Write($"Conflicto con {string.Join(" ", conflictPositions)}");
                }
                else
                {
                    Console.Write("Ningún conflicto");
                }

                Console.WriteLine();
            }
        }


        public List<Knight> GetKnights()
        {
            return new List<Knight>(knights);
        }
    }
}