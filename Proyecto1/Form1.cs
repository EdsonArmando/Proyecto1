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
    public partial class Form1 : Form
    {

        private string[] palabraReservada = { "año", "mes", "documento", "path", "nombre"};
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private string texto;
        private string path;
        private int contError = 0;
        private int contToken = 1;
        int no = 1;
        static ArrayList listToken = new ArrayList();
        static ArrayList errorToken = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void analizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idTexto.SelectionColor = Color.Black;
            listToken.Clear();
            errorToken.Clear();
            contError = 0;
            contToken = 1;
            no = 1;
            texto = idTexto.Text;
            analizador(texto);
            if (contError == 0)
            {
                generarTreeView();
                mandarPalabra();

            }
            else {
                MessageBox.Show("Hay errores lexicos");
                mandarPalabra();
                mandarPalabraError();
            }
        }

        private void generarTreeView()
        {
         
            Tree_View tree = new Tree_View(texto);
            tree.Show();
        }
        private void mandarPalabra() {
            string nombre = "";
            string comparar = "";
            string tipo = "";
            int pos = 0;
            foreach (Token i in listToken) {
                nombre = i.Lexema;
                tipo = i.Tipo;
                pos = i.Pos;
                FindMyText(nombre,tipo,pos);
                comparar = nombre;

            }
        }
        private void mandarPalabraError()
        {
            string nombre = "";
            int fila = 0;
            int pos = 0;
            foreach (ErrorToken i in errorToken)
            {
                nombre = i.Tokens;
                fila = i.Fila;
                pos = i.Pos;
                pintar2(nombre,pos);
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
                                palabra = token;
                                cantPunto = 0;
                            }
                        }else if(cantPunto>=2)  
                        {
                            int i = 0;
                            columna++;
                            while (i<tokenPunto.Length) {
                                analizarToken(":", fila, columna++, "DOS PUNTOS",estado);
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
                        if (palabra.Equals("::=")) {
                            contPalabra = 1;
                        } else if (palabra.ToLower().Equals("mes")) {
                            contPalabra = 3;
                        }
                        if (token.Equals("{")) {
                            columna++;
                            analizarToken(token, fila, columna, "CORCHETE APERTURA",estado);
                            token = "";
                            estadoMover = 0;
                        } else if (token.Equals("}")) {
                            columna++;
                            analizarToken(token, fila, columna, "CORCHETE CIERRE", estado);
                            token = "";
                            estadoMover = 0;
                        }
                        else if (token.Equals(":"))
                        {
                            columna++;
                            analizarToken(token, fila, columna, "DOS PUNTOS", estado);
                            token = "";
                            estadoMover = 0;
                        }
                        else if (token.Equals("::="))
                        {
                            columna++;
                            analizarToken(token, fila, columna, "SIGNO ASIGNACION", estado);
                            token = "";
                            estadoMover = 0;
                        }
                        else if (token.Equals(";"))
                        {
                            columna++;
                            analizarToken(token, fila, columna, "PUNTO Y COMA", estado);
                            token = "";
                            estadoMover = 0;
                            contPalabra = 0;
                        }

                        break;
                    case 2:
                        columna++;
                        analizarToken(token, fila, columna, "DIGITO", estado);
                        token = "";
                        estadoMover = 0;
                        break;
                    case 3:
                        if (Char.IsLetterOrDigit(letra) || Char.IsSymbol(letra) || letra == ' ' || letra == '_' || letra == ',' || letra == '"')
                        {
                            token += letra;
                            columna++;
                        }
                        else {
                            if (token.ToLower().Equals("mes"))
                            {
                                palabra = token;
                            }else if (token.ToLower().Equals("nombre"))
                            {
                                palabra = token;
                            }
                            if (contPalabra == 0) {
                            verificarReservadas(token, fila, columna,estado);
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
                        if (letra !='"')
                        {
                            token += letra;
                        }
                        else if (letra == '"')
                        {
                            estado = estado - 1;
                            contPalabra = 0;
                            estadoMover = 5;
                        }
                        break;
                    case 5:
                        if (contPalabra == 0) {
                            columna++;
                            analizarToken(token + "\"", fila, columna, "CADENA", estado);
                            token = "";
                            contPalabra = 0;
                            estadoMover = 0;
                        } else if (contPalabra == 1) {
                            analizarToken(token, fila, columna, "IDENTIFICADOR", estado);
                            token = "";
                            palabra = "";
                            estado = estado - 2;
                            estadoMover = 0;
                            contPalabra = 0;
                        }
                        else if (contPalabra == 3)
                        {
                            analizarToken(token, fila, columna, "IDENTIFICADOR", estado);
                            token = "";
                            palabra = "";
                            estado = estado - 1;
                            estadoMover = 0;
                            contPalabra = 0;
                        }
                        break;
                    case 8:
                        columna++;
                        errores(token += letra, fila, columna,estado);   
                        contError++;
                        token = "";
                        estadoMover = 0;
                        break;
                }
            }
        }
        private void verificarReservadas(string token, int fila, int columna,int inicio)
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
                analizarToken(token, fila, columna, "RESERVADA",inicio);
            }
            else if (uno == false)
            {
                errores(token, fila, columna,inicio);
            }
        }
        private void errores(string token, int fila, int columna,int pos) {
         
            errorToken.Add(new ErrorToken(no, token,"Elemento Lexico Desconocido",fila,columna,pos));
            no++;
            contError++;
   
        }
        private void analizarToken(string token, int fila, int columna, string tipo,int pos) {
            if (tipo.Equals("RESERVADA")) {
                listToken.Add(new Token(contToken, 10, token, tipo, fila, columna,pos));
                contToken++;
            }else if (tipo.Equals("DIGITO"))
            {
                listToken.Add(new Token(contToken, 20, token, tipo, fila, columna,pos));
                contToken++;
            }
            else if (tipo.Equals("CADENA"))
            {
                listToken.Add(new Token(contToken, 30, token, tipo, fila, columna,pos));
                contToken++;
            }
            else if (tipo.Equals("IDENTIFICADOR"))
            {
                listToken.Add(new Token(contToken, 40, token, tipo, fila, columna,pos));
                contToken++;
            }
            else if (tipo.Equals("DOS PUNTOS"))
            {
                listToken.Add(new Token(contToken, 50, token, tipo, fila, columna,pos));
                contToken++;
            }
            else if (tipo.Equals("PUNTO Y COMA"))
            {
                listToken.Add(new Token(contToken, 60, token, tipo, fila, columna,pos));
                contToken++;
            }
            else if (tipo.Equals("CORCHETE APERTURA"))
            {
                listToken.Add(new Token(contToken, 70, token, tipo, fila, columna,pos));
                contToken++;
            }
            else if (tipo.Equals("CORCHETE CIERRE"))
            {
                listToken.Add(new Token(contToken, 80, token, tipo, fila, columna,pos));
                contToken++;
            }
            else if (tipo.Equals("SIGNO ASIGNACION"))
            {
                listToken.Add(new Token(contToken, 90, token, tipo, fila, columna,pos));
                contToken++;
            }
        }
        private void pintar(string palabra)
            {

            int inicio = 0;          
                while (inicio < idTexto.Text.LastIndexOf(palabra))
                {
                    idTexto.Find(palabra, inicio, idTexto.TextLength, RichTextBoxFinds.MatchCase);
                    idTexto.SelectionColor = Color.Black;
                    inicio = idTexto.Text.IndexOf(palabra, inicio) + 1;
                }
            
        }
        public void pintar2(string text,int pos)
        {
            if (pos ==1)
            {
                if (text.Length > 0 && pos >= 0)
                {
                    if ((pos + 10) > pos || pos == -1)
                    {
                        int indexToText = idTexto.Find(text, pos, pos + 20, RichTextBoxFinds.None);
                        idTexto.SelectionColor = Color.Black;
                    }
                }
            }
            else if(pos>10){
                if (text.Length > 0 && pos >= 0)
                {
                    if ((pos + 10) > pos || pos == -1)
                    {
                        int indexToText = idTexto.Find(text, pos - 10, pos + 20, RichTextBoxFinds.None);
                        idTexto.SelectionColor = Color.Black;
                    }
                }
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
            file.Filter = "ls files (*.ls)|*.ls|All files (*.*)|*.*";
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                String texto = File.ReadAllText(path);
                idTexto.Text = "\t" + texto;
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();

            saveFileDialog1.Filter = "ls files (*.ls)|*.ls|All files (*.*)|*.*";
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
        public bool FindMyText(string text, string tipo,int pos)
        {
            pos = pos - 5;
            bool returnValue = false;
            if (tipo.Equals("RESERVADA")) {
                if (text.Length > 0)
                {
                    int num = Math.Min(idTexto.SelectionStart + 1, idTexto.TextLength);
                    int indexToText = idTexto.Find(text, num, RichTextBoxFinds.MatchCase);
                    idTexto.SelectionColor = Color.LightBlue;
                    if (indexToText >= 0)
                    {
                        returnValue = true;
                    }
                }
            } else if (tipo.Equals("IDENTIFICADOR")) {
                if (text.Length > 0)
                {
                    int num = Math.Min(idTexto.SelectionStart + 1, idTexto.TextLength);
                    int indexToText = idTexto.Find(text, num, RichTextBoxFinds.MatchCase);
                    idTexto.SelectionColor = Color.Orange;
                    if (indexToText >= 0)
                    {
                        returnValue = true;
                    }
                }
            }
            else if (tipo.Equals("CADENA"))
            {
                if (text.Length > 0)
                {
                    int num = Math.Min(idTexto.SelectionStart + 1, idTexto.TextLength);
                    int indexToText = idTexto.Find(text, num, RichTextBoxFinds.MatchCase);
                    idTexto.SelectionColor = Color.Green;
                    if (indexToText >= 0)
                    {
                        returnValue = true;
                    }
                }
            }
            else if (tipo.Equals("DIGITO"))
            {
                if (text.Length > 0)
                {
                    int num = Math.Min(idTexto.SelectionStart + 1, idTexto.TextLength);
                    int indexToText = idTexto.Find(text, num, RichTextBoxFinds.MatchCase);
                    idTexto.SelectionColor = Color.Yellow;
                    if (indexToText >= 0)
                    {
                        returnValue = true;
                    }
                }
            }
            else if (tipo.Equals("DOS PUNTOS"))
            {
                if (text.Length > 0)
                {
                    int num = Math.Min(idTexto.SelectionStart + 1, idTexto.TextLength);
                    int indexToText = idTexto.Find(text, num, RichTextBoxFinds.MatchCase);
                    idTexto.SelectionColor = Color.Pink;
                    if (indexToText >= 0)
                    {
                        returnValue = true;
                    }
                }
            }
            else if (tipo.Equals("PUNTO Y COMA"))
            {
                if (text.Length > 0)
                {
                    int num = Math.Min(idTexto.SelectionStart + 1, idTexto.TextLength);
                    int indexToText = idTexto.Find(text, num, RichTextBoxFinds.MatchCase);
                    idTexto.SelectionColor = Color.Red;
                    if (indexToText >= 0)
                    {
                        returnValue = true;
                    }
                }
            }
            else if (tipo.Equals("SIGNO ASIGNACION"))
            {
                if (text.Length > 0 && pos >= 0)
                {
                    if ((pos+10) > pos || pos == -1)
                    {
                        int indexToText = idTexto.Find(text, pos, pos+10, RichTextBoxFinds.MatchCase);
                        idTexto.SelectionColor = Color.Blue;
                    }
                }
            }
            else if (tipo.Equals("CORCHETE APERTURA")|| tipo.Equals("CORCHETE CIERRE"))
            {
                if (text.Length > 0)
                {
                    int num = Math.Min(idTexto.SelectionStart + 1, idTexto.TextLength);
                    int indexToText = idTexto.Find(text, num, RichTextBoxFinds.MatchCase);
                    idTexto.SelectionColor = Color.Purple;
                    if (indexToText >= 0)
                    {
                        returnValue = true;
                    }
                }
            }
          
            return returnValue;
        }

    }

}
