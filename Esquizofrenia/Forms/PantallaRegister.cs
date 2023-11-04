using Esquizofrenia;
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
    public partial class PantallaRegister : Form
    {
        public PantallaRegister()
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string nombreUsuario = txtUser.Text;
            int dni = int.Parse(txtDNI.Text);
            string contrasenia = txtPassword.Text;
            Cliente clientito = new Cliente(nombreUsuario, contrasenia, dni);
            ClienteDAO cDAO = new ClienteDAO();
            cDAO.agregarCliente(clientito);
            this.Close();
            PantallaSideBar pSideBar = new PantallaSideBar();
            pSideBar.Show();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
