using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esquizofrenia;

namespace Esquizofrenia
{
    internal class ClienteDAO
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
                
            }
            catch (MySqlException error)
            {
                Console.WriteLine(error.ToString());
                
                
            }
            return c;
        }
        
     
        public void agregarCliente(Cliente cliente)
        {
            MySqlConnection c = null;
            c = conectarse();
            string insert = "INSERT INTO cliente (nombre_apellido, dni, user, password) VALUES (@nomApe, @dni, @user, @password);";

            MySqlCommand command = new MySqlCommand(insert, c);
            command.Parameters.Add(new MySqlParameter("@nomApe", cliente.nombreApellido));
            command.Parameters.Add(new MySqlParameter("@dni", cliente.dni));
            command.Parameters.Add(new MySqlParameter("@correo", cliente.correoElectronico));
            command.Parameters.Add(new MySqlParameter("@user", cliente.user));
            command.Parameters.Add(new MySqlParameter("@password", cliente.password));
            command.ExecuteNonQuery();
        }
        public bool logIn(Cliente cli)
        {
            string existeCliente = "SELECT user, password FROM cliente WHERE user = @user and password = @pwd;";
            MySqlCommand comando = new MySqlCommand(existeCliente, conectarse());
            comando.Parameters.Add(new MySqlParameter("@user", cli.user));
            comando.Parameters.Add(new MySqlParameter("@pwd", cli.password));
            return comando.ExecuteNonQuery() == 1;
            
        
        }


    }
    
}
