using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquizofrenia
{
    internal class ReservaDAO : Conexion
    {
        public void reservandoMesa(Cliente cli, Mesa mesita, Reserva reservita)
        {
            
            string clienteReserva = "INSERT INTO reserva (num_telefono, fecha, hora, correo, mesa_id_mesa ) VALUES (@num_telefono, @fecha, @hora, @correo, @id);";
            MySqlCommand comando = new MySqlCommand(clienteReserva, conectarse());
            comando.Parameters.Add(new MySqlParameter("@num_telefono", cli.numTelefono));
            comando.Parameters.Add(new MySqlParameter("@fecha", reservita.fecha));
            comando.Parameters.Add(new MySqlParameter("@hora", reservita.hora));
            comando.Parameters.Add(new MySqlParameter("@correo", cli.correoElectronico));
            comando.Parameters.Add(new MySqlParameter("@id", mesita.id));
            comando.ExecuteNonQuery();
            string mesaFalse = "UPDATE mesa SET estado = @estado WHERE id_mesa = @id;";
            MySqlCommand comando2 = new MySqlCommand(mesaFalse, conectarse());
            comando2.Parameters.Add(new MySqlParameter("@estado", "reservada"));
            comando2.Parameters.Add(new MySqlParameter("@id", mesita.id));
            comando2.ExecuteNonQuery();
            
        }
    }
}
