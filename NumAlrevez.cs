using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImprimirAlrevez
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese un numero");
            NumAlrevez n1 = new NumAlrevez(Console.ReadLine());
            Console.WriteLine(n1.Invertir());
            Console.ReadKey();
        }
    }

    class NumAlrevez
    {
        string Num;
        public NumAlrevez(string num)
        {
            Num = num;
        }
        public string Num1 { get => Num; }

        public string Invertir()
        {
            string aux = Num;
            for (int i=Num.Length-1; i>=0; i--)
                aux += aux[i];
            return aux;
        }
    }
}
