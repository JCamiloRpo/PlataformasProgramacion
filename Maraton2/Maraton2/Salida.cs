using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maraton2
{
    public class Salida
    {
        string Name;
        int Nro;

        public Salida(string name, int nro)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Nro = nro;
        }

        public string attName { get => Name; set => Name = value; }
        public int attNro { get => Nro; set => Nro = value; }

    }
}
