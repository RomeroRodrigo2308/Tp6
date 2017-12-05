using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ej2.GUIs
{
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarCliente ventana = new AgregarCliente();
            ventana.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AgregarCuenta ventana = new AgregarCuenta();
            ventana.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RealizarMovimiento ventana = new RealizarMovimiento();
            ventana.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ObtenerCuentasEnRojo ventana = new ObtenerCuentasEnRojo();
            ventana.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ObtenerCuentasDeUnCliente ventana = new ObtenerCuentasDeUnCliente();
            ventana.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ObtenerMovimientosDeUnaCuenta ventana = new ObtenerMovimientosDeUnaCuenta();
            ventana.Show();
        }
    }
}
