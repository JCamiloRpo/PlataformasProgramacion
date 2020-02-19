using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumeroARomano
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n;
                Console.WriteLine("Ingrese un numero del 1 al 100");
                n = Convert.ToInt32(Console.ReadLine());
                Numero num = new Numero(n);
                Console.WriteLine(num.ToRoman());
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: "+e.Message);
                Console.ReadKey();
            }
        }
    }

    class Numero
    {
        
        int num;
        public Numero(int n)
        {
            if (n > 0 && n <= 100)
                num = n;
            else
                throw new Exception("El numero debe ser entre 1 y 100");
        }
        public string ToRoman()
        {
            // 1 - I, 5 - V, 10 - X, 50 - L, 100 - C
            string[] roman = { "I", "V", "X", "L", "C" };
            string val="",rom;
            int ind = 0, aux = num % 10;
            for(int j = 0; j < 2; j++)
            {
                rom = "";
                for (int i = 1; i <= aux; i++)
                {
                    if (i < 4)
                        rom += roman[ind];
                    else if (i == 4)
                        rom = roman[ind] + roman[ind + 1];
                    else if (i == 5)
                        rom = roman[ind + 1];
                    else if (i < 9)
                        rom +=roman[ind];
                    else if (i == 9)
                        rom = roman[ind++] + roman[ind + 1];
                    else
                        rom = roman[ind + 1];
                }
                val = rom + val;
                aux = num / 10;
                ind = 2;
            }
            return val;
        }
    }
}
