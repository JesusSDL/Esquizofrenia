using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquizofrenia
{
    public class Cliente
    {
        public string nombreApellido;
        public int dni { get; set; }

        public string user { get; set; }
        public string password { get; set; }
        public string correoElectronico { get; set; }
        public int idUser { get; set; }
        public int numTelefono { get; set; }

        public Cliente(string nombreApellido, int dni, string user, string password)
        {
            this.nombreApellido = nombreApellido;
            this.dni = dni;
            this.user = user;
            this.password = password;
 
        }

        public Cliente(string correoElectronico, int numTelefono)
        {
            this.numTelefono = numTelefono;
             this.correoElectronico = correoElectronico;

        }
        public Cliente(string user, string pwd)
        {
            this.user = user;
            this.password = pwd;

        }
        public void modificarEstadoMesa()
        {

        }
        public void agregarPedido()
        {

        }
    }
}
