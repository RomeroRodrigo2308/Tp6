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
    public partial class ObtenerCuentasEnRojo : Form
    {
        Bank iBank;

        public ObtenerCuentasEnRojo()
        {
            iBank = new Bank();

            InitializeComponent();
        }

        private void ObtenerCuentasEnRojo_Load(object sender, EventArgs e)
        {
            BindingSource mSource = new BindingSource();

            foreach (AccountDTO mAccount in iBank.GetOverdrawnAccounts())
            {
                mSource.Add(mAccount);
            }

            dataGridView1.DataSource = mSource;

            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.Refresh();
        }
    }
}
