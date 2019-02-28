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
        public Tree_View(string cadena)
        {
            InitializeComponent();
            agregarDocumento(cadena);
        }

        private void agregarDocumento(string cadena){
            char cadenas;
            string palabra="";
            TreeNode tNode;
            int opcion = 0;
            int j = 0;
            int coMes = 0;
            int pos =0;
            int contAnio = 0;
            string anio = "", mes = "", path = "", nombre = "",paths="C:";
            // TreeNode tNode;
            /*tNode = idTreeView.Nodes.Add("2017");

            idTreeView.Nodes[0].Nodes.Add("Enero");
            idTreeView.Nodes[0].Nodes[0].Nodes.Add("Documento 1");

            idTreeView.Nodes[0].Nodes.Add("Febrero");
            idTreeView.Nodes[0].Nodes[1].Nodes.Add("Documento 2");
            idTreeView.Nodes[0].Nodes[1].Nodes.Add("Documento 3");
            pala
            idTreeView.Nodes[0].Nodes.Add("Marzo");
            idTreeView.Nodes[0].Nodes[2].Nodes.Add("Documento 4");*/

            // TreeNode tNodes;
            /* tNodes = idTreeView.Nodes.Add("2018");
             idTreeView.Nodes[1].Nodes.Add("Enero");
             idTreeView.Nodes[1].Nodes[0].Nodes.Add("Documento 5");*/

            for ( j=0;j<cadena.Length;j++) {
                cadenas = cadena[j];
                palabra += cadenas;
                if (palabra.Equals("\n") || palabra.Equals(";") || palabra.Equals("=") || palabra.Equals("Documento{") || palabra.Equals("}") || palabra.Equals(":") || palabra.Equals("\r") || palabra.Equals("\t") || palabra.Equals("\f") || palabra.Equals(" "))
                {
                    palabra = "";

                } else if (palabra.Equals("Path")) {
                    palabra = "";
                }
                switch (opcion) {
                    case 0:
                        switch (palabra) {
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
                            case "Año":
                                palabra = "";
                                opcion = 1;
                                break;
                            case "Mes":
                                palabra = "";
                                opcion = 2;
                                break;
                            case "\"C:":
                                palabra = "";
                                opcion = 3;
                                break;
                            case "Nombre":
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
                        } else if (cadenas=='{') {
                            opcion = 0;
                            palabra = "";
                            tNode = idTreeView.Nodes.Add(anio);
                            anio = "";
                        
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
                        if (Char.IsLetter(cadenas)|| cadenas=='/'||cadenas=='.' || Char.IsDigit(cadenas))
                        {
                            path += cadenas;
                            opcion = 3;
                        }
                        else if (cadenas == ';')
                        {
                            opcion = 0;
                            palabra = "";
                            path = paths + path;
                            Console.WriteLine(path);
                        }
                        break;
                    case 4:
                        if (Char.IsLetter(cadenas) || Char.IsDigit(cadenas)|| cadenas=='_')
                        {
                            nombre += cadenas;
                            opcion = 4;
                        }
                        else if (cadenas == ';')
                        {
                            opcion = 0;
                            palabra = "";
                            if (coMes == 1) {
                                idTreeView.Nodes[pos].Nodes[pos].Nodes.Add(nombre);
                                nombre = "";
                            } else if (coMes>0) {
                                idTreeView.Nodes[pos].Nodes[coMes-1].Nodes.Add(nombre);
                                nombre = "";
                           
                            }
                        }
                        break;
                }
            }
            /*for (int i=0;i<5;i++) { 

                  tNode = idTreeView.Nodes.Add("201"+i);
                  idTreeView.Nodes[i].Nodes.Add("Enero");
                  idTreeView.Nodes[i].Nodes.Add("Febrero");
                  idTreeView.Nodes[i].Nodes[0].Nodes.Add("Documento"+i);
                idTreeView.Nodes[i].Nodes[1].Nodes.Add("Documento" + i);
            }*/

        }

        private void idTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string texto = idTreeView.SelectedNode.Text;
            Console.WriteLine(texto);
            idTexto.Text = texto;

        }
    }
}
