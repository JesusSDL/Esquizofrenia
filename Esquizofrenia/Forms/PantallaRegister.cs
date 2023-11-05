using Esquizofrenia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Esquizofrenia.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Esquizofrenia.modelo;
using Esquizofrenia.Dao;

namespace Pantallas.Forms
{
    public partial class PantallaRegister : Form
    {
        bool dragging = false;
        Point dragCursorPoint;
        Point dragFormPoint;
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

        private void PantallaRegister_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        private void PantallaRegister_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging) {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void PantallaRegister_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
