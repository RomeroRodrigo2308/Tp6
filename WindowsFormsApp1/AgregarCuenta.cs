using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ej2;

namespace WindowsFormsApp1
{
    public partial class AgregarCuenta : Form
    {
        Bank iBank = new Bank();

        public AgregarCuenta()
        {
            InitializeComponent();

            comboBox1.DataSource = Enum.GetValues(typeof(DocumentType));
        }

        private void button1_Click(object sender, EventArgs e)
        {// Incompleto
            if (radioButton1.Checked)
            {
                iBank.AperturaCuenta(Convert.ToInt32(textBox1.Text), textBox3.Text, Convert.ToDouble(textBox4.Text));
            }
        }
    }
}
