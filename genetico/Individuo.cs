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

        //Constructor 
        public Individuo(String _bites)
        {
            siguiente = null; //inicializamos a null debido a que no sabemos a que nodo apuntará
            bites = _bites;
        }

    }
}
