using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquizofrenia.modelo
{
    public class Mesa
    {
        private int id;
        private bool estado;
    
        public int Id { get => id; set => id = value; }
        public bool Estado { get => estado; set => estado = value; }


        public Mesa(int id, bool estado)
        {
            this.id = id;
            this.estado = estado;
        }
        public Mesa(int id)
        {
            this.id = id;
        }

        public Mesa()
        {

        }

        public Mesa(bool estado)
        {
            this.estado = estado;
        }

    }
}
