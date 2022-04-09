using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUniversidad
{
    public class ListaLigadaDobleGrupo
    {
        public ArregloCarrera ligaGrupo = new ArregloCarrera();

        public string InsertarGrupoFinal(short grado, char letra, string turno, string especialidad, int pos)
        {

            string respuesta = "";
            Grupo temp = null;
            Grupo nuevo = new Grupo
            {
                Grado = grado,
                Letra = letra,
                Turno = turno,
                Especialidad = especialidad
            };
            if (ligaGrupo.arre[pos].cabeza == null)
            {//SI LA LISTA ESTA VACIA SE AGREGA EN LA CABEZA
                ligaGrupo.arre[pos].cabeza = nuevo;
                respuesta = "Se agrego nodo de grupo a la cabeza";
            }
            else
            {//SE AGREGA AL FINAL DE LA LISTA, NECESARIO RECORRER LISTA
                temp = ligaGrupo.arre[pos].cabeza;
                while (temp.sig != null)
                {
                    temp = temp.sig;
                }//CUANDO SALE DEL CICLO TEMP YA ESTA EN EL ULTIMO NODO
                temp.sig = nuevo;
                nuevo.ant = temp;
                respuesta = "Nodo de grupo agregado al final de la lista";
            }
            return respuesta;
        }
        public string InsertarGrupoInicio(short grado, char letra, string turno, string especialidad, int pos)
        {
            string mensaje = "";
            Grupo nuevo = new Grupo
            {
                Grado = grado,
                Letra = letra,
                Turno = turno,
                Especialidad = especialidad
            };
            if (ligaGrupo.arre[pos].cabeza != null)//verifica que la cabeza no sea nula
            {
                nuevo.sig = ligaGrupo.arre[pos].cabeza;
                ligaGrupo.arre[pos].cabeza.ant = nuevo;
                ligaGrupo.arre[pos].cabeza = nuevo;
                mensaje = "Agregado al primer nodo";
            }
            else//si es nula, se le asigna el nuevo nodo
            {
                ligaGrupo.arre[pos].cabeza = nuevo;
                mensaje = "Nueva cabeza creada";
            }
            return mensaje;
        }
        public string InsertarMedio(short grado, char letra, string turno,
            string especialidad, int posCarrera,int posMedio)
        {
            int x = 0;
            string mensaje = "";
            Grupo nuevo = new Grupo
            {
                Grado = grado,
                Letra = letra,
                Turno = turno,
                Especialidad = especialidad
            };
            Grupo temp = ligaGrupo.arre[posCarrera].cabeza;
            if (temp != null)//verifica que la cabeza no sea nula
            {
                while (temp!=null)
                {
                    if (x == posMedio)
                    {
                        
                        if(temp.sig==null)//verifica que no sea el ultimo
                        {
                            temp.sig = nuevo;
                            nuevo.ant = temp;
                            mensaje = "Nodo agregado al final";
                        }
                        else
                        {
                            temp.sig.ant = nuevo;
                            nuevo.sig = temp.sig;
                            nuevo.ant = temp;
                            temp.sig = nuevo;
                            mensaje = "Nodo agregado en medio";
                        }
                    }
                    temp = temp.sig;
                    x++;
                }             
            }
            else//si es nula, se le asigna el nuevo nodo
            {
                temp = nuevo;
                mensaje = "Nueva cabeza creada";
            }
            return mensaje;
        }
        public Grupo EliminarGrupo(int posCarrera, int posEliminar)
        {
            
            Grupo temp = BuscaGrupo(posCarrera, posEliminar);
            Grupo aux = temp;          

            if (temp != null)
            {
                if (temp == ligaGrupo.arre[posCarrera].cabeza)
                {//Nodo a eliminar es la cabeza
                    if (temp.sig != null)
                    {
                        ligaGrupo.arre[posCarrera].cabeza = temp.sig;
                        temp.sig.ant = null;
                        temp = null;
                    }
                    else
                        ligaGrupo.arre[posCarrera].cabeza = null;
                }
                else if (temp.sig == null)
                {//Nodo a eliminar es el ultimo
                    temp.ant.sig = null;
                    temp.ant = null;
                }
                else
                {//Nodo a eliminar es intermedio
                    temp = temp.ant;
                    temp.sig = aux.sig;
                    temp.sig.ant = temp;
                }
                              
            }
                
            return aux;
        }
        public string[] MostrarGrupos(int pos)
        {
            string[] datos=null;
            if (ligaGrupo.control > pos)
            {
                Grupo temp = null;
                temp = ligaGrupo.arre[pos].cabeza;
                int totalNodos = ContarNodos(pos);
                int x = 0;
                temp = ligaGrupo.arre[pos].cabeza;
                datos = new string[totalNodos];
                if (temp == null)
                {
                    datos = null;
                }
                else
                {
                    while (temp != null)
                    {
                        datos[x] = temp.Mostrar();
                        temp = temp.sig;
                        x++;
                    }
                }
            }               
            return datos;
        }
        private int ContarNodos(int pos)
        {
            int cuentaNodos = 0;
            Grupo temp = ligaGrupo.arre[pos].cabeza;
            while (temp != null)
            {
                temp = temp.sig;
                cuentaNodos++;
            }
            return cuentaNodos;
        }
        public Grupo BuscaGrupo(int posCarrera,int posGrupo)
        {
            int x = 0;
            Grupo temp = ligaGrupo.arre[posCarrera].cabeza;
            Grupo aux = null;
            while (temp != null)
            {
                if (x == posGrupo)
                {
                    aux = temp;
                }
                temp = temp.sig;
                x++;
            }            
            return aux;
        }
    }
}
