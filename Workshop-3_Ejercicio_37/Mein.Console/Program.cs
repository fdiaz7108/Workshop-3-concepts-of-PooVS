using CosechandoACaballo;
using System;


// Crear instancia del tablero de ajedrez
namespace CosechandoACaballo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("COSECHANDO A CABALLO");
            Console.WriteLine("====================");

            // Crear instancia del tablero de ajedrez
            ChessBoard chessBoard = new ChessBoard();

            try
            {
                // Pedir al usuario que ingrese las posiciones de los caballos
                Console.Write("Ingrese ubicación de los caballos (ej: B7,C5,E2,H7,G5,F6): ");
                string input = Console.ReadLine();

                // Procesar las posiciones ingresadas
                chessBoard.AddKnightsFromInput(input);

                Console.WriteLine("\nResultados del análisis:");
                Console.WriteLine("========================");

                // Analizar y mostrar los conflictos
                chessBoard.AnalyzeConflicts();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}


            