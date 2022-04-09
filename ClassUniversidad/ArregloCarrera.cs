using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUniversidad
{
    public class ArregloCarrera
    {
        public Carrera[] arre = new Carrera[9];
        public short control = 0;
        

        public string InsertarFinal(string carrera, short año)
        {
            string res = "";
            if (control < 9)
            {
                arre[control]= new Carrera();
                arre[control].Nombre = carrera;
                arre[control].Año_fundacion = año;
                control++;
                res = "Carrera agregada";
            }
            else
                res = "Arreglo lleno";
            return res;
        }
        public string InsertarInicio(string carrera, short año)
        {
            string mensaje = "";
            if (control < 9)
            {
                if (arre[0] != null)//cuando el arreglo tiene elementos
                {
                    for (int i = control; i >= 0; i--)//ciclo de atras hacia delante
                    {
                        if (i == 0)//hasta que recorre todo el arreglo se agrega al primero 
                        {
                            arre[i] = new Carrera();
                            arre[i].Nombre = carrera;
                            arre[i].Año_fundacion = año;
                            mensaje = "Carrera agregada al inicio";
                            control++;
                        }
                        else
                            arre[i] = arre[i - 1];
                    }
                }
                else//cuando el arreglo no tiene elementos
                {
                    arre[0] = new Carrera();
                    arre[0].Nombre = carrera;
                    arre[0].Año_fundacion = año;
                    mensaje = "Primer carrera agregada";
                    control++;
                }
            }
            else
                mensaje = "Arreglo lleno";

            return mensaje;
        }
        public string[] MostrarArreglo()
        {
            string[] temp = new string[control];
            for (int i = 0; i < control; i++)
            {
                temp[i] = arre[i].Mostrar();
            }
            return temp;
        }
        public Carrera EliminarCarrera(int indice)
        {
            Carrera temp = arre[indice];
            if (temp != null)
            {
                if (indice == control - 1)//si es el ultimo
                {
                    arre[indice] = null;
                }
                else
                {
                    for (int i = indice; i <= control - 2; i++)
                    {
                        if (control >= 1)
                        {
                            arre[i] = arre[i + 1];
                        }
                        else//es el primero y unico
                            arre[i] = null;

                    }
                }
                control--;
            }
            return temp;
        }
    }
}
