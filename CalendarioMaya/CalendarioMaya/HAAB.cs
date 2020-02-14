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
            int dia=0,año=-1,nromes = index(Mes), total = Año * 365 + nromes * 20 + NroDia; ;
            string nom;
            for(int i = 0; i <= total; i++)
            {
                dia++;
                if (dia > 13)
                    dia = 1;
                if (i % 260 == 0)
                    año++;
            }
            nom = Tzolkin.Nombres1[NroDia];
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
