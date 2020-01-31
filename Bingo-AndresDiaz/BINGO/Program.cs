using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BINGO
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] Bingo = new string[] { "B", "I", "N", "G", "O" };
            int[,] numerosAle = new int[5,5];
            int min = 1 , max = 15;
            var random = new Random();
            string marcar;

            for (int i = 0; i < 5; i++) {

                for (int j = 0; j < 5; j++) {

                    if (i == 2 && j == 2)
                    {

                        numerosAle[i, j] = 0;
                    }
                    else
                    {

                        numerosAle[j, i] = random.Next(min, max);
                                           
                    }
                }
                min += 15;
                max += 15;
            }
            Tarjeton BINGO = new Tarjeton(Bingo, numerosAle);
            Tarjeton BingoO = new Tarjeton(Bingo, numerosAle);
            
            Console.WriteLine(BINGO.Imprimir() + BingoO.Imprimir() + "\n");
            while (1==1)
            {
                


                marcar = Console.ReadLine();
                BINGO.Marcar(marcar);

                Console.WriteLine(BINGO.Imprimir()  + "\n");
                //Console.WriteLine(BingoO.Imprimir());
            }


            /*for (int i = 0; i < 5; i++)
            {

                Console.Write(Bingo[i] + " || ");

            }
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {

                for (int j = 0; j < 5; j++)
                {

                    Console.Write(NumerosAle[i,j] + "||");

                }
                Console.WriteLine();

            }*/
            
            Console.ReadKey();
        }

        
    }
}








































//Derechos reservados (JCamilo y ADiaz)