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
        public Point centar;
        public Nivo<SlobodanZadatak> nivo;
        public int indexZadatka;
        int visinaForme;
        int sirinaForme;
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
        bool kraj;
        //U OVU STATICKU PROMENLJIVU SE CUVA NAZIV NIVOA KOJI TREBA DA SE UCITA
        //TREBA ONA DA SE AZURIRA PRE NEGO STO SE PRITISNE DUGME ZA ULAZAK U NIVO
        public static string nazivFajlaNivoa;
        private void frmSlobodanNivo_Load(object sender, EventArgs e)
        {
            RadnaPovrsina.IzracunajPolja(this, out gornjiLevi, out centar, out duzinaStr);
            visinaForme = this.Height;
            sirinaForme = this.Width;
            VeLicinaLokacijaSvega();
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
            btnSveska.Left = 5;
            btnPosalji.Left = 5;
            btnPomoc.Left = 5;
            btnSveska.Top = 5;
            btnSveska.Height = duzinaStr / 10;
            btnPomoc.Height = duzinaStr / 10;
            btnPosalji.Height = duzinaStr / 10;
            btnPomoc.Top = 10 + btnSveska.Height;
            btnPosalji.Top = visinaForme - 45 - duzinaStr / 10;
            lblTimer.Top = btnPomoc.Bottom + 5;
            lblTimer.Left = 5;
            tbxOdg1.Height = duzinaStr / 20;
            tbxOdg2.Height = duzinaStr / 20;
            tbxOdg3.Height = duzinaStr / 20;
            tbxOdg1.Width = duzinaStr / 20 * 3;
            tbxOdg2.Width = duzinaStr / 20 * 3;
            tbxOdg3.Width = duzinaStr / 20 * 3;
            tbxOdg3.Top = btnPosalji.Top - duzinaStr / 20 - 5;
            tbxOdg2.Top = tbxOdg3.Top - duzinaStr / 20 - 5;
            tbxOdg1.Top = tbxOdg2.Top - duzinaStr / 20 - 5;
            lblOdg1.Top = tbxOdg1.Top;
            lblOdg1.Width = tbxOdg1.Width;
            lblOdg2.Top = tbxOdg2.Top;
            lblOdg2.Width = tbxOdg2.Width;
            lblOdg3.Top = tbxOdg3.Top;
            lblOdg3.Width = tbxOdg3.Width;
            pbxSrce1.Width = (int)1.5 * duzinaStr / 20;
            pbxSrce1.Height = (int)1.5 * duzinaStr / 20;
            pbxSrce2.Width = (int)1.5 * duzinaStr / 20;
            pbxSrce2.Height = (int)1.5 * duzinaStr / 20;
            pbxSrce3.Width = (int)1.5 * duzinaStr / 20;
            pbxSrce3.Height = (int)1.5 * duzinaStr / 20;
            pbxSrce1.Left = sirinaForme - 25 - pbxSrce1.Width;
            pbxSrce2.Left = pbxSrce1.Left - 5 - pbxSrce2.Width;
            pbxSrce3.Left = pbxSrce2.Left - 5 - pbxSrce3.Width;
            pbxSrce1.Top = 5;
            pbxSrce2.Top = 5;
            pbxSrce3.Top = 5;
            btnPomoc.Font = new Font("Georgia", duzinaStr / 45);
            btnObrisi.Font = new Font("Georgia", duzinaStr / 45);
            btnPosalji.Font = new Font("Georgia", duzinaStr / 45);
            btnSveska.Font = new Font("Georgia", duzinaStr / 45);
            tbxOdg1.Font = new Font("Georgia", duzinaStr / 45);
            tbxOdg2.Font = new Font("Georgia", duzinaStr / 45);
            tbxOdg3.Font = new Font("Georgia", duzinaStr / 45);
            lblOdg1.Font = new Font("Georgia", duzinaStr / 45);
            lblOdg2.Font = new Font("Georgia", duzinaStr / 45);
            lblOdg3.Font = new Font("Georgia", duzinaStr / 45);
            lblPitanje.Font = new Font("Georgia", duzinaStr / 45);
            lblTimer.Font = new Font("Georgia", duzinaStr / 30); 
            lblKraj.Font = new Font("Georgia", duzinaStr / 30);
            btnPonovo.Font = new Font("Georgia", duzinaStr / 45);
            btnNazad.Font = new Font("Georgia", duzinaStr / 45);
            if (sirinaForme > visinaForme)
            {
                if (gornjiLevi.X > duzinaStr / 20 * 3 + 10)
                {
                    tbxOdg1.Left = gornjiLevi.X - duzinaStr / 20 * 3 - 5;
                    tbxOdg2.Left = gornjiLevi.X - duzinaStr / 20 * 3 - 5;
                    tbxOdg3.Left = gornjiLevi.X - duzinaStr / 20 * 3 - 5;
                    btnSveska.Width = gornjiLevi.X - 10;
                    btnPomoc.Width = gornjiLevi.X - 10;
                    btnPosalji.Width = gornjiLevi.X - 10;
                }
                else
                {
                    tbxOdg1.Left = 5;
                    tbxOdg2.Left = 5;
                    tbxOdg3.Left = 5;
                    btnPosalji.Width = duzinaStr / 20 * 3;
                    btnPomoc.Width = duzinaStr / 20 * 3;
                    btnSveska.Width = duzinaStr / 20 * 3;
                }
                lblOdg1.Left = tbxOdg1.Left - lblOdg1.Width - 15;
                lblOdg2.Left = tbxOdg2.Left - lblOdg2.Width - 15;
                lblOdg3.Left = tbxOdg3.Left - lblOdg3.Width - 15;
            }
            else
            {
                tbxOdg1.Left = 25;
                tbxOdg2.Left = 25;
                tbxOdg3.Left = 25;
                btnSveska.Width = duzinaStr / 4;
                btnPomoc.Width = duzinaStr / 4;
                btnPosalji.Width = duzinaStr / 4;
                lblOdg1.Left = 0;
                lblOdg2.Left = 0;
                lblOdg3.Left = 0;
            }
            btnObrisi.Height = btnSveska.Height;
            btnObrisi.Width = btnSveska.Width;
            btnObrisi.Top = btnPosalji.Top;
            btnObrisi.Left = btnPosalji.Left;
            btnNazad.Height = duzinaStr / 10;
            btnNazad.Width = duzinaStr / 5;
            btnNazad.Top = gornjiLevi.Y + duzinaStr / 2;
            btnNazad.Left = gornjiLevi.X + duzinaStr / 20 * 8;
            btnPonovo.Height = duzinaStr / 10;
            btnPonovo.Width = duzinaStr / 5;
            btnPonovo.Top = gornjiLevi.Y + duzinaStr / 20 * 13;
            btnPonovo.Left = gornjiLevi.X + duzinaStr / 20 * 8;
            lblPitanje.Top = 5;
            lblPitanje.Left = btnSveska.Right + 5;
            lblPitanje.Width = pbxSrce3.Left - 5 - lblPitanje.Left;
            lblPitanje.Height = duzinaStr / 20 * 2;
            lblKraj.Top = gornjiLevi.Y + duzinaStr / 20 * 8;
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
                btnPosalji.Visible = false;
                btnPosalji.Enabled = false;
                lblOdg1.Visible = false;
                lblOdg2.Visible = false;
                lblOdg3.Visible = false;
                lblOdg1.Enabled = false;
                lblOdg2.Enabled = false;
                lblOdg3.Enabled = false;
                tbxOdg1.Visible = false;
                tbxOdg2.Visible = false;
                tbxOdg3.Visible = false;
                tbxOdg1.Enabled = false;
                tbxOdg2.Enabled = false;
                tbxOdg3.Enabled = false;
                pbxSrce1.Enabled = false;
                pbxSrce2.Enabled = false;
                pbxSrce3.Enabled = false;
                pbxSrce3.Visible = false;
                pbxSrce2.Visible = false;
                pbxSrce1.Visible = false;
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
                btnPosalji.Visible = true;
                btnPosalji.Enabled = true;
                lblOdg1.Visible = true;
                lblOdg2.Visible = true;
                lblOdg3.Visible = true;
                lblOdg1.Enabled = true;
                lblOdg2.Enabled = true;
                lblOdg3.Enabled = true;
                tbxOdg1.Visible = true;
                tbxOdg2.Visible = true;
                tbxOdg3.Visible = true;
                tbxOdg1.Enabled = true;
                tbxOdg2.Enabled = true;
                tbxOdg3.Enabled = true;
                if (nivo.TrenutniBrojSrca >= 1)
                {
                    pbxSrce1.Enabled = true;
                    pbxSrce1.Visible = true;
                }
                if (nivo.TrenutniBrojSrca >= 2)
                {
                    pbxSrce2.Enabled = true;
                    pbxSrce2.Visible = true;
                }
                if (nivo.TrenutniBrojSrca == 3)
                {
                    pbxSrce3.Enabled = true;
                    pbxSrce3.Visible = true;
                }
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
        private void Kraj(bool izgubio)
        {
            kraj = true;
            btnSveska.Enabled = false;
            btnPosalji.Enabled = false;
            btnPomoc.Enabled = false;
            tbxOdg1.Enabled = false;
            tbxOdg2.Enabled = false;
            tbxOdg3.Enabled = false;
            btnObrisi.Enabled = false;
            lblKraj.Visible = true;
            lblKraj.Left = gornjiLevi.X + duzinaStr / 2 - lblKraj.Width / 2;
            btnNazad.Visible = true;
            btnNazad.Enabled = true;
            btnPonovo.Visible = izgubio;
            btnPonovo.Enabled = izgubio;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ostalo = nivo.Zadaci[indexZadatka].VremeZadatak - (DateTime.Now - pocetakZadatka);
            if (ostalo <= new TimeSpan(0, 0, 0))
            {
                timer1.Stop();
                lblKraj.Text = "Isteklo je vreme! Izgubili ste :(";
                Kraj(true);
            }
            else 
            {
                if (ostalo.Seconds > 9) 
                   lblTimer.Text = $"{ostalo.Minutes}:{ostalo.Seconds}";
                else
                    lblTimer.Text = $"{ostalo.Minutes}:0{ostalo.Seconds}";
            }
            
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
                        if (!otvorenaSveska && !kraj)
                        {
                            BrojOdgovora(false, false);
                            lblOdg1.Text = null;
                            lblOdg2.Text = null;
                            lblOdg3.Text = "Resenje:";
                        }
                        break;
                    }
                case FormaResenja.tacka:
                    {
                        if (!otvorenaSveska && !kraj)
                        {
                            BrojOdgovora(false, true);
                            lblOdg1.Text = null;
                            lblOdg2.Text = "X:";
                            lblOdg3.Text = "Y:";
                        }
                        break;
                    }
                case FormaResenja.pravaEks:
                    {
                        if (!otvorenaSveska && !kraj)
                        {
                            BrojOdgovora(false, true);
                            lblOdg1.Text = null;
                            lblOdg2.Text = "K:";
                            lblOdg3.Text = "N:";
                        }
                        break;
                    }
                case FormaResenja.pravaImp:
                    {
                        if (!otvorenaSveska && !kraj)
                        {
                            BrojOdgovora(true, true);
                            lblOdg1.Text = "A:";
                            lblOdg2.Text = "B:";
                            lblOdg3.Text = "C:";
                        }
                        break;
                    }
                case FormaResenja.krug:
                    {
                        if (!otvorenaSveska && !kraj)
                        {
                            BrojOdgovora(true, true);
                            lblOdg1.Text = "P:";
                            lblOdg2.Text = "Q:";
                            lblOdg3.Text = "R²:";
                        }
                        break;
                    }
                case FormaResenja.elipsaHiperbola:
                    {
                        if (!otvorenaSveska && !kraj)
                        {
                            BrojOdgovora(false, true);
                            lblOdg1.Text = null;
                            lblOdg2.Text = "A²:";
                            lblOdg3.Text = "B²:";
                        }
                        break;
                    }
                case FormaResenja.parabola:
                    {
                        if (!otvorenaSveska && !kraj)
                        {
                            BrojOdgovora(false, false);
                            lblOdg1.Text = null;
                            lblOdg2.Text = null;
                            lblOdg3.Text = "P:";
                        }
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
                if (indexZadatka >= 3)
                {
                    timer1.Stop();
                    lblKraj.Text = "Cestitamo! Pobedili ste :)";
                    Kraj(false);
                }
                else
                {
                    indexZadatka++;
                    this.Refresh();
                    VeLicinaLokacijaSvega();
                    pocetakZadatka = DateTime.Now;
                    tbxOdg1.Text = null;
                    tbxOdg2.Text = null;
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
                    lblKraj.Text = "Nemate vise zivota! Izgubili ste :(";
                    Kraj(true);
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
            pocetakZadatka = pocetakZadatka - new TimeSpan(0, 0, 20);
            MessageBox.Show(nivo.Zadaci[indexZadatka].Hint, "POMOC");
        }
        private void btnNazad_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPonovo_Click(object sender, EventArgs e)
        {
            kraj = false;
            btnSveska.Enabled = true;
            btnSveska.Visible = true;
            btnPosalji.Enabled = true;
            btnPosalji.Visible = true;
            btnPomoc.Enabled = true;
            btnPomoc.Visible = true;
            tbxOdg1.Enabled = true;
            tbxOdg2.Enabled = true;
            tbxOdg3.Enabled = true;
            btnObrisi.Enabled = false;
            btnObrisi.Visible = false;
            lblKraj.Visible = false;
            btnNazad.Visible = false;
            btnNazad.Enabled = false;
            btnPonovo.Visible = false;
            btnPonovo.Enabled = false;
            indexZadatka = 0;
            this.Refresh();
            VeLicinaLokacijaSvega();
            nivo.TrenutniBrojSrca = 3;
            pbxSrce1.Visible = true;
            pbxSrce2.Visible = true;
            pbxSrce3.Visible = true;
            pocetakZadatka = DateTime.Now;
            timer1.Start();
            tbxOdg1.Text = null;
            tbxOdg2.Text = null;
            tbxOdg3.Text = null;
        }
    }
}
