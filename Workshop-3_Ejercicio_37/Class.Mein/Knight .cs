using System;
using System.Collections.Generic;

namespace CosechandoACaballo
{
    
    public class Knight
    {
       
        public Position Position { get; private set; }

      
        public Knight(Position position)
        {
            Position = position;
        }

       
        public bool IsInConflictWith(Knight otherKnight)
        {
           
            var (col1, row1) = this.Position.ToCoordinates();
            var (col2, row2) = otherKnight.Position.ToCoordinates();

            
            int colDiff = Math.Abs(col1 - col2);
            int rowDiff = Math.Abs(row1 - row2);

            
            return (colDiff == 2 && rowDiff == 1) || (colDiff == 1 && rowDiff == 2);
        }

       
    
        public List<Knight> FindConflicts(List<Knight> allKnights)
        {
            List<Knight> conflictingKnights = new List<Knight>();

            foreach (var knight in allKnights)
            {
             
                if (knight != this && this.IsInConflictWith(knight))
                {
                    conflictingKnights.Add(knight);
                }
            }

            return conflictingKnights;
        }

        
        public override string ToString()
        {
            return Position.ToString();
        }
    }
}