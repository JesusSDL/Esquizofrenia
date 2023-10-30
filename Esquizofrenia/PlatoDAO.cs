using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquizofrenia
{
    internal class PlatoDAO
    {
        public MySqlConnection conectarse()
        {
            string sv = "localhost";
            string bd = "esquizofrenia";
            string user = "admin";
            string pwd = "Administrador.";
            string cadenaConexion = ($" Database = {bd}; DataSource = {sv}; User Id = {user}; Password = {pwd}");
            MySqlConnection c = new MySqlConnection(cadenaConexion);
            try
            {
                c.Open();
                Console.WriteLine("hola");

            }
            catch (MySqlException error)
            {
                Console.WriteLine(error.ToString());
                return null;
            }
            return c;
        }
        public void agregarPlato(Plato platazo)
        {
            string queryAltaPlato = "INSERT INTO plato (nombre, tamanio, precio) VALUES (@nombre, @tamanio, @precio);";
            MySqlCommand comando = new MySqlCommand(queryAltaPlato, conectarse());
            comando.Parameters.Add(new MySqlParameter("@nombre", platazo.nombre));
            comando.Parameters.Add(new MySqlParameter("@tamanio", platazo.tamanio));
            comando.Parameters.Add(new MySqlParameter("@precio", platazo.precio));
            comando.ExecuteNonQuery();
        }
        public List<Plato> sauronPlatos()
        {
            List<Plato> losPlatazos = new List<Plato>();
            string queryLosPlatos = "SELECT nombre, tamanio, precio FROM plato;";
            MySqlDataReader verSauron = null;
            try
            {
                MySqlCommand comando = new MySqlCommand(queryLosPlatos);
                comando.Connection = conectarse();
                verSauron = comando.ExecuteReader();

            }
    }
}
