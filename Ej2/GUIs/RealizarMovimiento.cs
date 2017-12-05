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
    public partial class RealizarMovimiento : Form
    {
        Bank iBank;

        public RealizarMovimiento()
        {
            iBank = new Bank();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                try
                {
                    iBank.RealizarMovimiento(Convert.ToInt32(textBox1.Text), richTextBox1.Text, Convert.ToDouble(textBox3.Text) * (-1));
                    iBank.RealizarMovimiento(Convert.ToInt32(textBox2.Text), richTextBox1.Text, Convert.ToDouble(textBox3.Text));
                    MessageBox.Show("Movimiento realizado con exito");
                    Close();
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("El formato de los datos ingresados no es correcto, por favor revise los campos");
                }
            }
            else
            {
                MessageBox.Show("Los campos referentes a las cuentas y al monto no pueden quedar vacios");
            }
        }
    }
}
