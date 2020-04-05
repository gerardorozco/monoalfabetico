using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonoalfabeticoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCifrar_Click(object sender, EventArgs e)
        {
            Cifrado cifrado = new Cifrado();
            cifrado.Clave = txtClave.Text;
            cifrado.Mensaje = txtMensaje.Text;
            lblResult.Text = cifrado.Cifrar();
        }

        private void btnDescifrar_Click(object sender, EventArgs e)
        {
            Cifrado cifrado = new Cifrado();
            cifrado.Clave = txtClave.Text;
            cifrado.Mensaje = txtMensaje.Text;
            lblResult.Text = cifrado.Descifrar();
        }
    }
}
