using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    public partial class Tree_View : Form
    {
        private ArrayList ubicacionDoc = new ArrayList();
        private List<int> ubiPala = new List<int>();
        TextBox textBox1 = new TextBox();
        public Tree_View(string cadena)
        {
            InitializeComponent();
            agregarDocumento(cadena);
        }

        private void agregarDocumento(string cadena) {
            char cadenas;
            string palabra = "";
            TreeNode tNode;
            int opcion = 0;
            int j = 0;
            int coMes = 0;
            int pos = 0;
            int contAnio = 0;
            string anio = "", mes = "", path = "", nombre = "", paths = "C:";
            for (j = 0; j < cadena.Length; j++) {
                cadenas = cadena[j];
                palabra += cadenas;
                if (palabra.Equals("\n") || palabra.Equals(";") || palabra.Equals("=") || palabra.ToLower().Equals("documento{") || palabra.Equals("}") || palabra.Equals(":") || palabra.Equals("\r") || palabra.Equals("\t") || palabra.Equals("\f") || palabra.Equals(" "))
                {
                    palabra = "";

                } else if (palabra.Equals("Path")) {
                    palabra = "";
                }
                switch (opcion) {
                    case 0:
                        switch (palabra.ToLower()) {
                            case " ":
                            case "\r":
                            case "\t":
                            case "\f":
                            case "\n":
                            case ":":
                            case "=":
                            case "}":
                                opcion = 0;
                                break;
                            case "año":
                                palabra = "";
                                opcion = 1;
                                break;
                            case "mes":
                                palabra = "";
                                opcion = 2;
                                break;
                            case "\"c:":
                                palabra = "";
                                opcion = 3;
                                break;
                            case "nombre":
                                palabra = "";
                                opcion = 4;
                                break;
                            default:

                                break;
                        }
                        break;
                    case 1:
                        if (Char.IsDigit(cadenas)) {
                            anio += cadenas;
                            opcion = 1;
                        } else if (cadenas == '{') {
                            opcion = 0;
                            palabra = "";
                            tNode = idTreeView.Nodes.Add(anio);
                            anio = "";
                            contAnio++;
                            if (contAnio >= 2) {
                                pos++;
                                coMes = 0;
                            }
                            //Console.WriteLine(anio);
                        }
                        break;
                    case 2:
                        if (Char.IsLetter(cadenas))
                        {
                            mes += cadenas;
                            opcion = 2;
                        }
                        else if (cadenas == '{')
                        {
                            opcion = 0;
                            palabra = "";

                            idTreeView.Nodes[pos].Nodes.Add(mes);
                            mes = "";
                            coMes++;
                            //Console.WriteLine(mes);
                        }
                        break;
                    case 3:
                        if (Char.IsLetter(cadenas) || cadenas == '/' || cadenas == '.' || Char.IsDigit(cadenas))
                        {
                            path += cadenas;
                            opcion = 3;
                        }
                        else if (cadenas == ';')
                        {
                            opcion = 0;
                            palabra = "";
                            path = paths + path;
                        }
                        break;
                    case 4:
                        if (Char.IsLetter(cadenas) || Char.IsDigit(cadenas) || cadenas == '_')
                        {
                            nombre += cadenas;
                            opcion = 4;
                        }
                        else if (cadenas == ';')
                        {
                            opcion = 0;
                            palabra = "";
                            if (coMes == 1) {
                                idTreeView.Nodes[pos].Nodes[0].Nodes.Add(nombre);
                                ubicacionDoc.Add(new Path(nombre, path));
                                nombre = "";
                                //Console.WriteLine(pos + " "+ 0);
                                path = "";
                            } else if (coMes > 0) {
                                idTreeView.Nodes[pos].Nodes[coMes - 1].Nodes.Add(nombre);
                                ubicacionDoc.Add(new Path(nombre, path));
                                //Console.WriteLine(pos + " " + (coMes - 1));
                                nombre = "";
                                //Console.WriteLine("-------------");
                                path = "";
                            }
                        }
                        break;
                }
            }
            /*for (int i=0;i<2;i++) { 

                  tNode = idTreeView.Nodes.Add("201"+i);
                  idTreeView.Nodes[i].Nodes.Add("Enero");
                  idTreeView.Nodes[i].Nodes[0].Nodes.Add("Documento"+i);
            }*/

        }

        private void idTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            idTexto.Text = "";
            string nombreDoc = idTreeView.SelectedNode.Text;
            string path = "";
            string texto = "";
            foreach (Path p in ubicacionDoc)
            {
                if (nombreDoc.Equals(p.Nombre)) {
                    path = p.Url;
                }
            }
            try {

                try {
                    try {
                        texto = File.ReadAllText(path);
                        idTexto.Text = texto;
                    }
                    catch (System.IO.FileNotFoundException ed) {
                        MessageBox.Show("Path erronea");
                    }
                 
                }
                catch (System.IO.DirectoryNotFoundException ef) {
                    MessageBox.Show("Path erronea");
                }
            }
            catch (System.ArgumentException ex) {

            }
        }

        private void idBuscar_Click(object sender, EventArgs e)
        {
            int i;
            char conca;
            string palabra = "";
            int opc = 0;
            for ( i = 0; i < idTexto.Text.Length; i++) {
                conca = idTexto.Text[i];
                switch (opc) {
                    case 0:
                        switch (conca) {
                            case ' ':
                            case '\r':
                            case '\t':
                            case '\f':
                            case '\n':
                                analizarPalabra(palabra);
                                palabra = "";
                                break;
                            default:
                                opc = 1;
                                i = i - 1;
                                break;
                        }
                        break;
                    case 1:
                        if (conca == ' ' || conca == '\n')
                        {
                            opc = 0;
                            i = i - 1;
                        }
                        else {
                            palabra += conca;
                            opc = 1;
                        }
                        break;
                }
            }

        }
        private void analizarPalabra(string palabra) {
            string exp = IdExpresion.Text;
            Regex rx;
            rx = new Regex(exp);
            bool isMatch = false;
            isMatch = rx.IsMatch(palabra);
            if (isMatch == true)
            {
                this.textBox1.Text = palabra;
                pintar(palabra);
            }
            else if (isMatch == false)
            {
            }

        }
        private void pintar(string palabra)
        {
        int inicio = 0;
            while (inicio <= idTexto.Text.LastIndexOf(palabra))
            {
                idTexto.Find(palabra, inicio, idTexto.TextLength, RichTextBoxFinds.None);
                idTexto.SelectionColor = Color.Blue;
                inicio = idTexto.Text.IndexOf(palabra, inicio) + 1;
            }
        }

    }
}
