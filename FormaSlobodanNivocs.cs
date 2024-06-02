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
        Graphics pozadina;
        DateTime pocetakZadatka;
        string odg1;
        string odg2;
        string odg3;
        //U OVU STATICKU PROMENLJIVU SE CUVA NAZIV NIVOA KOJI TREBA DA SE UCITA
        //TREBA ONA DA SE AZURIRA PRE NEGO STO SE PRITISNE DUGME ZA ULAZAK U NIVO
        public static string nazivFajlaNivoa;
        private void frmSlobodanNivo_Load(object sender, EventArgs e)
        {
            RadnaPovrsina.IzracunajPolja(this, out gornjiLevi, out centar, out duzinaStr);
            visinaForme = this.Height;
            sirinaForme = this.Width;
            pocetakZadatka = DateTime.Now;
            timer1.Start();
        }

        private void frmSlobodanNivo_Paint(object sender, PaintEventArgs e)
        {
            RadnaPovrsina.ucitajPozadinu(e.Graphics, this);
            pozadina = e.Graphics;
            UcitajZadatak();
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
                sveska.DrawLine(new Pen(Color.Black, 5), prethodna, novaTacka);
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ostalo = nivo.Zadaci[indexZadatka].VremeZadatak - (DateTime.Now - pocetakZadatka);
            if (ostalo <= new TimeSpan(0, 0, 0))
            {
                timer1.Stop();
                //izgubio
            }
            else lblTimer.Text = $"{ostalo.Minutes}:{ostalo.Seconds}";
        }
        private void BrojOdgovora(bool prvi, bool drugi)
        {
            lblOdg1.Visible = prvi;
            lblOdg2.Visible = drugi;
            lblOdg2.Enabled = drugi;
            lblOdg1.Enabled = prvi;
            tbxOdg1.Visible = prvi;
            tbxOdg1.Enabled = prvi;
            tbxOdg2.Enabled = drugi;
            tbxOdg2.Visible = drugi;
        }
        private void UcitajZadatak()
        {
            nivo.Zadaci[indexZadatka].Nacrtaj(pozadina, centar, duzinaStr / 20);
            lblPitanje.Text = nivo.Zadaci[indexZadatka].Pitanje;
            switch (nivo.Zadaci[indexZadatka].FormaResenja)
            {
                case FormaResenja.broj:
                case FormaResenja.tekst:
                    {
                        BrojOdgovora(false, false);
                        lblOdg1.Text = null;
                        lblOdg2.Text = null;
                        lblOdg3.Text = "Resenje:";
                        break;
                    }
                case FormaResenja.tacka:
                    {
                        BrojOdgovora(false, true);
                        lblOdg1.Text = null;
                        lblOdg2.Text = "X:";
                        lblOdg3.Text = "Y:";
                        break;
                    }
                case FormaResenja.pravaEks:
                    {
                        BrojOdgovora(false, true);
                        lblOdg1.Text = null;
                        lblOdg2.Text = "K:";
                        lblOdg3.Text = "N:";
                        break;
                    }
                case FormaResenja.pravaImp:
                    {
                        BrojOdgovora(true, true);
                        lblOdg1.Text = "A:";
                        lblOdg2.Text = "B:";
                        lblOdg3.Text = "C:";
                        break;
                    }
                case FormaResenja.krug:
                    {
                        BrojOdgovora(true, true);
                        lblOdg1.Text = "R:";
                        lblOdg2.Text = "P:";
                        lblOdg3.Text = "Q:";
                        break;
                    }
                case FormaResenja.elipsaHiperbola:
                    {
                        BrojOdgovora(false, true);
                        lblOdg1.Text = null;
                        lblOdg2.Text = "A:";
                        lblOdg3.Text = "B:";
                        break;
                    }
                case FormaResenja.parabola:
                    {
                        BrojOdgovora(false, false);
                        lblOdg1.Text = null;
                        lblOdg2.Text = null;
                        lblOdg3.Text = "P:";
                        break;
                    }
                default: break;
            }
        }

        private void btnPosalji_Click(object sender, EventArgs e)
        {
            if (odg1 == nivo.Zadaci[indexZadatka].parametri[0] &&
                odg2 == nivo.Zadaci[indexZadatka].parametri[1] &&
                odg3 == nivo.Zadaci[indexZadatka].parametri[2])
            {
                //transliranje
                if (indexZadatka >= 4)
                {
                    timer1.Stop();
                    //pobeda
                }
                else
                {
                    indexZadatka++;
                    UcitajZadatak();
                    tbxOdg2.Text = null;
                    tbxOdg1.Text = null;
                    tbxOdg3.Text = null;
                }
            }
            else
            {
                nivo.TrenutniBrojSrca--;
                if (nivo.TrenutniBrojSrca == 2)
                {
                    pbxSrce3.Visible = false;
                }
                else if (nivo.TrenutniBrojSrca == 1)
                {
                    pbxSrce2.Visible = false;
                }
                else
                {
                    pbxSrce1.Visible = false;
                    timer1.Stop();
                    //izgubio
                }
            }
        }

        private void tbxOdg1_TextChanged(object sender, EventArgs e)
        {
            odg1 = tbxOdg1.Text;
        }

        private void tbxOdg2_TextChanged(object sender, EventArgs e)
        {
            odg2 = tbxOdg2.Text;
        }

        private void tbxOdg3_TextChanged(object sender, EventArgs e)
        {
            odg3 = tbxOdg3.Text;
        }

        private void btnPomoc_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nivo.Zadaci[indexZadatka].Hint, "POMOC");
        }

    }
}
