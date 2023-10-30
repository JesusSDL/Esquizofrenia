﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquizofrenia
{
    internal class ReservaDAO
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

        public void reservandoMesa(Cliente cli, Mesa mesita, Reserva reservita)
        {
            string clienteReserva = "INSERT INTO reserva FROM esquizofrenia (num_telefono, fecha, hora, correo) VALUES (@num_telefono, @fecha, @hora, @correo);";
            MySqlCommand comando = new MySqlCommand(clienteReserva, conectarse());
            comando.Parameters.Add(new MySqlParameter("@num_telefono", cli.numTelefono));
            comando.Parameters.Add(new MySqlParameter("@fecha", reservita.fecha));
            comando.Parameters.Add(new MySqlParameter("@hora", reservita.hora));
            comando.Parameters.Add(new MySqlParameter("@correo", cli.correoElectronico));
            comando.ExecuteNonQuery();
            string mesaFalse = "INSERT INTO mesa FROM esquizofrenia (estado) VALUES (@estado);";
            MySqlCommand comando2 = new MySqlCommand(mesaFalse, conectarse());
            bool ponerEstado = false;
            comando.Parameters.Add(new MySqlParameter("@estado", ponerEstado));
            comando2.ExecuteNonQuery();
        }
    }
}