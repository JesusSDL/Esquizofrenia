using Esquizofrenia.Forms;
using Pantallas.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pantallas
{
    public partial class Form1 : Form
    {
        PantallaSideBar pSideBar;
        PantallaRegister pRegister;
        Form pSideBarAdmin;
        bool dragging = false;
        Point dragCursorPoint;
        Point dragFormPoint;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "admin" && txtPassword.Text == "admin")
            {
                pSideBarAdmin = new PantallaSideBarAdmin();
                pSideBarAdmin.Show();
                this.Hide();
            }
            else {
                pSideBar = new PantallaSideBar();
                pSideBar.Show();
                this.Hide();
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pRegister = new PantallaRegister();
            pRegister.Show();
            this.Hide();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;

            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging) {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));

            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
