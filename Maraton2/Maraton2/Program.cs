using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maraton2
{
    class Program
    {
        static void Main(string[] args)
        {
            SistemaIrrigacion[] sistemas = new SistemaIrrigacion[10];
            StreamReader arch = new StreamReader(@"..\..\..\Sistemas.txt");
            StreamWriter sal = new StreamWriter(@"..\..\..\Calculos.txt");
            string linea;
            string[] sis = new string[50];
            int n = 0, i = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Iniciando...");
            while ((linea = arch.ReadLine()) != null) //Leer archivo para ir llenando el vector
            {
                if (linea.Equals("9999 9999 9999")) break;
                if (!linea.Equals("*"))
                {
                    sis[i] = linea; //Lleno posicion del vector a enviar
                    i++;
                }
                else
                {
                    sistemas[n] = new SistemaIrrigacion(sis,i); //Creo sistema
                    n++;
                    i = 0; //inicializo
                }
            }
            arch.Close();
            Console.WriteLine("Fin de lectura");
            for (i = 0; i < n; i++)//Escribir resultados
            {
                sal.WriteLine("Sistema de Irrigación # " + (i + 1));
                sal.WriteLine(sistemas[i].CalcularConfiguraciones());
            }
            sal.Close();
            Console.WriteLine("Fin de escritura");
            Console.WriteLine("Terminado");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Press Enter to Exit");
            Console.ReadKey();
        }
    }
}
