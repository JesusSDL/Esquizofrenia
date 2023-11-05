using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Esquizofrenia.Dao
{
    public class Conexion

    {
        public MySqlConnection conexion;
        protected MySqlConnection conectarse()
        {
            string cadenaConexion = "server=localhost; Database=esquizofrenia; user id=root; password=Administrador.";
            conexion = new MySqlConnection(cadenaConexion);
            return conexion;
        }
        
        protected void abrirConexion()
        {
            conexion.Open();
        }

        protected void cerrarConexion()
        {
            conexion.Close();
        }
    }
}
