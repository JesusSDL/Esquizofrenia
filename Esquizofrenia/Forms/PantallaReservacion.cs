using Esquizofrenia;
using Esquizofrenia.Dao;
using Esquizofrenia.modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pantallas.Forms
{
    public partial class PantallaReservacion : Form
    {
        public PantallaReservacion()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int nroMesa = int.Parse(txtMesaSeleccion.Text);
            Mesa mesita = new Mesa(nroMesa);
            /* MesaDAO mDAO = new MesaDAO();
            List<Mesa> lasMesasDisponibles = mDAO.traerMesasDispo();
                if (lasMesasDisponibles.Contains(mesita))
                */
                    string correo = txtCorreo.Text;
                    string nroTelefono = txtNumeroTelefono.Text;
                    string hora = txtHora.Text;
                    string date = txtFecha.Text;

                    Reserva reservita = new Reserva(date, hora);
                    Cliente cli = new Cliente(correo, nroTelefono);
                    ReservaDAO rDAO = new ReservaDAO();
                    rDAO.reservandoMesa(cli, mesita, reservita);
                  //  PantallaSideBar pSideBar = new PantallaSideBar();
                  //  pSideBar.Show();
                   
  
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
