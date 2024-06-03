namespace AgeomProj
{
    partial class frmKvizNivo
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
            this.components = new System.ComponentModel.Container();
            this.lblPitanje = new System.Windows.Forms.Label();
            this.lblOdg4 = new System.Windows.Forms.Label();
            this.lblOdg3 = new System.Windows.Forms.Label();
            this.lblOdg2 = new System.Windows.Forms.Label();
            this.lblOdg1 = new System.Windows.Forms.Label();
            this.tmrKviz = new System.Windows.Forms.Timer(this.components);
            this.lblTajmer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPitanje
            // 
            this.lblPitanje.AutoSize = true;
            this.lblPitanje.Location = new System.Drawing.Point(154, 117);
            this.lblPitanje.Name = "lblPitanje";
            this.lblPitanje.Size = new System.Drawing.Size(38, 13);
            this.lblPitanje.TabIndex = 0;
            this.lblPitanje.Text = "pitanje";
            // 
            // lblOdg4
            // 
            this.lblOdg4.AutoSize = true;
            this.lblOdg4.Location = new System.Drawing.Point(383, 219);
            this.lblOdg4.Name = "lblOdg4";
            this.lblOdg4.Size = new System.Drawing.Size(31, 13);
            this.lblOdg4.TabIndex = 1;
            this.lblOdg4.Text = "odg4";
            this.lblOdg4.Click += new System.EventHandler(this.lblOdg4_Click);
            // 
            // lblOdg3
            // 
            this.lblOdg3.AutoSize = true;
            this.lblOdg3.Location = new System.Drawing.Point(136, 261);
            this.lblOdg3.Name = "lblOdg3";
            this.lblOdg3.Size = new System.Drawing.Size(31, 13);
            this.lblOdg3.TabIndex = 2;
            this.lblOdg3.Text = "odg3";
            this.lblOdg3.Click += new System.EventHandler(this.lblOdg3_Click);
            // 
            // lblOdg2
            // 
            this.lblOdg2.AutoSize = true;
            this.lblOdg2.Location = new System.Drawing.Point(150, 227);
            this.lblOdg2.Name = "lblOdg2";
            this.lblOdg2.Size = new System.Drawing.Size(31, 13);
            this.lblOdg2.TabIndex = 3;
            this.lblOdg2.Text = "odg2";
            this.lblOdg2.Click += new System.EventHandler(this.lblOdg2_Click);
            // 
            // lblOdg1
            // 
            this.lblOdg1.AutoSize = true;
            this.lblOdg1.Location = new System.Drawing.Point(154, 183);
            this.lblOdg1.Name = "lblOdg1";
            this.lblOdg1.Size = new System.Drawing.Size(31, 13);
            this.lblOdg1.TabIndex = 4;
            this.lblOdg1.Text = "odg1";
            this.lblOdg1.Click += new System.EventHandler(this.lblOdg1_Click);
            // 
            // tmrKviz
            // 
            this.tmrKviz.Interval = 1000;
            this.tmrKviz.Tick += new System.EventHandler(this.tmrKviz_Tick);
            // 
            // lblTajmer
            // 
            this.lblTajmer.AutoSize = true;
            this.lblTajmer.Location = new System.Drawing.Point(391, 227);
            this.lblTajmer.Name = "lblTajmer";
            this.lblTajmer.Size = new System.Drawing.Size(35, 13);
            this.lblTajmer.TabIndex = 5;
            this.lblTajmer.Text = "";
            // 
            // frmKvizNivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTajmer);
            this.Controls.Add(this.lblOdg1);
            this.Controls.Add(this.lblOdg2);
            this.Controls.Add(this.lblOdg3);
            this.Controls.Add(this.lblOdg4);
            this.Controls.Add(this.lblPitanje);
            this.Name = "frmKvizNivo";
            this.Text = "FormaKvizNivo";
            this.Load += new System.EventHandler(this.frmKvizNivo_Load);
            this.SizeChanged += new System.EventHandler(this.frmKvizNivo_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmKvizNivo_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPitanje;
        private System.Windows.Forms.Label lblOdg4;
        private System.Windows.Forms.Label lblOdg3;
        private System.Windows.Forms.Label lblOdg2;
        private System.Windows.Forms.Label lblOdg1;
        private System.Windows.Forms.Timer tmrKviz;
        private System.Windows.Forms.Label lblTajmer;
    }
}