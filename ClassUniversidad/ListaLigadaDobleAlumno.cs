using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUniversidad
{
    public class ListaLigadaDobleAlumno
    {
        public ListaLigadaDobleGrupo refGrupo = new ListaLigadaDobleGrupo();

        public string InsertarAlumnoFinal(string matricula, string nom, short edad,int posCarrera, int posGrupo)
        {
            string respuesta = "";
            Grupo aux = refGrupo.BuscaGrupo(posCarrera, posGrupo);
            Alumno temp = aux.cabezaAlumno;
            Alumno nuevo = new Alumno
            {
                Matricula=matricula,
                Nombre=nom,
                Edad=edad
            };
            if (temp == null)             
            {
                aux.cabezaAlumno = nuevo;
                respuesta = "Se agrego nodo de alumno a la cabeza";
            }
            else
            {              
                while (temp.sigAlumno != null)
                {
                    temp = temp.sigAlumno;
                }//CUANDO SALE DEL CICLO TEMP YA ESTA EN EL ULTIMO NODO
                temp.sigAlumno = nuevo;
                nuevo.antAlumno = temp;
                respuesta = "Nodo de alumno agregado al final de la lista";
            }
            return respuesta;
        }
        public string InsertarAlumnoInicio(string matricula, string nom, short edad, int posCarrera, int posGrupo)
        {
            string mensaje = "";
            Grupo aux = refGrupo.BuscaGrupo(posCarrera, posGrupo);
            Alumno temp = aux.cabezaAlumno;
            Alumno nuevo = new Alumno
            {
                Matricula = matricula,
                Nombre = nom,
                Edad = edad
            };
            if (temp != null)//verifica que la cabeza no sea nula
            {
                nuevo.sigAlumno = temp;
                temp.antAlumno = nuevo;
                aux.cabezaAlumno = nuevo;
                mensaje = "Agregado al primer nodo";
            }
            else//si es nula, se le asigna el nuevo nodo
            {
                aux.cabezaAlumno = nuevo;
                mensaje = "Nueva cabeza creada";
            }
            return mensaje;
        }
        public string[] MostrarAlumnos(int posCarrera, int posGrupo)
        {
            Grupo aux = refGrupo.BuscaGrupo(posCarrera, posGrupo);
            Alumno temp = aux.cabezaAlumno;
            int totalNodos = ContarNodos(aux.cabezaAlumno);
            int x = 0;            
            string[] datos = new string[totalNodos];
            if (temp == null)
            {
                datos = null;
            }
            else
            {
                while (temp != null)
                {
                    datos[x] = temp.Mostrar();
                    temp = temp.sigAlumno;
                    x++;
                }
            }
            return datos;
        }
        public Alumno EliminarAlumno(int posCarrera,int posGrupo, int posEliminar)
        {

            Grupo cabezatemp = refGrupo.BuscaGrupo(posCarrera,posGrupo);
            Alumno temp = BuscaAlumno(posCarrera, posGrupo, posEliminar);
            Alumno aux = temp;
            if (temp != null)
            {
                if (temp == cabezatemp.cabezaAlumno)
                {//Nodo a eliminar es la cabeza
                    if (temp.sigAlumno != null)
                    {
                        cabezatemp.cabezaAlumno = temp.sigAlumno;
                        temp.sigAlumno.antAlumno = null;
                        temp = null;
                    }
                    else
                        cabezatemp.cabezaAlumno = null;
                }
                else if (temp.sigAlumno == null)
                {//Nodo a eliminar es el ultimo
                    temp.antAlumno.sigAlumno = null;
                    temp.antAlumno = null;
                }
                else
                {//Nodo a eliminar es intermedio
                    temp = temp.antAlumno;
                    temp.sigAlumno = aux.sigAlumno;
                    temp.sigAlumno.antAlumno = temp;
                }

            }
            return aux;
        }
            
        private int ContarNodos(Alumno aux)
        {
            int cuentaNodos = 0;
            Alumno temp = aux;
            while (temp != null)
            {
                temp = temp.sigAlumno;
                cuentaNodos++;
            }
            return cuentaNodos;
        }
        public Alumno BuscaAlumno(int posCarrera, int posGrupo,int posAlumno)
        {
            int x = 0;
            Grupo auxGrupo = refGrupo.BuscaGrupo(posCarrera,posGrupo);
            Alumno temp = auxGrupo.cabezaAlumno;
            Alumno aux = null;
            while (temp != null)
            {
                if (x == posAlumno)
                {
                    aux = temp;
                }
                temp = temp.sigAlumno;
                x++;
            }
            return aux;
        }
    }
}
