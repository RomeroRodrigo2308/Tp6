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
    public partial class AgregarCuenta : Form
    {
        Bank iBank;
        public AgregarCuenta()
        {
            iBank = new Bank();
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(DocumentType));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != "" && textBox4.Text != "")
                {
                    if (radioButton1.Checked && textBox1.Text != "")
                    {
                        int mId = iBank.AperturaCuenta(Convert.ToInt32(textBox1.Text), textBox3.Text, Convert.ToDouble(textBox4.Text));
                        MessageBox.Show("Se ha abierto la cuenta con exito, el id es: " + mId.ToString());
                        Close();
                    }
                    else if (radioButton2.Checked && textBox2.Text != "")
                    {
                        try
                        {
                            int mClientId = iBank.GetClientId((DocumentType)comboBox1.SelectedItem, textBox2.Text);
                            int mId = iBank.AperturaCuenta(mClientId, textBox3.Text, Convert.ToDouble(textBox4.Text));
                            MessageBox.Show("Se ha abierto la cuenta con exito, el id es: " + mId.ToString());
                            Close();
                        }
                        catch (System.InvalidOperationException)
                        {
                            MessageBox.Show("El documento ingresado no corresponde a un cliente cargado en el sistema");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Revise los campos dentro del recuadro Cliente, la opcion seleccionada no debe tener campos en blanco");
                    }
                }
                else
                {
                    MessageBox.Show("No debe dejar los campos Nombre y Limite de Descubierto en blanco");
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("El formato de los datos ingresados no es correcto, por favor revise los campos");
            }
        }
    }
}
