using Esquizofrenia.modelo;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
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
            string user = "root";
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
            string queryAltaPlato = "INSERT INTO plato (nombre, tamaño, precio) VALUES (@nombre, @tamaño, @precio);";
            MySqlCommand comando = new MySqlCommand(queryAltaPlato, conectarse());
            comando.Parameters.Add(new MySqlParameter("@nombre", platazo.nombre));
            comando.Parameters.Add(new MySqlParameter("@tamaño", platazo.tamanio));
            comando.Parameters.Add(new MySqlParameter("@precio", platazo.precio));
            comando.ExecuteNonQuery();
        }


        public DataTable getPlatos()
        {
            try
            {
                string query = "SELECT nombre as Nombre, tamaño as Tamaño, precio as Precio FROM plato;";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conectarse());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;

            }
            catch (MySqlException error) { 
                Console.WriteLine(error.ToString());
                return null;
            }

            
        }
        public List<Plato> sauronPlatos()
        {
            List<Plato> losPlatazos = new List<Plato>();
            string queryLosPlatos = "SELECT nombre, tamaño, precio FROM plato;";
            MySqlDataReader verSauron = null;
            try
            {
                MySqlCommand comando = new MySqlCommand(queryLosPlatos);
                comando.Connection = conectarse();
                verSauron = comando.ExecuteReader();
                while (verSauron.Read())
                {
                    string nombre = verSauron.GetString("nombre");
                    string tamanio = verSauron.GetString("tamaño");
                    float precio = verSauron.GetFloat("precio");
                    Plato p = new Plato(nombre, tamanio, precio);
                    losPlatazos.Add(p);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return losPlatazos;
        }
    }
}
