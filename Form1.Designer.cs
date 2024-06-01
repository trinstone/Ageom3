namespace AgeomProj
{
    partial class frmUvod
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
            this.lblIgraj = new System.Windows.Forms.Label();
            this.btnFormule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIgraj
            // 
            this.lblIgraj.AutoSize = true;
            this.lblIgraj.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIgraj.Location = new System.Drawing.Point(436, 243);
            this.lblIgraj.Name = "lblIgraj";
            this.lblIgraj.Size = new System.Drawing.Size(73, 25);
            this.lblIgraj.TabIndex = 0;
            this.lblIgraj.Text = "IGRAJ";
            this.lblIgraj.Click += new System.EventHandler(this.lblIgraj_Click);
            // 
            // btnFormule
            // 
            this.btnFormule.BackColor = System.Drawing.Color.Transparent;
            this.btnFormule.Location = new System.Drawing.Point(585, 428);
            this.btnFormule.Name = "btnFormule";
            this.btnFormule.Size = new System.Drawing.Size(75, 23);
            this.btnFormule.TabIndex = 1;
            this.btnFormule.Text = "Formule";
            this.btnFormule.UseVisualStyleBackColor = false;
            this.btnFormule.Click += new System.EventHandler(this.btnFormule_Click);
            // 
            // frmUvod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 630);
            this.Controls.Add(this.btnFormule);
            this.Controls.Add(this.lblIgraj);
            this.Name = "frmUvod";
            this.Text = "Ageom";
            this.Load += new System.EventHandler(this.frmUvod_Load);
            this.SizeChanged += new System.EventHandler(this.frmUvod_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmUvod_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmUvod_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIgraj;
        private System.Windows.Forms.Button btnFormule;
    }
}

