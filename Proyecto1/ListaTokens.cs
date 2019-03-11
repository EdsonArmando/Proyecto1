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
    public partial class ListaTokens : Form
    {
        private string[] datos = new string[5];
        public ListaTokens(ArrayList list)
        {
            InitializeComponent();
            idListView.View = View.Details;
            idListView.GridLines = true;
            idListView.FullRowSelect = true;
            //Add items in the listview
            string[] datos = new string[6];
            ListViewItem itm;

            //Add first item
            foreach (Token i in list) {
                datos[0] = Convert.ToString(i.No);
                datos[1] = Convert.ToString(i.Tokens);
                datos[2] = i.Lexema;
                datos[3] = i.Tipo;
                datos[4] = Convert.ToString(i.Fila);
                datos[5] = Convert.ToString(i.Columna);
                itm = new ListViewItem(datos);
                idListView.Items.Add(itm);
            }  
        }
    }
}
