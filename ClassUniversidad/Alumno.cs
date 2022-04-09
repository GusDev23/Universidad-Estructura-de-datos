using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUniversidad
{
    public class Alumno
    {
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public short Edad {get; set; }

        public Alumno sigAlumno = null;
        public Alumno antAlumno = null;

        public string Mostrar()
        {
            return Matricula + " " + Nombre + " " + Edad;
        }
    }
}
