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

namespace Esquizofrenia.Forms
{
    public partial class PantallaABMCPlatos : Form
    {   
        
        public PantallaABMCPlatos()
        {
            InitializeComponent();
            PlatoDAO platoDAO = new PlatoDAO();
            dataGridViewPlatos.AllowUserToAddRows = false;
            try {
                
                dataGridViewPlatos.DataSource = platoDAO.getPlatos();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String nombrePlato = txtNombrePlato.Text;
            String tamanio = txtTamanio.Text;
            float precio = float.Parse(txtPrecio.Text);
            Plato newPlato = new Plato(nombrePlato,tamanio, precio);
            PlatoDAO platoDAO = new PlatoDAO();
            platoDAO.agregarPlato(newPlato);

            txtNombrePlato.Text = "";
            txtTamanio.Text = "";
            txtPrecio.Text = "";

        }
    }
}
