//Clase para realizar todas las operaciones con los individuos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace genetico
{
    class Operaciones
    {

        Individuo inicio; //variable que contendrá la lista

        public Operaciones() //constructor para iniciar lista
        {
            inicio = null;
        }


        public void iniciar_poblacion(int t_poblacion) //realizar paso uno
        {
            Random rand = new Random(); //objeto para generar numeros aleatorios
            int digito; //entero que estara entre 0 o 1
            String cuerpo; //cuerpo del individuo (Grupo de 8 bits)

            for (int i = 0; i < t_poblacion; i++) //for para generar a todos los individuos
            {
                cuerpo = "";
                for(int j = 0; j < 8; j++)
                {
                    digito = rand.Next(0, 2); //generar numero que sera 0 o 1
                    cuerpo += digito.ToString();//añadir el bit al cuerpo
                }

                Individuo nuevo = new Individuo(cuerpo); // generar individuo

                if(inicio == null) //comprobar si es el primer elemento
                {
                    inicio = nuevo; 
                }
                else
                {
                    Individuo aux = inicio; //evitar que la lista se vea afectada

                    while (aux.siguiente != null)
                        aux = aux.siguiente; //conseguimos el ultimo elemento de la lista

                    aux.siguiente = nuevo; //guardamos el individuo
                }

                cuerpo = ""; //vaciamos el cuerpo para el siguiente individuo

            }

        }

        public void imprimir()
        {
            int num = 1;
            if(inicio == null)
                Console.WriteLine("No hay nada");
            else
            {
                Individuo aux = inicio;
                while(aux != null)
                {
                    Console.WriteLine(num.ToString() + "-> " + aux.bites);
                    aux = aux.siguiente;
                    num++;
                }
            }
        }

    }
}
