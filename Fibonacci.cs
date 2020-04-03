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
            foreach (long i in number.getFibonacci())
                Console.Write(i + " ");
            Console.WriteLine("");
            Console.ReadKey();
        }
    }

    class Number
    {
        long n;

        public Number(long n)
        {
            this.n = n;
        }

        public long N { get => n; set => n = value; }

        public long[] getFibonacci()
        {
            long[] sequence = new long[n];
            long num =0;
            for(int i=1,j=(int)(n-1); i < n+1; i++)
            {
                num = (long) ((Math.Pow(((1 + Math.Sqrt(5)) / 2), i) - Math.Pow(((1 - Math.Sqrt(5)) / 2), i)) / Math.Sqrt(5) );
                sequence[j--] = num;
            }
            return sequence;
        }
    }
}
