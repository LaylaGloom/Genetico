using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace genetico
{
    class Padre
    {

        public Padre siguiente;
        public String bite;

        public Padre(String _bite)
        {
            siguiente = null;
            bite = _bite;
        }

    }
}
