using System;
using System.Collections;
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
    public partial class ListaError : Form
    {
        private string[] datos = new string[5];
        public ListaError(ArrayList list)
        {
            InitializeComponent();
            idListView.View = View.Details;
            idListView.GridLines = true;
            idListView.FullRowSelect = true;
            //Add items in the listview
            string[] datos = new string[5];
            ListViewItem itm;

            //Add first item
            foreach (ErrorToken i in list)
            {
                datos[0] = Convert.ToString(i.No);
                datos[1] = i.Tokens;
                datos[2] = i.Lexema;
                datos[3] = Convert.ToString(i.Fila);
                datos[4] = Convert.ToString(i.Columna);
                itm = new ListViewItem(datos);
                idListView.Items.Add(itm);
            }
        }
    }
}
