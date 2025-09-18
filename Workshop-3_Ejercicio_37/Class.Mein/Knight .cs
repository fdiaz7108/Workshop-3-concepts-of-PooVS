using System;
using System.Collections.Generic;

namespace CosechandoACaballo
{
    /// <summary>
    /// Clase que representa un caballo en el tablero
    /// </summary>
    public class Knight
    {
        // Propiedad para almacenar la posición del caballo
        public Position Position { get; private set; }

        /// <summary>
        /// Constructor de la clase Knight
        /// </summary>
        /// <param name="position">Posición del caballo</param>
        public Knight(Position position)
        {
            Position = position;
        }

        /// <summary>
        /// Verifica si este caballo está en conflicto con otro caballo
        /// </summary>
        /// <param name="otherKnight">Otro caballo a verificar</param>
        /// <returns>True si hay conflicto, false en caso contrario</returns>
        public bool IsInConflictWith(Knight otherKnight)
        {
            // Obtener coordenadas de ambos caballos
            var (col1, row1) = this.Position.ToCoordinates();
            var (col2, row2) = otherKnight.Position.ToCoordinates();

            // Calcular diferencias en columnas y filas
            int colDiff = Math.Abs(col1 - col2);
            int rowDiff = Math.Abs(row1 - row2);

            // Un caballo ataca en movimiento de L: (2,1) o (1,2)
            return (colDiff == 2 && rowDiff == 1) || (colDiff == 1 && rowDiff == 2);
        }

        /// <summary>
        /// Encuentra todos los caballos con los que tiene conflicto
        /// </summary>
        /// <param name="allKnights">Lista de todos los caballos en el tablero</param>
        /// <returns>Lista de caballos en conflicto</returns>
        public List<Knight> FindConflicts(List<Knight> allKnights)
        {
            List<Knight> conflictingKnights = new List<Knight>();

            foreach (var knight in allKnights)
            {
                // No comparar consigo mismo
                if (knight != this && this.IsInConflictWith(knight))
                {
                    conflictingKnights.Add(knight);
                }
            }

            return conflictingKnights;
        }

        /// <summary>
        /// Representación en string del caballo
        /// </summary>
        /// <returns>String con la posición del caballo</returns>
        public override string ToString()
        {
            return Position.ToString();
        }
    }
}