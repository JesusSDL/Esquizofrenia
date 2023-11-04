using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquizofrenia
{
    internal class MesaDAO
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
        public List<Mesa> traerMesasDispo()
        {
            List<Mesa> lasMesasDispo = new List<Mesa>();
            string queryMesasDispo = "SELECT id_mesa FROM mesa WHERE estado = 'disponible';";
           
            try
            {
                MySqlDataReader verSauron = null;
                MySqlCommand comando = new MySqlCommand(queryMesasDispo);
                comando.Connection = conectarse();
                verSauron = comando.ExecuteReader();

                while (verSauron.Read())
                {
                    int idNoReservada = verSauron.GetInt32("id_mesa");
                    Mesa mesita = new Mesa(idNoReservada);
                    lasMesasDispo.Add(mesita);
                }
            }
            catch (MySqlException error)
            { 
                Console.WriteLine (error.ToString());
            }
            return lasMesasDispo;
        }
    }
}
