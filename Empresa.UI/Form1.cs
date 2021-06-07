using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using empresa_models;

namespace Empresa.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new ClientesForms();
            f.ShowDialog();
        }
    }
}
