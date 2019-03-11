﻿using System;
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
    public partial class Form1 : Form
    {

        private string[] palabraReservada = { "Año", "Mes", "Documento", "Path", "Nombre" };
        private string texto;
        private int contError = 0;
        private int columna = 1;
        private int fila = 1;
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
            //if (contError==0) {
                generarTreeView();
           // }
            mandarPalabra();
        }

        private void generarTreeView()
        {
         
            Tree_View tree = new Tree_View(texto);
            tree.Show();
        }
        private void mandarPalabra() {
            string nombre = "";
            foreach (string i in palabraReservada) {
                nombre = i;
                pintar(nombre);
            }
        }
        private void pintar(string palabra)
        {
            int inicio = 0;
            while (inicio <= idTexto.Text.LastIndexOf(palabra))
            {
                idTexto.Find(palabra, inicio, idTexto.TextLength, RichTextBoxFinds.None);
                idTexto.SelectionColor = Color.LightBlue;
                inicio = idTexto.Text.IndexOf(palabra, inicio) + 1;
            }
        }
        private void analizador(string texto) {
            string token = "";
            char letra;
            int estado = 0;
            int estadoMover = 0;
            for (estado=0;estado<texto.Length; estado++) {
                letra = texto[estado];
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
                                columna = 1;
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
                                token += letra;
                                estadoMover = 1;
                                estado = estado - 1;
                                break;
                            case ';':
                                token += letra;
                                estadoMover = 1;
                                estado = estado - 1;
                                break;
                            case '=':
                                token += letra;
                                estadoMover = 1;
                                estado = estado - 1;
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
                        analizarToken(token, fila, columna, "Simbolo");
                        columna++;
                        token = "";
                        estadoMover = 0;
                        break;
                    case 2:
                        analizarToken(token, fila, columna, "Digito");
                        columna++;
                        token = "";
                        estadoMover = 0;
                        break;
                    case 3:
                        if (Char.IsLetterOrDigit(letra))
                        {
                            token += letra;
                        }
                        else {
                            verificarReservadas(token, fila, columna);
                            columna++;
                            token = "";
                            estado = estado - 1;
                            estadoMover = 0;
                        }
                        break;
                    case 4:
                        if (Char.IsLetterOrDigit(letra) || Char.IsSymbol(letra) || letra == ' ' || letra == '_' || letra == ',')
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
                        analizarToken(token + "\"", fila, columna, "IDENTIFICADOR");
                        columna++;
                        token = "";
                        estadoMover = 0;
                        break;
                    case 8:
                        errores(token += letra, fila, columna);
                        columna++;
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
                if (token.Equals(nombre))
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
            int no = 0;
            errorToken.Add(new ErrorToken(no, token,"Elemento Lexico Desconocido",fila,columna));
            foreach (ErrorToken i in errorToken) {
                Console.WriteLine(i.Tokens);
            }
        }
        private void analizarToken(string token, int fila, int columna, string tipo) {
            listToken.Add(new Token(contToken,contToken,token,tipo,fila,columna));
            contToken++;
        }
  
        private void tablaSimbolosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaTokens lista = new ListaTokens(listToken);

            lista.Show();
        }
    }
}
