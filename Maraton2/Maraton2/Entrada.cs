using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maraton2
{
    public class Entrada
    {
        string Name;
        Valvula Val;
        float Flujo;

        public Entrada(float flujo)
        {
            Flujo = flujo;
        }

        public Entrada(string name, Valvula val, float flujo)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Val = val ?? throw new ArgumentNullException(nameof(val));
            Flujo = flujo;
        }

        public string attName { get => Name; set => Name = value; }
        public Valvula attVal { get => Val; set => Val = value; }
        public float attFlujo { get => Flujo; set => Flujo = value; }
    }
}
