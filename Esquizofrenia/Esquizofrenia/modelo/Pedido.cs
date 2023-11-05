using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquizofrenia.modelo
{
    internal class Pedido
    {
        private string detalle { get; set; }
        private float precio { get; set; }

        public ArrayList platos = new ArrayList();

        public void sumarPlato()
        {
            platos.Add(new Plato());
        }
        
    }
}
