using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarioMaya
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader arcHAAB = new StreamReader(@"..\..\..\HAAB.txt");
            StreamWriter arcTzolkin = new StreamWriter(@"..\..\..\Tzolkin.txt");
            string linea;
            string[] form=new string[3];
            //Leyendo entrada
            linea = arcHAAB.ReadLine();
            int N = Convert.ToInt32(linea),i=0;
            HAAB[] fechas = new HAAB[N];
            while ((linea = arcHAAB.ReadLine()) != null)
            {
                form = linea.Split(' ');
                fechas[i] = new HAAB(Convert.ToInt32(form[0].Replace('.',' ')),form[1],Convert.ToInt32(form[2]));
                i++;
            }
            arcHAAB.Close();
            //Escribiendo salida
            arcTzolkin.WriteLine(N + "");
            for (i = 0; i < N; i++)
                arcTzolkin.WriteLine(fechas[i].toTzolkin().ToString());
            arcTzolkin.Close();
        }
    }
}
