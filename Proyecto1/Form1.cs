using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    public partial class Form1 : Form
    {

        private string[] palabraReservada = { "año", "mes", "documento", "path", "nombre"};
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private string texto;
        private string path;
        private int contError = 0;
        private int contToken = 1;
        static ArrayList listToken = new ArrayList();
        static ArrayList errorToken = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void analizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            texto = idTexto.Text;
            analizador(texto);
            if (contError == 0)
            {
                generarTreeView();
            }
            else {
                MessageBox.Show("Hay errores lexicos");
            }
            
        }

        private void generarTreeView()
        {
         
            Tree_View tree = new Tree_View(texto);
            tree.Show();
        }
        private void mandarPalabra() {
            string nombre = "";
            string tipo = "";
            foreach (Token i in listToken) {
                nombre = i.Lexema;
                tipo = i.Tipo;
                pintar(nombre,tipo);
            }
        }
        private void analizador(string texto) {
            string token = "";
            int columna = 0;
            int fila = 1;
            string palabra = "";
            string tokenPunto = "";
            char letra;
            int contPalabra = 0;
            int estado = 0;
            int cantPunto = 0;
            int estadoMover = 0;
            for (estado=0;estado<texto.Length; estado++) {
                letra = texto[estado];
                if (cantPunto>0) {
                    if (letra != ':')
                    {
                        if (cantPunto == 1)
                        {
                            estadoMover = 1;
                            token = tokenPunto;
                            estado = estado - 1;
                            tokenPunto = "";
                            cantPunto = 0;
                        }
                        else if (letra == '=')
                        {
                            if (cantPunto == 2)
                            {
                                token = tokenPunto + letra;
                                estadoMover = 1;
                                estado = estado - 1;

                                cantPunto = 0;
                            }
                        }else if(cantPunto>=2)  
                        {
                            int i = 0;
                            columna++;
                            while (i<tokenPunto.Length) {
                                analizarToken(":", fila, columna++, "DOS PUNTOS");
                                i++;
                            }
                            columna = columna - 1;
                            tokenPunto = "";
                            token = "";
                            cantPunto = 0;
                        }
                    }
                }
               
                switch (estadoMover) {
                    case 0:
                        switch (letra) {
                            case ' ':
                            case '\r':
                            case '\t':
                            case '\f':
                                estadoMover = 0;
                                break;
                            case '\n':
                                fila++;
                                columna = 0;
                                estadoMover = 0;
                                break;
                            case '{':
                                token += letra;
                                estadoMover = 1;
                                estado = estado - 1;
                                break;
                            case '}':
                                token += letra;
                                estadoMover = 1;
                                estado = estado - 1;
                                break;
                            case ':':
                                tokenPunto += letra;
                                cantPunto++;
                                estadoMover = 0;
                                /* estadoMover = 1;
                                 estado = estado - 1;*/
                                break;
                            case ';':
                                token += letra;
                                estadoMover = 1;
                                estado = estado - 1;
                                break;
                            case '=':
                                if (tokenPunto.Equals("::"))
                                {
                                    tokenPunto = "";
                                }
                                else {
                                    estadoMover = 8;
                                    estado = estado - 1;
                                }
                                break;
                            case '"':
                                token += letra;
                                estadoMover = 4;
                                break;
                            default:
                                if (Char.IsNumber(letra))
                                {
                                    token += letra;
                                    estadoMover = 2;
                                    estado = estado - 1;
                                }
                                else if (Char.IsLetter(letra))
                                {
                                    estadoMover = 3;
                                    estado = estado - 1;
                                }
                                else
                                {
                                    estadoMover = 8;
                                    estado = estado - 1;
                                }
                                break;
                        }
                        break;
                    case 1:
                        if (palabra.ToLower().Equals("nombre")) {
                            contPalabra = 1;
                        } else if (palabra.ToLower().Equals("mes")) {
                            contPalabra = 3;
                        }
                        if (token.Equals("{")) {
                            columna++;
                            analizarToken(token, fila, columna, "CORCHETE APERTURA");
                            token = "";
                            estadoMover = 0;
                        } else if (token.Equals("}")) {
                            columna++;
                            analizarToken(token, fila, columna, "CORCHETE CIERRE");
                            token = "";
                            estadoMover = 0;
                        }
                        else if (token.Equals(":"))
                        {
                            columna++;
                            analizarToken(token, fila, columna, "DOS PUNTOS");
                            token = "";
                            estadoMover = 0;
                        }
                        else if (token.Equals("::="))
                        {
                            columna++;
                            analizarToken(token, fila, columna, "SIGNO ASIGNACION");
                            token = "";
                            estadoMover = 0;
                        }
                        else if (token.Equals(";"))
                        {
                            columna++;
                            analizarToken(token, fila, columna, "PUNTO Y COMA");
                            token = "";
                            estadoMover = 0;
                        }

                        break;
                    case 2:
                        columna++;
                        analizarToken(token, fila, columna, "DIGITO");
                        token = "";
                        estadoMover = 0;
                        break;
                    case 3:
                        if (Char.IsLetterOrDigit(letra) || Char.IsSymbol(letra) || letra == ' ' || letra == '_' || letra == ',')
                        {
                            token += letra;
                            columna++;
                        }
                        else {
                            if (token.ToLower().Equals("nombre"))
                            {
                                palabra = token;

                            } else if (token.ToLower().Equals("mes")) {
                                palabra = token;
                            }
                            if (contPalabra == 0) {
                                verificarReservadas(token, fila, columna);
                                token = "";
                                estado = estado - 1;
                                estadoMover = 0;
                            } else if (contPalabra == 1) {
                                estadoMover = 5;
                            }
                            else if (contPalabra == 3)
                            {
                                estado = estado - 1;
                                estadoMover = 5;
                                palabra = "";
                            }

                        }
                        break;
                    case 4:
                        if (Char.IsLetterOrDigit(letra) || Char.IsSymbol(letra) || letra == ' ' || letra == '_' || letra == ',' || letra == '/' || letra == '.' || letra == ':')
                        {
                            token += letra;
                        }
                        else if (letra == '"')
                        {
                            estado = estado - 1;
                            estadoMover = 5;
                        }
                        break;
                    case 5:
                        if (contPalabra == 0) {
                            columna++;
                            analizarToken(token + "\"", fila, columna, "CADENA");
                            token = "";
                            estadoMover = 0;
                        } else if (contPalabra == 1) {
                            analizarToken(token, fila, columna, "IDENTIFICADOR");
                            token = "";
                            palabra = "";
                            estado = estado - 2;
                            estadoMover = 0;
                            contPalabra = 0;
                        }
                        else if (contPalabra == 3)
                        {
                            analizarToken(token, fila, columna, "IDENTIFICADOR");
                            token = "";
                            palabra = "";
                            estado = estado - 1;
                            estadoMover = 0;
                            contPalabra = 0;
                        }
                        break;
                    case 8:
                        columna++;
                        errores(token += letra, fila, columna);   
                        contError++;
                        token = "";
                        estadoMover = 0;
                        break;
                }
            }
        }
        private void verificarReservadas(string token, int fila, int columna)
        {
            string nombre = "";
            bool uno = false;
            for (int i = 0; i < palabraReservada.Length; i++)
            {
                nombre = palabraReservada[i];
                if (token.ToLower().Equals(nombre))
                {
                    i = palabraReservada.Length + 1;
                    uno = true;
                }
            }
            if (uno == true)
            {
                analizarToken(token, fila, columna,"RESERVADA");
            }
            else if (uno == false)
            {
                errores(token, fila, columna);
            }
        }
        private void errores(string token, int fila, int columna) {
            int no = 1;
            errorToken.Add(new ErrorToken(no, token,"Elemento Lexico Desconocido",fila,columna));
            no++;
        }
        private void analizarToken(string token, int fila, int columna, string tipo) {
            listToken.Add(new Token(contToken,contToken,token,tipo,fila,columna));
            contToken++;
        }
        private void pintar(string palabra, string tipo)
            {

            int inicio = 0;          
                while (inicio < idTexto.Text.LastIndexOf("Documento"))
                {
                    idTexto.Find("Documento", inicio, idTexto.TextLength, RichTextBoxFinds.None);
                    idTexto.SelectionColor = Color.Green;
                    inicio = idTexto.Text.IndexOf("Documento", inicio) + 1;
                }
            
        }
        private void tablaSimbolosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaTokens lista = new ListaTokens(listToken);

            lista.Show();
        }

        private void tablaErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaError lista = new ListaError(errorToken);
            lista.Show();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "ddc files (*.ddc)|*.ddc|All files (*.*)|*.*";
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                String texto = File.ReadAllText(path);
                idTexto.Text = "\t" + texto;
                //Console.WriteLine(path);
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();

            saveFileDialog1.Filter = "ddc files (*.ddc)|*.ddc|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string name = saveFileDialog1.FileName;
                saveFileDialog1.InitialDirectory = @"c:\temp\";
                File.WriteAllText(saveFileDialog1.FileName, idTexto.Text);
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter archivo = new StreamWriter(path);
            archivo.Write(idTexto.Text);
            archivo.Close();
            MessageBox.Show("Se ha guardado satisfactoriamente");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
