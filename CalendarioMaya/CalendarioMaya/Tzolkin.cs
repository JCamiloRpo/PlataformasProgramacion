using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarioMaya
{
    public class Tzolkin : Calendario
    {
        string NomDia;
        static string[] Nombres = { "imix", "ik", "akbal", "kan", "chicchan", "cimi", "manik", "lamat", "muluk", "ok", "chuen", "eb", "ben", "ix", "mem", "cib", "caban", "eznab", "canac", "ahau" };
        
        public Tzolkin(int nroDia, string nomDia, int año) : base(nroDia, año)
        {
            Año = año;
            if (Nombres.Contains<string>(nomDia))
                NomDia = nomDia;
            if(nroDia < 14)
                NroDia = nroDia;
        }

        public string NomDia1 { get => NomDia; set => NomDia = value; }
        public static string[] Nombres1 { get => Nombres; set => Nombres = value; }

        public string ToString()
        {
            return NroDia+" "+NomDia+" "+Año;
        }
    }
}
