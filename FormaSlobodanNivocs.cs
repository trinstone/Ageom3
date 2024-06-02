using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgeomProj
{
    public partial class frmSlobodanNivo : Form
    {
        public frmSlobodanNivo(Nivo<SlobodanZadatak> nivo)
        {
            InitializeComponent();
            this.nivo = nivo;
            indexZadatka = 0;
        }
        public Point gornjiLevi;
        public int duzinaStr; 
        int visinaForme;
        int sirinaForme;
        public Point centar;
        public Nivo<SlobodanZadatak> nivo;
        public int indexZadatka;
        bool crtanjeUSvesci = false;
        bool otvorenaSveska = false;
        Point prethodna;
        Point novaTacka;
        Graphics sveska;
        //U OVU STATICKU PROMENLJIVU SE CUVA NAZIV NIVOA KOJI TREBA DA SE UCITA
        //TREBA ONA DA SE AZURIRA PRE NEGO STO SE PRITISNE DUGME ZA ULAZAK U NIVO
        public static string nazivFajlaNivoa;
        private void frmSlobodanNivo_Load(object sender, EventArgs e)
        {
            RadnaPovrsina.IzracunajPolja(this, out gornjiLevi, out centar, out duzinaStr);
            visinaForme = this.Height;
            sirinaForme = this.Width;
        }

        private void frmSlobodanNivo_Paint(object sender, PaintEventArgs e)
        {
            RadnaPovrsina.ucitajPozadinu(e.Graphics, this);
            nivo.Zadaci[indexZadatka].Nacrtaj(e.Graphics, centar, duzinaStr / 20);

        }
        public void VeLicinaLokacijaSvega()
        {
            pnlSveska.Left = 0;
            pnlSveska.Top = 0;
            pnlSveska.Width = sirinaForme;
            pnlSveska.Height = visinaForme;
            sveska = pnlSveska.CreateGraphics();
        }
        private void frmSlobodanNivo_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                RadnaPovrsina.IzracunajPolja(this, out gornjiLevi, out centar, out duzinaStr);
                this.Refresh();
                visinaForme = this.Height;
                sirinaForme = this.Width;
                VeLicinaLokacijaSvega();
            }
        }

        private void btnSveska_Click(object sender, EventArgs e)
        {
            if (!otvorenaSveska)
            {
                pnlSveska.Enabled = true;
                pnlSveska.Visible = true;
                btnObrisi.Enabled = true;
                btnObrisi.Visible = true;
                otvorenaSveska = true;
                btnSveska.Text = "NAZAD";
                sveska = pnlSveska.CreateGraphics();
            }
            else
            {
                pnlSveska.Enabled = false;
                pnlSveska.Visible = false;
                btnObrisi.Enabled = false;
                btnObrisi.Visible = false;
                otvorenaSveska = false;
                btnSveska.Text = "SVESKA";
            }
        }

        private void pnlSveska_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i <= pnlSveska.Height; i += duzinaStr / 20)
            {
                e.Graphics.DrawLine(Pens.Gray, 0, i, pnlSveska.Width, i);
            }
            for (int i = 0; i <= pnlSveska.Width; i += duzinaStr / 20)
            {
                e.Graphics.DrawLine(Pens.Gray, i, 0, i, pnlSveska.Height);
            }
        }

        private void pnlSveska_MouseDown(object sender, MouseEventArgs e)
        {
            crtanjeUSvesci = true;
            prethodna = e.Location;
        }

        private void pnlSveska_MouseMove(object sender, MouseEventArgs e)
        {
            if (crtanjeUSvesci)
            {
                novaTacka = e.Location;
                sveska.DrawLine(Pens.Black, prethodna, novaTacka);
                prethodna = novaTacka;
            }
        }

        private void pnlSveska_MouseUp(object sender, MouseEventArgs e)
        {
            crtanjeUSvesci = false;
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            pnlSveska.Refresh();
        }

    }
}
