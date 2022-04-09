using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUniversidad
{
    public class Carrera
    {
        public string Nombre { get; set; }
        public short Año_fundacion { get; set; }

        public Grupo cabeza = null;
        public string Mostrar()
        {
            return Nombre + " " + Año_fundacion;
        }
    }
}
