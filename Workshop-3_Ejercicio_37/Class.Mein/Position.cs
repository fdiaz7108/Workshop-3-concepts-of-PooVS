using System;

namespace CosechandoACaballo
{
    
    public class Position
    {
        
        public char Column { get; private set; }
        public int Row { get; private set; }

        
        public Position(char column, int row)
        {
            
            if (char.ToUpper(column) < 'A' || char.ToUpper(column) > 'H')
                throw new ArgumentException("La columna debe estar entre A y H");

           
            if (row < 1 || row > 8)
                throw new ArgumentException("La fila debe estar entre 1 y 8");

            Column = char.ToUpper(column);
            Row = row;
        }

       
        public (int col, int row) ToCoordinates()
        {
            
            int col = Column - 'A';

            int row = Row - 1;
            return (col, row);
        }

       
        public override string ToString()
        {
            return $"{Column}{Row}";
        }

        
        public static Position FromString(string positionString)
        {
            if (string.IsNullOrEmpty(positionString) || positionString.Length < 2)
                throw new ArgumentException("Formato de posición inválido");

            char column = positionString[0];
            int row = int.Parse(positionString.Substring(1));

            return new Position(column, row);
        }
    }
}