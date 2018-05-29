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
            String cuerpo; //cuerpo del individuo (Grupo de 8 bits)

            int digito, //entero que estara entre 0 o 1
                _decimal; //variable donde se almacenará la conversion decimal de cada individuo 
            double apti = 0, //varibale donde se almacenará la aptitud del individuo
                   fnom = 0, //varibale donde se almacenará la fnormal del individuo
                   facum = 0; //varibale donde se almacenará el acumulado respectivo del individuo

            for (int i = 0; i < t_poblacion; i++) //for para generar a todos los individuos
            {
                cuerpo = "";
                for(int j = 0; j < 8; j++)
                {
                    digito = rand.Next(0, 2); //generar numero que sera 0 o 1
                    cuerpo += digito.ToString();//añadir el bit al cuerpo
                }

                _decimal = calcular_x(cuerpo); //obtener valor decimal del binario
                apti = calcular_aptitud(_decimal); //obtener aptitud

                Console.WriteLine(apti / get_sumatoria());

                facum += fnom; //obtener acumulado

                Individuo nuevo = new Individuo(cuerpo, _decimal, apti); // generar individuo

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

            //calculamos fnom y acumulado

            Individuo calculo = inicio; //auxiliar para asigniar ultimos valores

            while (calculo != null)
            {
                calculo.fnom = calculo.aptitud / get_sumatoria(); //realizar fnom mediante formula por individuo
                facum += calculo.fnom; //calcular acumulado 
                calculo.acumulado = facum; //asignar el acumulado al respectivo individuo

                calculo = calculo.siguiente;
            }

        }

        public void imprimir() //imprimimos la tabla
        {
            Console.Clear(); //limpiar consola

            int num = 1;
            String fx, fnom, acum; //variables para recortar

            if(inicio == null)
                Console.WriteLine("No hay nada");
            else
            { 
                Console.WriteLine("# Individuo   Decimal    f(x)    fnom    Acumulado"); //cabezera de tabla
                Individuo aux = inicio;
                while(aux != null)
                {
                    fx = aux.aptitud.ToString(); //convertimos a String para obtener los primeros 4 caracteres           
                    fnom = aux.fnom.ToString();
                    acum = aux.acumulado.ToString();

                    //imprimir informacion del individuo
                    Console.WriteLine(num.ToString() + " " + aux.bites + "\t" + aux.x + "\t " + Math.Round(aux.aptitud, 2) + "\t" + Math.Round(aux.fnom, 2) + "\t" 
                        + Math.Round(aux.acumulado,2));
                    
                    //recorremos
                    aux = aux.siguiente;
                    num++;

                }
            }
        }

        private int calcular_x(String cuerpo) //convertimos el string a numero binario
        {
            int numero = 0, //variable para obtener sumatoria
                bin = 128; // calculo de binario a decimal
            char bit; //obtener la letra en la posicion del for

            for (int i = 0; i < 8; i++)
            {
                bit = cuerpo[i];

                if (bit == '1')
                    numero += bin;

                bin /= 2;
            }

            return numero; //regresamos el numero en int 32
        }

        private double calcular_aptitud(int x) //calcular aptitud del individuo
        {
            return (Math.Sin((Math.PI * x) / 256)); //regresamos el calculo
        }

        public double get_sumatoria()
        {
            Individuo aux = inicio;
            double sum = 0;

            while(aux != null)
            {
                sum += aux.aptitud;
                aux = aux.siguiente;
            }

            return Math.Round(sum,2);
        }

    }
}
