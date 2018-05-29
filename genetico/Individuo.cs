//clase para cada nodo de los individuos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace genetico
{
    class Individuo
    {

        public Individuo siguiente;
        public String bites;
        public int x;
        public double aptitud;
        public double fnom;
        public double acumulado;

        //Constructor 
        public Individuo(String _bites, int _x, double _aptitud)
        {
            siguiente = null; //inicializamos a null debido a que no sabemos a que nodo apuntará
            x = _x;
            aptitud = _aptitud;
            fnom = 0;
            acumulado = 0;
            bites = _bites;
        }

    }
}
