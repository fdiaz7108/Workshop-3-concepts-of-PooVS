using System;

namespace CosechandoACaballo
{
    /// <summary>
    /// Clase que representa una posición en el tablero de ajedrez
    /// </summary>
    public class Position
    {
        // Propiedades para almacenar la columna (letra) y fila (número)
        public char Column { get; private set; }
        public int Row { get; private set; }

        /// <summary>
        /// Constructor de la clase Position
        /// </summary>
        /// <param name="column">Columna (A-H)</param>
        /// <param name="row">Fila (1-8)</param>
        public Position(char column, int row)
        {
            // Validar que la columna esté entre A y H
            if (char.ToUpper(column) < 'A' || char.ToUpper(column) > 'H')
                throw new ArgumentException("La columna debe estar entre A y H");

            // Validar que la fila esté entre 1 y 8
            if (row < 1 || row > 8)
                throw new ArgumentException("La fila debe estar entre 1 y 8");

            Column = char.ToUpper(column);
            Row = row;
        }

        /// <summary>
        /// Convierte la posición a coordenadas numéricas (0-7, 0-7)
        /// </summary>
        /// <returns>Tupla con coordenadas (columna, fila)</returns>
        public (int col, int row) ToCoordinates()
        {
            // Convertir letra a número (A=0, B=1, ..., H=7)
            int col = Column - 'A';
            // Convertir fila a índice (1=0, 2=1, ..., 8=7)
            int row = Row - 1;
            return (col, row);
        }

        /// <summary>
        /// Representación en string de la posición
        /// </summary>
        /// <returns>String en formato "A1", "B2", etc.</returns>
        public override string ToString()
        {
            return $"{Column}{Row}";
        }

        /// <summary>
        /// Crea una Position desde un string (ej: "B7")
        /// </summary>
        /// <param name="positionString">String con la posición</param>
        /// <returns>Objeto Position</returns>
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