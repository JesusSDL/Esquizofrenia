using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquizofrenia
{
    internal class Mesa
    {
        public int id { get; set; }
        public bool estado { get; set; }
        
        public void moviendoMesa()
        {

        }
        public Mesa(int id, bool estado)
        {
            this.id = id;
            this.estado = estado;
        }
        public Mesa(int id)
        {
            this.id = id;
        }
    }
}
