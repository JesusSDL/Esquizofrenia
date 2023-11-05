using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquizofrenia.modelo
{
    internal class Plato
    {
            public string nombre { get; set; }
            public string tamanio { get; set; }
            public float precio { get; set; }

        public Plato(string nombre, string tamanio, float precio)
        {
            this.nombre = nombre;
            this.tamanio = tamanio;
            this.precio = precio;
        }

        public Plato()
        {
        }
    }
}
