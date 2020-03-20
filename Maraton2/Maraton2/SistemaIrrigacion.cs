using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Maraton2
{
    public class SistemaIrrigacion
    {
        Entrada[] Entradas;
        Valvula[] Valvulas;
        Salida[] Salidas;
        string[] Configuraciones= new string[10];
        int nIn, nOut, nVal, nConf;

        public SistemaIrrigacion(string[] sis, int nroLines)
        {
            string[] split;
            int j=0,k=0,l=0,m=0;
            
            for(int n=0; n < nroLines; n++)
            {
                split = sis[n].Split(' ');
                if (n == 0)// Leer los tamaños
                {
                    nIn = Convert.ToInt32(split[0]);
                    nOut = Convert.ToInt32(split[1]);
                    nVal = Convert.ToInt32(split[2]);
                    Entradas = new Entrada[nIn];
                    Valvulas = new Valvula[nVal];
                    Salidas = new Salida[nOut];
                }
                else if (n == 1)//Asignar flujos de entradas
                {
                    for (int i = 0; i < nIn; i++)
                        Entradas[i] =new Entrada(Convert.ToSingle(split[i]));
                }
                else if(n < (nIn + 2))//Asignar nombres a las Entradas y la Valvula que le corresponde
                {
                    Entradas[j].attName = split[0];
                    Valvulas[j] = new Valvula(split[1], j);
                    Entradas[j].attVal = Valvulas[j];
                    j++;
                }
                else if (n < (nOut + nIn + 2))//Asignar nombres a las Salidas
                {
                    Salidas[k] = new Salida(sis[n], k);
                    k++;
                }
                else if(n < (nVal + nOut + nIn + 2))//Asignamiento a las valvulas
                {

                    int pos;
                    Valvulas[l] = Valvulas[l] ?? new Valvula(split[0], l);
                    //Asignar por izquierda
                    pos = Convert.ToInt32(Regex.Replace(split[1], @"[^\d]", "")) - 1; //Obtener solo los numeros de un texto con Regex.Replace
                    if (split[1][0] == 'S')
                        Valvulas[l].attEndIzq = Salidas[pos];
                    else
                    {
                        Valvulas[pos] = Valvulas[pos] ?? new Valvula(split[1],pos);
                        Valvulas[l].attIzq = Valvulas[pos];
                    }
                    //Asignar por derecha
                    pos = Convert.ToInt32(Regex.Replace(split[2], @"[^\d]", "")) - 1;
                    if (split[2][0] == 'S')
                        Valvulas[l].attEndDer = Salidas[pos];
                    else
                    {
                        Valvulas[pos] = Valvulas[pos] ?? new Valvula(split[2], pos);
                        Valvulas[l].attDer = Valvulas[pos];
                    }
                    l++;
                }
                else//Asignamiento de configuraciones
                {
                    Configuraciones[m] = sis[n];
                    m++;
                }
            }
            nConf = m;
        }

        public string CalcularConfiguraciones()
        {
            string salida = "";
            float[] flujos = new float[nOut];
            for (int i = 0; i < nOut; i++)//Inicializar flujos de salida
                flujos[i] = 0;
            for(int n = 0; n < nConf; n++) //Iterar sobre las configuraciones
            {
                salida += "Configuración de válvulas # " + (n + 1)+"\n";
                for (int i = 0; i < nIn; i++) //Iterar sobre las salidas segun una configuracion
                {
                    Valvula tmp; //Temporal que ira cambiando segun se cambie de valvula donde este parado
                    Salida sal = new Salida("S",0); //Salida que corresponde a una entrada segun la configuración 
                    //Iterar sobre las valvulas hasta llegar a una salida, es decir que tmp es null y sal queda con una salida 
                    for (tmp = Entradas[i].attVal; tmp != null; tmp = Configuraciones[n].Split(' ')[tmp.attNro] == "L" ? tmp.attIzq : tmp.attDer)
                        sal = Configuraciones[n].Split(' ')[tmp.attNro] == "L" ? tmp.attEndIzq : tmp.attEndDer;
                    
                    flujos[sal.attNro] += Entradas[i].attFlujo;//Acumulativo de los flujos de entrada
                }
                for (int i = 0; i < nOut; i++)//Iterar sobre las salidas
                {
                    salida += "Salida # " + (i + 1) + " : flujo " + flujos[i] + " galones/min\n";
                    flujos[i] = 0;
                }
            }
            return salida;
        }

    }
}
