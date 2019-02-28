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
    public partial class Tree_View : Form
    {
        public Tree_View()
        {
            InitializeComponent();
            agregarDocumento();
        }

        private void agregarDocumento() {

            TreeNode tNode;
            tNode = idTreeView.Nodes.Add("2017");

            idTreeView.Nodes[0].Nodes.Add("Enero");
            idTreeView.Nodes[0].Nodes[0].Nodes.Add("Documento 1");

            idTreeView.Nodes[0].Nodes.Add("Febrero");
            idTreeView.Nodes[0].Nodes[1].Nodes.Add("Documento 2");
            idTreeView.Nodes[0].Nodes[1].Nodes.Add("Documento 3");

            idTreeView.Nodes[0].Nodes.Add("Marzo");
            //idTreeView.Nodes[0].Nodes[2].Nodes.Add("ADO.NET");
            idTreeView.Nodes[0].Nodes[2].Nodes.Add("Documento 4");

            TreeNode tNodes;
            tNodes = idTreeView.Nodes.Add("2018");
            idTreeView.Nodes[1].Nodes.Add("Enero");
            idTreeView.Nodes[1].Nodes[0].Nodes.Add("Documento 5");


        }

        private void idTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string texto = idTreeView.SelectedNode.Text;
            Console.WriteLine(texto);
            idTexto.Text = texto;

        }
    }
}
