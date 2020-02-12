using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarioMaya
{
    public abstract class Calendario
    {
        protected int NroDia;
        protected int Año;

        public Calendario(int nroDia, int año)
        {
            NroDia = nroDia;
            Año = año;
        }

        public int NroDia1 { get => NroDia; set => NroDia = value; }
        public int Año1 { get => Año; set => Año = value; }
    }
}
