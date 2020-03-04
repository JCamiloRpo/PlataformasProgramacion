using System;

namespace CifradoCadena
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese letra de inicio");
            char LI = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Ingrese letra de cifrado");
            char LC = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Ingrese la cadena");
            Cadena cadena = new Cadena { palabra = Console.ReadLine() };
            Console.WriteLine(cadena.Cifrar(LI, LC));
            Console.ReadKey();
        }
    }

    class Cadena
    {
        public string palabra;
        public string Cifrar(char LI, char LC)
        {//97 - 122
            string salida="",aux = palabra.ToLower(); //Convierto a minisculas para trabajar desde a (97) hasta z (122)
            char dif;
            if (LC > LI) dif = (char)(LC-LI); //Calculo la diferencia de las letras inicios, ya que esa diferencia se le suma a la letra de la cadena
            else dif = (char)(LI-LC);
            for(int i=0; i<aux.Length; i++)
            {
                if ((aux[i] + dif) > 122) //Si dicha suma de la diferencia es mayor a 122 se le resta 26 para volver al inicio EJ la suma da 123 - 26 = 97, que corresponde a la 'a'
                    salida += (char)((aux[i] + dif) - 26);
                else //Si no sobre pasa el limite se suma normal
                    salida += (char)(aux[i] + dif);
            }
            return salida;
        }
    }
}
