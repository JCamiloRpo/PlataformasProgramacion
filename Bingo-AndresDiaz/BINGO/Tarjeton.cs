using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BINGO
{
    class Tarjeton
    {

        private string[] BINGO;
        private int[,] NumerosAle;

        public Tarjeton(string[] bINGO, int[,] numerosAle)
        {
            BINGO1 = bINGO;
            NumerosAle1 = numerosAle;
        }

        public string[] BINGO1 { get => BINGO; set => BINGO = value; }
        public int[,] NumerosAle1 { get => NumerosAle; set => NumerosAle = value; }

        public string Imprimir() {
            string imprimir = BINGO[0] + BINGO[1] + BINGO[2] + BINGO[3] + BINGO[4] + "\n";
            /*int[,] soporte = NumerosAle;
            string imprimir2 = imprimir;*/
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {

                    imprimir += NumerosAle[i, j] + " || ";
                    //imprimir2 += soporte[i, j] + " || ";

                }
                imprimir += "\n";
                //imprimir2 += "\n";
            }

            return imprimir /*+ "                    " + imprimir2*/;
        }
        public int[,] Marcar(string pos) {

            string[] splt = (pos.Split(','));

            for (int i = 0; i < 5; i++)
            {

                for (int j = 0; j < 5; j++)
                {

                    if (i == Convert.ToInt32(splt[0]) && j == Convert.ToInt32(splt[1]))
                    {

                        NumerosAle[i, j] = 0;

                    }

                }   
            }
            Console.Clear();
            return NumerosAle;
        }

    }
}
