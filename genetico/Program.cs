using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace genetico
{
    class Program
    {
        static void Main(string[] args)
        {
            String poblacion_s; //numero introducido por el usuario
            bool digit; //variable para comprobar el numero introducido
            int numero_entero = 0, //variable para ocupar 
                poblacion_i; //numero de la poblacion en numero entero

            Operaciones accion = new Operaciones();

            do
            {
                Console.WriteLine("Escriba el tamaño de la pobracion");
                poblacion_s = Console.ReadLine();
                digit = Int32.TryParse(poblacion_s, out numero_entero); //validar si lo introducido es un numero, regresa Bool
                if (digit)
                {
                    poblacion_i = Int32.Parse(poblacion_s); //convertir String a int base 32
                    if (poblacion_i % 2 == 0) //validar si la poblacion es par
                        break; //romper ciclo
                    else
                        Console.WriteLine("El tamaño de la poblacion debe ser par\n"); // mostrar mensaje de error
                }
                else
                    Console.WriteLine("El tamaño debe ser un numero entero\n");
            } while (true); //ciclo infinito

            accion.iniciar_poblacion(poblacion_i); //generar poblacion

            accion.imprimir(); //imprimir la tabla

            Console.ReadKey();

        }
    }
}
