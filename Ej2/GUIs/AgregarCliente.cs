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
    public partial class AgregarCliente : Form
    {
        Bank iBank;
        public AgregarCliente()
        {
            iBank = new Bank();
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(DocumentType));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                try
                {
                    int mId = iBank.NuevoCliente(textBox1.Text, textBox2.Text, (DocumentType)comboBox1.SelectedItem, textBox3.Text);
                    MessageBox.Show("Cliente agregado satisfactoriamiente, su Id es: " + mId.ToString());
                    Close();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    MessageBox.Show("El cliente ya se encuentra cargado en la base de datos");
                }
                catch (Exception)
                {
                    MessageBox.Show("Ha ocurrido un error, por favor revise los campos");
                }
            }
            else
            {
                MessageBox.Show("No deje campos en blanco");
            }
        }
    }
}
