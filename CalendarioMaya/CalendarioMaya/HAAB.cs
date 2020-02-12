using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarioMaya
{
    class HAAB : Calendario
    {
        string Mes;
        static string[] Meses = {"pop","no","zip","zotz","tzec","xul","yoxkin","mol","chen","yax","zac","ceh","mac","kankin","muan","pax","koyab","cumhu"};

        public HAAB(int nroDia, string mes, int año):base(nroDia,año)
        {
            if(año < 5000)
                Año = año;
            if (Meses.Contains<string>(mes))
            {
                Mes = mes;
                if (mes.Equals(Meses[17]) && nroDia < 5)
                    NroDia = nroDia;
                else if (nroDia < 20)
                    NroDia = nroDia;
            }
        }

        public string Mes1 { get => Mes; set => Mes = value; }
        public static string[] Meses1 { get => Meses; set => Meses = value; }

        public Tzolkin toTzolkin()
        {
            int dia,año,nromes = index(Mes)+1;
            string nom;
            if (NroDia < 13)
                dia = NroDia + 1;
            else
                dia = NroDia - 12;
            nom = Tzolkin.Nombres1[NroDia];
            año = (int)Math.Round(((double)(Año*365 + nromes*20)/ (double)260),0);
            return new Tzolkin(dia, nom, año);
        }

        int index(string pal)
        {
            for (int i = 0; i < Meses.Length; i++)
                if (Meses[i].Equals(pal))
                    return i;
            return -1;
        }

        public string toString()
        {
            return NroDia + ". " + Mes + " " + Año;
        }

    }
}
