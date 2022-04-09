using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUniversidad
{
    public class Grupo
    {
        public short Grado { get; set; }
        public char Letra { get; set; }
        public string Turno { get; set; }
        public string  Especialidad { get; set; }

        public Grupo sig=null;
        public Grupo ant=null;
        public Alumno cabezaAlumno = null;
        public string Mostrar()
        {
            return Grado + "" + Letra + " " + Turno + " " + Especialidad;
        }
    }
}
