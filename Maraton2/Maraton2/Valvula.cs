using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maraton2
{
    public class Valvula
    {
        Valvula Der, Izq;
        Salida EndDer, EndIzq;
        string Name;
        int Nro;

        public Valvula(string name, int nro)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Nro = nro;
        }

        public Valvula attDer { get => Der; set => Der = value; }
        public Valvula attIzq { get => Izq; set => Izq = value; }
        public Salida attEndDer { get => EndDer; set => EndDer = value; }
        public Salida attEndIzq { get => EndIzq; set => EndIzq = value; }
        public string attName { get => Name; set => Name = value; }
        public int attNro { get => Nro; set => Nro = value; }

    }
}
