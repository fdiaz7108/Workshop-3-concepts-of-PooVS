using CosechandoACaballo;
using System;



namespace CosechandoACaballo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("COSECHANDO A CABALLO");
            Console.WriteLine("====================");

           
            ChessBoard chessBoard = new ChessBoard();

            try
            {
                
                Console.Write("Ingrese ubicación de los caballos (ej: B7,C5,E2,H7,G5,F6): ");
                string input = Console.ReadLine();

               
                chessBoard.AddKnightsFromInput(input);

                Console.WriteLine("\nResultados del análisis:");
                Console.WriteLine("========================");

               
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


            