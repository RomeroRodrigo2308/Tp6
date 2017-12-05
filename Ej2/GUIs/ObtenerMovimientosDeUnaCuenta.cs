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
    public partial class ObtenerMovimientosDeUnaCuenta : Form
    {
        Bank iBank;

        public ObtenerMovimientosDeUnaCuenta()
        {
            iBank = new Bank();

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    BindingSource mSource = new BindingSource();

                    foreach (AccountMovementDTO mMovement in iBank.GetAccountMovements(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)))
                    {
                        mSource.Add(mMovement);
                    }

                    dataGridView1.DataSource = mSource;

                    dataGridView1.AutoGenerateColumns = true;

                    dataGridView1.Refresh();
                }
                else
                {
                    MessageBox.Show("No deje campos en blanco");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("El formato de alguno de los campos no es correcto");
            }
        }
    }
}
