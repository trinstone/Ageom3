namespace AgeomProj
{
    partial class frmSlobodanNivo
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnlSveska = new System.Windows.Forms.Panel();
            this.btnSveska = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(185, 36);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "aaa";
            // 
            // pnlSveska
            // 
            this.pnlSveska.Enabled = false;
            this.pnlSveska.Location = new System.Drawing.Point(460, 64);
            this.pnlSveska.Name = "pnlSveska";
            this.pnlSveska.Size = new System.Drawing.Size(200, 100);
            this.pnlSveska.TabIndex = 1;
            this.pnlSveska.Visible = false;
            this.pnlSveska.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSveska_Paint);
            this.pnlSveska.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlSveska_MouseDown);
            this.pnlSveska.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlSveska_MouseMove);
            this.pnlSveska.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlSveska_MouseUp);
            // 
            // btnSveska
            // 
            this.btnSveska.Location = new System.Drawing.Point(51, 53);
            this.btnSveska.Name = "btnSveska";
            this.btnSveska.Size = new System.Drawing.Size(75, 23);
            this.btnSveska.TabIndex = 2;
            this.btnSveska.Text = "SVESKA";
            this.btnSveska.UseVisualStyleBackColor = true;
            this.btnSveska.Click += new System.EventHandler(this.btnSveska_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(90, 437);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(75, 23);
            this.btnObrisi.TabIndex = 3;
            this.btnObrisi.Text = "OBRISI";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // frmSlobodanNivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnSveska);
            this.Controls.Add(this.pnlSveska);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSlobodanNivo";
            this.Text = "FormaSlobodanNivocs";
            this.Load += new System.EventHandler(this.frmSlobodanNivo_Load);
            this.SizeChanged += new System.EventHandler(this.frmSlobodanNivo_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSlobodanNivo_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel pnlSveska;
        private System.Windows.Forms.Button btnSveska;
        private System.Windows.Forms.Button btnObrisi;
    }
}