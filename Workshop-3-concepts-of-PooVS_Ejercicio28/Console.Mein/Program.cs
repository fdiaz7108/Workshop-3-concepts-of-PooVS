
namespace LaVigaMasResistente
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese la viga: ");
            string input = Console.ReadLine();

            Beam beam = new Beam(input);
            beam.Analyze();

            Console.WriteLine(beam.GetResult());

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}