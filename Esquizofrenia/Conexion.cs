
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
public class Conexion
{
    public string sv = "localhost";
    public string bd = "esquizofrenia";
    public string user = "admin";
    public string pwd = "Administrador.";
    public MySqlConnection conectarse()
    {
        
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



}


