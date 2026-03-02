using System;
using System.Collections.Generic;

namespace RegistroPersonas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Registro de Personas");

            int cantidad = ObtenerCantidadPersonas();

            List<string> nombres = new List<string>();
            List<int> edades = new List<int>();

            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"\n--- Persona {i + 1} ---");
                nombres.Add(ValidarNombre());
                edades.Add(ObtenerEdadValida());
            }

            MostrarResultados(nombres, edades);

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }

        static int ObtenerCantidadPersonas()
        {
            int cantidad;
            while (true)
            {
                Console.Write("¿Cuántas personas deseas registrar? ");
                if (int.TryParse(Console.ReadLine().Trim(), out cantidad) && cantidad >= 1)
                    return cantidad;
                Console.WriteLine("Error: Ingresa un número entero mayor o igual a 1.");
            }
        }

        static string ValidarNombre()
        {
            string nombre;
            do
            {
                Console.Write("Nombre: ");
                nombre = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(nombre))
                    Console.WriteLine("Error: El nombre no puede estar vacío.");
            } while (string.IsNullOrEmpty(nombre));
            return nombre;
        }

        static int ObtenerEdadValida()
        {
            int edad;
            while (true)
            {
                Console.Write("Edad: ");
                if (int.TryParse(Console.ReadLine().Trim(), out edad) && edad >= 0)
                    return edad;
                Console.WriteLine("Error: Ingresa una edad válida.");
            }
        }

        static void MostrarResultados(List<string> nombres, List<int> edades)
        {
            Console.WriteLine("\n=== Lista general de personas registradas ===");
            for (int i = 0; i < nombres.Count; i++)
            {
                string estado = edades[i] >= 18 ? "Mayor de edad" : "Menor de edad";
                Console.WriteLine($"{nombres[i]} - {edades[i]} años ({estado})");
            }
        }
    }
}