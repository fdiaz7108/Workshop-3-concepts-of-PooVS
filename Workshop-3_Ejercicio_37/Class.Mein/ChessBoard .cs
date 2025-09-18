using System;
using System.Collections.Generic;
using System.Linq;

namespace CosechandoACaballo
{
    /// <summary>
    /// Clase que representa el tablero de ajedrez y gestiona los caballos
    /// </summary>
    public class ChessBoard
    {
        // Lista de caballos en el tablero
        private List<Knight> knights;

        /// <summary>
        /// Constructor de la clase ChessBoard
        /// </summary>
        public ChessBoard()
        {
            knights = new List<Knight>();
        }

        /// <summary>
        /// Agrega un caballo al tablero
        /// </summary>
        /// <param name="knight">Caballo a agregar</param>
        public void AddKnight(Knight knight)
        {
            knights.Add(knight);
        }

        /// <summary>
        /// Agrega múltiples caballos desde un string de entrada
        /// </summary>
        /// <param name="input">String con posiciones separadas por comas</param>
        public void AddKnightsFromInput(string input)
        {
            if (string.IsNullOrEmpty(input))
                return;

            // Dividir el input por comas y procesar cada posición
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

        /// <summary>
        /// Analiza y muestra los conflictos entre todos los caballos
        /// </summary>
        public void AnalyzeConflicts()
        {
            foreach (var knight in knights)
            {
                // Encontrar caballos en conflicto con el caballo actual
                var conflictingKnights = knight.FindConflicts(knights);

                // Mostrar resultados
                Console.Write($"Analizando Caballo en {knight.Position} => ");

                if (conflictingKnights.Any())
                {
                    // Crear lista de posiciones de caballos en conflicto
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

        /// <summary>
        /// Obtiene la lista de todos los caballos en el tablero
        /// </summary>
        /// <returns>Lista de caballos</returns>
        public List<Knight> GetKnights()
        {
            return new List<Knight>(knights);
        }
    }
}