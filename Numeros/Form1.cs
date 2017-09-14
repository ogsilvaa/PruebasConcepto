using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Humanizer;
using Numeros.Properties;

namespace Numeros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            int numero;
            if (int.TryParse(txtNumero.Text, out numero))
            {
                lblOrdinal.Text = $"{numero.Ordinalize()}: {numero.ToOrdinalWords()}";
                lblTexto.Text = numero.ToWords();
                lblRomano.Text = numero > 0 ? (numero<3999?numero.ToRoman():Resources.Mayor) : Resources.Cero;
            }
            else
            {
                lblOrdinal.Text = string.Empty;
                lblTexto.Text = string.Empty;
                lblRomano.Text = string.Empty;
            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
