using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgeomProj
{
    public partial class frmKvizNivo : Form
    {
        public frmKvizNivo(Nivo<KvizZadatak> nivo)
        {
            InitializeComponent();
        }
        public Point gornjiLevi;
        public int duzinaStr;
        public Point centar;
        public Nivo<KvizZadatak> nivo;
        public int indexZadatka;
        private void frmKvizNivo_Load(object sender, EventArgs e)
        {
            //nivo.UnosIzFajla("");
            RadnaPovrsina.IzracunajPolja(this, out gornjiLevi, out centar, out duzinaStr);
        }
        public void VelicinaLokacijaSvega()
        {
            int levaStrana = gornjiLevi.X + duzinaStr / 40;
            lblPitanje.Left = levaStrana;
            lblPitanje.Top = gornjiLevi.Y + duzinaStr / 20;
            lblPitanje.Font = new Font("Georgia", (int)(duzinaStr / 30));
            lblOdg1.Left = levaStrana;
            lblOdg1.Top = lblPitanje.Bottom + duzinaStr / 20;
            lblOdg1.Font = new Font("Georgia", (int)(duzinaStr / 30));
            lblOdg2.Left = levaStrana;
            lblOdg2.Top = lblOdg1.Bottom + duzinaStr / 20;
            lblOdg2.Font = new Font("Georgia", (int)(duzinaStr / 30));
            lblOdg3.Left = levaStrana;
            lblOdg3.Top = lblOdg2.Bottom + duzinaStr / 20;
            lblOdg3.Font = new Font("Georgia", (int)(duzinaStr / 30));
            lblOdg4.Left = levaStrana;
            lblOdg4.Top = lblOdg3.Bottom + duzinaStr / 20;
            lblOdg4.Font = new Font("Georgia", (int)(duzinaStr / 30));
        }
        public void OkviriOdgovora(PaintEventArgs e)
        {
            for (int i = 0; i < 4; i++) 
            {
                Label a = (Label)this.Controls.Find("lbl" + "Odg" + (i + 1), true)[0];
                Point gornjiLevi = new Point();
                gornjiLevi.X = a.Left;
                gornjiLevi.Y = a.Top;
                int duzina = a.Width;
                int visina = a.Height;
                Pen okvir = new Pen(Color.Black, 3);
                e.Graphics.DrawRectangle(okvir,gornjiLevi.X,gornjiLevi.Y,duzina,visina);
            }
        }
        public void BojenjeOdgovora(int indexTacnog)
        {
            for (int i = 0; i < 4; i++)
            {
                Label a = (Label)this.Controls.Find("lbl" + "Odg" + (i + 1), true)[0];
                if(indexTacnog == i)
                    a.BackColor = Color.Green;
                else
                    a.BackColor = Color.Red;
            }
        }
        private void frmKvizNivo_Paint(object sender, PaintEventArgs e)
        {
            VelicinaLokacijaSvega();
            OkviriOdgovora(e);
            BojenjeOdgovora(0);
            RadnaPovrsina.ucitajPozadinu(e.Graphics, this);
        }

        private void frmKvizNivo_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                RadnaPovrsina.IzracunajPolja(this, out gornjiLevi, out centar, out duzinaStr);
                this.Refresh();
            }
        }

        
    }
}
