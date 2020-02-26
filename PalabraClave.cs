using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalabraClave
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese la palabra clave");
            string clave = Console.ReadLine();
            Console.WriteLine("Ingrese la linea");
            string linea = Console.ReadLine();
            PalabraClave pc = new PalabraClave(linea, clave);
            Console.WriteLine(pc.Encontrar());
        }

        class PalabraClave
        {
            string Linea, Clave;
            public PalabraClave(string linea, string clave)
            {
                Linea = linea.ToLower();
                Clave = clave.ToLower();
            }
            public string Encontrar()
            {
                //Caso 1: dfgihguiiuyyuiclavefghhgh - clave
                if (Linea.Contains(Clave))
                    return "1";
                //Caso 2: fghCgLhAghVhjEgh - clave
                for(int i = 0, j = 0; j < Linea.Length; j++)
                {
                    if (i == Clave.Length)
                        return "2";
                    if (Linea[j] == Clave[i])
                        i++;
                }
                //Caso 3: afeEaedVefsAsefLedCaef - clave
                for (int i = Clave.Length-1, j = 0; j < Linea.Length; j++)
                {
                    if (i == -1)
                        return "3";
                    if (Linea[j] == Clave[i])
                        i--;
                }
                //Caso 4: No esta la palabra clave
                return "4";
            }
        }
    }
}
