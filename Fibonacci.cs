using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese numero a obtener secuencia Fibonacci");
            Number number = new Number(Convert.ToInt32(Console.ReadLine()));
            foreach (int i in number.getFibonacci())
                Console.Write(i + " ");
            Console.WriteLine("");
            Console.ReadKey();
        }
    }

    class Number
    {
        int n;

        public Number(int n)
        {
            this.n = n;
        }

        public int N { get => n; set => n = value; }

        public int[] getFibonacci()
        {
            int[] sequence = new int[n+1];
            int num=0;
            for(int i=0; i < n+1; i++)
            {
                num = (int) ((Math.Pow(((1 + Math.Sqrt(5)) / 2), i) - Math.Pow(((1 - Math.Sqrt(5)) / 2), i)) / Math.Sqrt(5) );
                sequence[i] = num;
            }
            return sequence;
        }
    }
}
