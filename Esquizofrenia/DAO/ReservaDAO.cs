using Esquizofrenia.modelo;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquizofrenia.Dao
{
    public class ReservaDAO : Conexion
    {

        public ReservaDAO() {
            MySqlConnection c = conectarse();
        }

        public void reservandoMesa(Cliente cli, Mesa mesita, Reserva reservita)
        {
            using (MySqlConnection connection = conectarse())
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string clienteReserva = "INSERT INTO reserva (num_telefono, fecha, hora, correo, mesa_id_mesa) VALUES (@num_telefono, @fecha, @hora, @correo, @id);";
                        using (MySqlCommand comando = new MySqlCommand(clienteReserva, connection, transaction))
                        {
                            comando.Parameters.Add(new MySqlParameter("@num_telefono", cli.NumTelefono));
                            comando.Parameters.Add(new MySqlParameter("@fecha", reservita.fecha));
                            comando.Parameters.Add(new MySqlParameter("@hora", reservita.hora));
                            comando.Parameters.Add(new MySqlParameter("@correo", cli.CorreoElectronico));
                            comando.Parameters.Add(new MySqlParameter("@id", mesita.Id));
                            comando.ExecuteNonQuery();
                        }

                        string mesaReservada = "UPDATE mesa SET estado = 'ocupada' WHERE id_mesa = @id;";
                        using (MySqlCommand comando2 = new MySqlCommand(mesaReservada, connection, transaction))
                        {
                            comando2.Parameters.Add(new MySqlParameter("@id", mesita.Id));
                            comando2.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        transaction.Rollback(); 
                    }
                }
            }

        }



    }
}
