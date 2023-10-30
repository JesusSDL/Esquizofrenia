using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esquizofrenia
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
            Cliente c = new Cliente("jesusdl", 123456);
            ReservaDAO  cDAO = new ReservaDAO();
            Mesa mesita = new Mesa(1);
            DateTime Hoy = DateTime.Now;
            Reserva reservita = new Reserva(Hoy, "13:00");
            cDAO.reservandoMesa(c, mesita, reservita);
            
           
        }
    }
}
