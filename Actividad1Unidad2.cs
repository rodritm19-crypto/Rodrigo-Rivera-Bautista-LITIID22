using System;
using System.Collections.Generic;

namespace RegistroPersonas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Registro de Personas")
            int cantidad = ObtenerCantidadPersonas();
            List<string> nombres = new List<string>();
            List<int> edades = new List<int>();
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"\n--- Persona {i + 1} ---");
                string nombre;
                do
                {
                    Console.Write("Nombre: ");
                    nombre = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(nombre))
                    {
                        Console.WriteLine("Error: El nombre no puede estar vacío. Intenta de nuevo.");
                    }
                } while (string.IsNullOrEmpty(nombre));
                nombres.Add(nombre);
                int edad = ObtenerEdadValida();
                edades.Add(edad);
            }
            if (cantidad == 1)
            {
                string estado = edades[0] >= 18 ? "mayor de edad" : "menor de edad";
                Console.WriteLine($"\n{nombres[0]} es {estado} ({edades[0]} años).");
            }
            else
            {
                Console.WriteLine("\n=== Lista general de personas registradas ===");
                for (int i = 0; i < cantidad; i++)
                {
                    Console.WriteLine($"{nombres[i]} - {edades[i]} años");
                }
                List<string> mayores = new List<string>();
                List<string> menores = new List<string>();

                for (int i = 0; i < cantidad; i++)
                {
                    string registro = $"{nombres[i]} - {edades[i]} años";
                    if (edades[i] >= 18)
                        mayores.Add(registro);
                    else
                        menores.Add(registro);
                }
                if (mayores.Count > 0)
                {
                    Console.WriteLine("\nMayores de edad");
                    foreach (var persona in mayores)
                    {
                        Console.WriteLine(persona);
                    }
                }
                if (menores.Count > 0)
                {
                    Console.WriteLine("\nMenores de edad");
                    foreach (var persona in menores)
                    {
                        Console.WriteLine(persona);
                    }
                }
            }

            Console.WriteLine("\nPresiona cualquier tecla");
            Console.ReadKey();
        }
        static int ObtenerCantidadPersonas()
        {
            int cantidad;
            while (true)
            {
                Console.Write("¿Cuántas personas deseas registrar? ");
                string entrada = Console.ReadLine().Trim();

                if (int.TryParse(entrada, out cantidad) && cantidad >= 1)
                {
                    return cantidad;
                }
                else
                {
                    Console.WriteLine("Error: Ingresa un número entero mayor o igual a 1.");
                }
            }
        }
        static int ObtenerEdadValida()
        {
            int edad;
            while (true)
            {
                Console.Write("Edad: ");
                string entrada = Console.ReadLine().Trim();

                if (int.TryParse(entrada, out edad) && edad >= 0)
                {
                    return edad;
                }
                else
                {
                    Console.WriteLine("Error: Ingresa una edad válida (número entero ≥ 0).");
                }
            }
        }
    }
}