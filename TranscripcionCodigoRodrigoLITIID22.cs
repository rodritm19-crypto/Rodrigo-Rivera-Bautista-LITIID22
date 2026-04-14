using System;

class Program
{
    static int ObtenerEdad()
    {
        int edad;

        while (true)
        {
            Console.Write("Edad: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out edad) && edad >= 0)
            {
                return edad;
            }
            else
            {
                Console.WriteLine("Edad inválida. Ingrese un número entero válido.");
            }
        }
    }

    static void MostrarResultados(string[] nombres, int[] edades)
    {
        Console.WriteLine("\n==============================");
        Console.WriteLine("\nLista General:");

        for (int i = 0; i < nombres.Length; i++)
        {
            Console.WriteLine($"{nombres[i]} - {edades[i]} años");
        }

        Console.WriteLine("\nMayores de edad:");
        for (int i = 0; i < nombres.Length; i++)
        {
            if (edades[i] >= 18)
                Console.WriteLine($"{nombres[i]} - {edades[i]} años");
        }

        Console.WriteLine("\nMenores de edad:");
        for (int i = 0; i < nombres.Length; i++)
        {
            if (edades[i] < 18)
                Console.WriteLine($"{nombres[i]} - {edades[i]} años");
        }

        Console.WriteLine("\nPrograma finalizado.");
    }

    static void Main(string[] args)
    {
        int cantidad;
        while (true)
        {
            Console.Write("¿Cuántas personas deseas registrar? ");
            if (int.TryParse(Console.ReadLine(), out cantidad) && cantidad > 0)
            {
                break;
            }
            Console.WriteLine("Cantidad inválida. Ingrese un número entero positivo.");
        }

        string[] nombres = new string[cantidad];
        int[] edades = new int[cantidad];

        for (int i = 0; i < cantidad; i++)
        {
            Console.Write("Nombre: ");
            nombres[i] = Console.ReadLine();
            edades[i] = ObtenerEdad();
        }

        MostrarResultados(nombres, edades);
    }
}