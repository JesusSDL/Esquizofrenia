using Esquizofrenia.modelo;
using MySqlConnector;
using System.Collections;

namespace Esquizofrenia.Dao
{
    public class ClienteDAO : Conexion
    {
        public ClienteDAO() {
            MySqlConnection c = conectarse();               
        }

        public void agregarCliente(Cliente cliente)
        {
            MySqlConnection c = null;
            c = conectarse();
            string insert = "INSERT INTO cliente (nombre_apellido, dni, correo, USER_id_user) VALUES (@nomApe, @dni, @correo, @idUser);";

            MySqlCommand command = new MySqlCommand(insert, c);
            command.Parameters.Add(new MySqlParameter("@nombre", cliente.NombreApellido));
            command.Parameters.Add(new MySqlParameter("@dni", cliente.Dni));
            command.Parameters.Add(new MySqlParameter("@correo", cliente.CorreoElectronico));
            command.Parameters.Add(new MySqlParameter("@idUser", cliente.IdUser));

            //string insertUser = "INSERT INTO user (user, password) VALUES (@user, @password);";
            //  MySqlCommand comandoUser = new MySqlCommand(insertUser, conectarse());
            //  comandoUser.Parameters.Add(new MySqlParameter("@user", cliente.user));
            //  comandoUser.Parameters.Add(new MySqlParameter("@password", cliente.password));
            // comandoUser.ExecuteNonQuery();
            command.ExecuteNonQuery();
        }
        public ArrayList logins(Cliente cliente)
        {
            string comando = string.Format("SELECT id_cliente FROM cliente WHERE user= @usuario AND password = @contrasena;");
            MySqlCommand adapter = new MySqlCommand(comando, conectarse());
            adapter.Parameters.AddWithValue("@usuario",cliente.User);
            adapter.Parameters.AddWithValue("@contrasena", cliente.Password);

            abrirConexion();
            MySqlDataReader lector;
            ArrayList log = new ArrayList();
            lector = adapter.ExecuteReader();
            while (lector.Read())
            {
                log.Add(lector["id_cliente"].ToString());
            }
            
            return log;
        }

    }
}
