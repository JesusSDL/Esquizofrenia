using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquizofrenia
{
    internal class Plato
    {
        public string nombre { get; set; }
        public int tamaño { get; set; }
        public float precio { get; set; }

        public Plato(string nombre, int tamaño, float precio)
        {
            this.nombre = nombre;
            this.tamaño = tamaño;
            this.precio = precio;
        }
    }
}
