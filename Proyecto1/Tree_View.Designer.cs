namespace Proyecto1
{
    partial class Tree_View
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
            this.IdExpresion = new System.Windows.Forms.TextBox();
            this.idBuscar = new System.Windows.Forms.Button();
            this.idTexto = new System.Windows.Forms.RichTextBox();
            this.idTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // IdExpresion
            // 
            this.IdExpresion.Location = new System.Drawing.Point(13, 28);
            this.IdExpresion.Name = "IdExpresion";
            this.IdExpresion.Size = new System.Drawing.Size(235, 20);
            this.IdExpresion.TabIndex = 1;
            // 
            // idBuscar
            // 
            this.idBuscar.Location = new System.Drawing.Point(254, 25);
            this.idBuscar.Name = "idBuscar";
            this.idBuscar.Size = new System.Drawing.Size(75, 23);
            this.idBuscar.TabIndex = 2;
            this.idBuscar.Text = "Buscar";
            this.idBuscar.UseVisualStyleBackColor = true;
            this.idBuscar.Click += new System.EventHandler(this.idBuscar_Click);
            // 
            // idTexto
            // 
            this.idTexto.Location = new System.Drawing.Point(254, 55);
            this.idTexto.Name = "idTexto";
            this.idTexto.Size = new System.Drawing.Size(718, 527);
            this.idTexto.TabIndex = 4;
            this.idTexto.Text = "";
            // 
            // idTreeView
            // 
            this.idTreeView.Location = new System.Drawing.Point(13, 55);
            this.idTreeView.Name = "idTreeView";
            this.idTreeView.Size = new System.Drawing.Size(235, 527);
            this.idTreeView.TabIndex = 5;
            this.idTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.idTreeView_AfterSelect);
            // 
            // Tree_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 619);
            this.Controls.Add(this.idTreeView);
            this.Controls.Add(this.idTexto);
            this.Controls.Add(this.idBuscar);
            this.Controls.Add(this.IdExpresion);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Tree_View";
            this.Text = "Tree_View";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox IdExpresion;
        private System.Windows.Forms.Button idBuscar;
        private System.Windows.Forms.RichTextBox idTexto;
        private System.Windows.Forms.TreeView idTreeView;
    }
}