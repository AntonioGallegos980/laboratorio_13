using System;
using System.Collections.Generic;

class Program
{
    static List<int> resultados = new List<int>();

    static void Main()
    {
        int opcion;
        do
        {
            Console.Clear();
            MostrarMenu();
            opcion = LeerOpcion();
            ProcesarOpcion(opcion);

        } while (opcion != 5);
    }

    static void MostrarMenu()
    {
        Console.WriteLine("================================");
        Console.WriteLine("Encuestas de Calidad");
        Console.WriteLine("================================");
        Console.WriteLine("1: Realizar Encuesta");
        Console.WriteLine("2: Ver datos registrados");
        Console.WriteLine("3: Eliminar un dato");
        Console.WriteLine("4: Ordenar datos de menor a mayor");
        Console.WriteLine("5: Salir");
        Console.WriteLine("================================");
        Console.Write("Ingrese una opción: ");
    }

    static void ProcesarOpcion(int opcion)
    {
        switch (opcion)
        {
            case 1:
                RealizarEncuesta();
                break;
            case 2:
                VerDatosRegistrados();
                break;
            case 3:
                EliminarDato();
                break;
            case 4:
                OrdenarDatos();
                break;
            case 5:
                Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                break;
        }
    }

    static int LeerOpcion()
    {
        int opcion;
        while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 5)
        {
            Console.WriteLine("Opción no válida. Intente nuevamente.");
            Console.Write("Ingrese una opción: ");
        }
        return opcion;
    }

    static void RealizarEncuesta()
    {
        Console.Clear();
        Console.WriteLine("===================================");
        Console.WriteLine("Nivel de Satisfacción");
        Console.WriteLine("===================================");
        Console.WriteLine("¿Qué tan satisfecho está con la atención de nuestra tienda?");
        Console.WriteLine("1: Nada satisfecho");
        Console.WriteLine("2: No muy satisfecho");
        Console.WriteLine("3: Tolerable");
        Console.WriteLine("4: Satisfecho");
        Console.WriteLine("5: Muy satisfecho");
        Console.WriteLine("===================================");
        int respuesta;
        do
        {
            Console.Write("Ingrese una opción: ");
        } while (!int.TryParse(Console.ReadLine(), out respuesta) || respuesta < 1 || respuesta > 5);

        Console.Clear();
        resultados.Add(respuesta);
        Console.WriteLine("===================================");
        Console.WriteLine("Nivel de Satisfacción");
        Console.WriteLine("===================================");
        Console.WriteLine("¡Gracias por participar!");
        Console.WriteLine("===================================");

        Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
        Console.ReadKey(true);
    }

    static void VerDatosRegistrados()
    {
        Console.Clear();
        Console.WriteLine("Resultados de las encuestas:");

        if (resultados.Count > 0)
        {
            Dictionary<int, int> conteoOpciones = new Dictionary<int, int>();
            for (int i = 0; i < resultados.Count; i++)
            {
                Console.Write($"[{resultados[i]}]   ");
            }

            for (int i = 0; i < resultados.Count; i++)
            {
                int opcion = resultados[i];

                if (conteoOpciones.ContainsKey(opcion))
                {
                    conteoOpciones[opcion]++;
                }
                else
                {
                    conteoOpciones[opcion] = 1;
                }
            }

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("");
                if (conteoOpciones.ContainsKey(i))
                {
                    Console.WriteLine($"{conteoOpciones[i]:D2} personas: {TraducirOpcion(i)}");
                }
                else
                {
                    Console.WriteLine($"00 personas: {TraducirOpcion(i)}");
                }
            }
        }
        else
        {
            Console.WriteLine("No hay datos registrados.");
        }

        Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
        Console.ReadKey(true);
    }

    static string TraducirOpcion(int opcion)
    {
        switch (opcion)
        {
            case 1:
                return "Nada satisfecho";
            case 2:
                return "No muy satisfecho";
            case 3:
                return "Tolerable";
            case 4:
                return "Satisfecho";
            case 5:
                return "Muy satisfecho";
            default:
                return "Opción no válida";
        }
    }

    static void EliminarDato()
    {
        Console.Clear();
        if (resultados.Count > 0)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Eliminar un dato");
            Console.WriteLine("===================================");
            MostrarConteoOpcionesFormato(resultados);
            int posicionAEliminar;
            do
            {
                Console.Write("\nIngrese la posición a eliminar: ");
            } while (!int.TryParse(Console.ReadLine(), out posicionAEliminar) || posicionAEliminar < 1 || posicionAEliminar > resultados.Count);

            resultados.RemoveAt(posicionAEliminar - 1);

            Console.WriteLine("\n===================================");
            Console.WriteLine("Resultados de las encuestas después de eliminar:");
            Console.WriteLine("===================================");
            MostrarConteoOpcionesFormato(resultados);
        }
        else
        {
            Console.WriteLine("No hay datos registrados para eliminar.");
        }

        Console.WriteLine("\nPresione cualquier tecla para volver al menú principal...");
        Console.ReadKey(true);
    }

    static void OrdenarDatos()
    {
        Console.Clear();
        if (resultados.Count > 0)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Ordenar datos");
            Console.WriteLine("===================================");
            MostrarConteoOpcionesFormato(resultados);

            resultados.Sort();

            Console.WriteLine("\nResultados de las encuestas después de ordenar:");
            Console.WriteLine("===================================");
            MostrarConteoOpcionesFormato(resultados);
        }

        Console.WriteLine("\nPresione cualquier tecla para volver al menú principal...");
        Console.ReadKey(true);
    }

    static void MostrarConteoOpcionesFormato(List<int> opciones)
    {
        for (int i = 0; i < opciones.Count; i++)
        {
            Console.Write($"{i:D3}:[{opciones[i]:D2}]   ");
        }

        Console.WriteLine("\n===================================");
    }
}


