using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalabraMedio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese la cadena con las tres palabras\nEj: Inicio Medio Final");
            //do /*Loop para probar varias palabras
            //{
                Console.ResetColor();
                Console.Write("\n> ");
                string cadena = Console.ReadLine();
                try
                {
                    bool r = Palabra.palabraMedio(cadena);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(cadena.Split(' ')[0] + " ");
                    if (r)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(cadena.Split(' ')[1] + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(cadena.Split(' ')[2] + " ");

                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                //Console.WriteLine("exit? Y / N.");
            //} while (Console.ReadKey().Key != ConsoleKey.Y);
            Console.WriteLine("\nFin del programa");
            Console.ReadKey();
        }
    }

    class Palabra
    {
        public static bool palabraMedio(string cadena)
        {
            string[] sp = cadena.Split(' ');
            if (sp.Length != 3) throw new Exception("\nFormato incorrecto\nEj: Inicio Medio Final\n");
            if (sp[0].CompareTo(sp[2]) < 0)
                return sp[0].CompareTo(sp[1]) < 0 && sp[1].CompareTo(sp[2]) < 0;
            else
                return sp[0].CompareTo(sp[1]) > 0 && sp[1].CompareTo(sp[2]) < 0;
        }
    }
}
