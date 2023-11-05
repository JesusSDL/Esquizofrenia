using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquizofrenia.modelo
{
   public class Cliente
    {
        private string nombreApellido;
        private int dni;
        private string user;
        private string password;
        private string correoElectronico;
        private int idUser;
        private string numTelefono;

        public string NombreApellido
        {
            get { return nombreApellido; }
            set{ nombreApellido = value; }
        }
        public int Dni 
        { 
            get { return dni; }
            set{dni = value; }
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string Password
        {
           get { return password; }
            set { password = value; }
        }

        public string CorreoElectronico
        {
            get { return correoElectronico;}
            set{ correoElectronico = value; }
        }

        public int IdUser
        {
            get { return idUser; }
            set {idUser = value; }
        }

        public string NumTelefono
        {
                get { return numTelefono; }
            set { numTelefono = value; }
        }

        Cuenta cuenta = new Cuenta();

        Mesa mesaAsignada = new Mesa(false);

        public Cliente(string nombreApellido, int dni, string user, string password, string correoElectronico, int idUser, string numTelefono)
        {
            this.nombreApellido = nombreApellido;
            this.dni = dni;
            this.user = user;
            this.password = password;
            this.correoElectronico = correoElectronico;
            this.idUser = idUser;
            this.numTelefono = numTelefono;
        }

        public Cliente(string nombreApellido, int dni, string correoElectronico, int idUser)
        {
            this.dni = dni;
            this.nombreApellido = nombreApellido;
            this.correoElectronico = correoElectronico;
            this.idUser = idUser;
        }

        public Cliente()
        {
        }

        public void modificarEstadoMesa(bool estado)
        {
            mesaAsignada.Estado = estado;
        }
        public void agregarPedido()
        {
            cuenta.agregarPedido();
        }

        public Cliente(string correoElectronico, string numTelefono)
        {
            this.numTelefono = numTelefono;
            this.correoElectronico = correoElectronico;

        }

    }
}
