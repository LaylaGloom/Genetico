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
            String poblacion_s, //numero introducido por el usuario
                   probabilidad_cruce; //numero introducido por el usuario
            bool digit; //variable para comprobar el numero introducido
            int numero_entero = 0, //variable para compara con digito entero
                poblacion_i; //numero de la poblacion en numero entero
            double numero_decimal = 0.0, //variable para comparar con digito decimal
                   probabilidad_c; //variable para almacenar la probabilidad de cruce

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

            do
            {
                Console.WriteLine("Escriba la probabilidad de cruce [0.65 ~ 0.80]");
                probabilidad_cruce = Console.ReadLine();
                digit = Double.TryParse(probabilidad_cruce, out numero_decimal);
                if (digit)
                {
                    probabilidad_c = Double.Parse(probabilidad_cruce);
                    if (probabilidad_c <= 0.80 && probabilidad_c >= 0.65)
                        break;
                    else
                        Console.WriteLine("Se debe introducir un numero entre esos rangos");
                }
                else
                    Console.WriteLine("Se debe introducir un numero entre esos rangos");

            } while (true);

            accion.iniciar_poblacion(poblacion_i); //generar poblacion

            accion.imprimir(); //imprimir la tabla

            accion.generarLosNuevosPadresDeLaPatria(poblacion_i);

            Console.ReadKey();

        }
    }
}
