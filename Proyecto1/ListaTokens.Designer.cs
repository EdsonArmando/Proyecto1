namespace Proyecto1
{
    partial class ListaTokens
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
            this.idListView = new System.Windows.Forms.ListView();
            this.idNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.idToken = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.idLexema = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.idTipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.idFila = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.idColumna = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // idListView
            // 
            this.idListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idNo,
            this.idToken,
            this.idLexema,
            this.idTipo,
            this.idFila,
            this.idColumna});
            this.idListView.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idListView.Location = new System.Drawing.Point(12, 12);
            this.idListView.Name = "idListView";
            this.idListView.Size = new System.Drawing.Size(1037, 562);
            this.idListView.TabIndex = 0;
            this.idListView.UseCompatibleStateImageBehavior = false;
            this.idListView.View = System.Windows.Forms.View.Details;
            // 
            // idNo
            // 
            this.idNo.Text = "No. Token";
            this.idNo.Width = 195;
            // 
            // idToken
            // 
            this.idToken.Text = "ID Token";
            this.idToken.Width = 149;
            // 
            // idLexema
            // 
            this.idLexema.Text = "Lexema";
            this.idLexema.Width = 193;
            // 
            // idTipo
            // 
            this.idTipo.Text = "Tipo";
            this.idTipo.Width = 278;
            // 
            // idFila
            // 
            this.idFila.Text = "Fila";
            this.idFila.Width = 98;
            // 
            // idColumna
            // 
            this.idColumna.Text = "Columna";
            this.idColumna.Width = 116;
            // 
            // ListaTokens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 586);
            this.Controls.Add(this.idListView);
            this.Name = "ListaTokens";
            this.Text = "ListaTokens";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView idListView;
        private System.Windows.Forms.ColumnHeader idNo;
        private System.Windows.Forms.ColumnHeader idToken;
        private System.Windows.Forms.ColumnHeader idLexema;
        private System.Windows.Forms.ColumnHeader idTipo;
        private System.Windows.Forms.ColumnHeader idFila;
        private System.Windows.Forms.ColumnHeader idColumna;
    }
}