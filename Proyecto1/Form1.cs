using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    public partial class Form1 : Form
    {
        private string texto;
        private int contError = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void analizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            texto = idTexto.Text;
            if (contError==0) {
                generarTreeView();
            }
        }

        private void generarTreeView()
        {
         
            Tree_View tree = new Tree_View(texto);
            tree.Show();
        }
    }
}
