using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquizofrenia.modelo
{
    internal class Cuenta
    {
        private int idMesa { get; set; }
        private float precioTotal { get; set; }
        private DateTime fecha { get; set; }

        public ArrayList pedidos = new ArrayList();

        public void agregarPedido()
        {
            pedidos.Add(new Pedido());
        }
    }
}
