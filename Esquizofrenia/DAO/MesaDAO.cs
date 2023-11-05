using Esquizofrenia.modelo;
using MySqlConnector;
using System;
using System.Collections.Generic;

namespace Esquizofrenia.Dao
{
    public class MesaDAO : Conexion
    {
        public MesaDAO()
        {
                MySqlConnection c = conectarse();
        }

        public List<Mesa> traerMesasDisponibles()
        {
            List<Mesa> lasMesasDispo = new List<Mesa>();
            string queryMesasDispo = "SELECT id_mesa WHERE estado == 'disponible';";
            MySqlDataReader verSauron = null;
            try
            {
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
                Console.WriteLine(error.ToString());
            }
            return lasMesasDispo;
        }


        public void modificarEstadoReservada(int id)
        {
            string comando = string.Format("UPDATE mesa SET estado = 'ocupada' WHERE id_mesa =@num;");
            using (MySqlConnection connection = conectarse())
            {
                using (MySqlCommand adapter = new MySqlCommand(comando, connection))
                {
                    adapter.Parameters.AddWithValue("@num", id);
                    connection.Open();
                    adapter.ExecuteNonQuery();
                }
            }

        }

    }
}
