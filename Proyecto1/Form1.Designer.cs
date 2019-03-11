namespace Proyecto1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idTexto = new System.Windows.Forms.RichTextBox();
            this.tablaSimbolosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.analizarToolStripMenuItem,
            this.acercaToolStripMenuItem,
            this.tablaSimbolosToolStripMenuItem,
            this.tablaErroresToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.abrirToolStripMenuItem.Text = "Abrir";
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.guardarToolStripMenuItem.Text = "Guardar";
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.guardarComoToolStripMenuItem.Text = "Guardar Como";
            // 
            // analizarToolStripMenuItem
            // 
            this.analizarToolStripMenuItem.Name = "analizarToolStripMenuItem";
            this.analizarToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.analizarToolStripMenuItem.Text = "Analizar";
            this.analizarToolStripMenuItem.Click += new System.EventHandler(this.analizarToolStripMenuItem_Click);
            // 
            // acercaToolStripMenuItem
            // 
            this.acercaToolStripMenuItem.Name = "acercaToolStripMenuItem";
            this.acercaToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.acercaToolStripMenuItem.Text = "Acerca De";
            // 
            // idTexto
            // 
            this.idTexto.Location = new System.Drawing.Point(13, 28);
            this.idTexto.Name = "idTexto";
            this.idTexto.Size = new System.Drawing.Size(560, 410);
            this.idTexto.TabIndex = 1;
            this.idTexto.Text = "";
            // 
            // tablaSimbolosToolStripMenuItem
            // 
            this.tablaSimbolosToolStripMenuItem.Name = "tablaSimbolosToolStripMenuItem";
            this.tablaSimbolosToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.tablaSimbolosToolStripMenuItem.Text = "Tabla Simbolos";
            this.tablaSimbolosToolStripMenuItem.Click += new System.EventHandler(this.tablaSimbolosToolStripMenuItem_Click);
            // 
            // tablaErroresToolStripMenuItem
            // 
            this.tablaErroresToolStripMenuItem.Name = "tablaErroresToolStripMenuItem";
            this.tablaErroresToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.tablaErroresToolStripMenuItem.Text = "Tabla Errores";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.idTexto);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaToolStripMenuItem;
        private System.Windows.Forms.RichTextBox idTexto;
        private System.Windows.Forms.ToolStripMenuItem tablaSimbolosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablaErroresToolStripMenuItem;
    }
}

