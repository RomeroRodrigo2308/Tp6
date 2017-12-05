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
    public partial class ObtenerCuentasDeUnCliente : Form
    {
        Bank iBank;

        public ObtenerCuentasDeUnCliente()
        {
            iBank = new Bank();
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(DocumentType));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked && textBox1.Text != "")
                {
                    BindingSource mSource = new BindingSource();

                    foreach (AccountDTO mAccount in iBank.GetClientAccounts(Convert.ToInt32(textBox1.Text)))
                    {
                        mSource.Add(mAccount);
                    }

                    dataGridView1.DataSource = mSource;

                    dataGridView1.AutoGenerateColumns = true;

                    dataGridView1.Refresh();
                }
                else if (radioButton2.Checked && textBox2.Text != "")
                {
                    int mClientId = iBank.GetClientId((DocumentType)comboBox1.SelectedItem, textBox2.Text);

                    BindingSource mSource = new BindingSource();

                    foreach (AccountDTO mAccount in iBank.GetClientAccounts(mClientId))
                    {
                        mSource.Add(mAccount);
                    }

                    dataGridView1.DataSource = mSource;

                    dataGridView1.AutoGenerateColumns = true;

                    dataGridView1.Refresh();
                }
                else
                {
                    MessageBox.Show("Por favor, no deje campos en blanco o asegurese de haber elegido la opcion correcta");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato no valido");
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("El documento ingresado no corresponde a un cliente cargado en el sistema");
            }
        }
    }
}