using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AgeomProj
{
    public partial class frmKvizNivo : Form
    {
        public frmKvizNivo(Nivo<KvizZadatak> nivo)
        {
            InitializeComponent();
            this.nivo = nivo;
        }
        public Point gornjiLevi;
        public int duzinaStr;
        public Point centar;
        public Nivo<KvizZadatak> nivo;
        public int indexZadatka = 0;
        public int indexTacnog;
        DateTime pocetakZadatka;
        public bool krajZadatka = false;
        KvizZadatak trenutni;
        Stopwatch stoperica=new Stopwatch();    
        private void frmKvizNivo_Load(object sender, EventArgs e)
        {
            RadnaPovrsina.IzracunajPolja(this, out gornjiLevi, out centar, out duzinaStr);
            if (indexZadatka==0)
            {
                trenutni = nivo.Zadaci[indexZadatka];
                (int index, string[] odgovori) = trenutni.PromesajOdgovore();
                indexTacnog = index;
                trenutni = nivo.Zadaci[indexZadatka];
                IspisiTekst(trenutni.Pitanje, odgovori);
                
                this.Refresh();

            }
            pocetakZadatka = DateTime.Now;
            tmrKviz.Start();
        }
        public void UcitajZadatak()
        {
            trenutni = nivo.Zadaci[indexZadatka];
            (int index, string[] odgovori) = trenutni.PromesajOdgovore();
            indexTacnog = index;
            trenutni = nivo.Zadaci[indexZadatka];
            IspisiTekst(trenutni.Pitanje, odgovori);
            
            this.Refresh();

        }
        public void ObrisiBoje()
        {
            lblOdg1.BackColor = SystemColors.Control;
            lblOdg2.BackColor = SystemColors.Control;
            lblOdg3.BackColor = SystemColors.Control;
            lblOdg4.BackColor = SystemColors.Control;

        }
        public void IspisiTekst(string pitanje, string[] odgovori)
        {
            lblPitanje.Text = pitanje;
            for (int i = 0; i < 4; i++)
            {
                Label a = (Label)this.Controls.Find("lbl" + "Odg" + (i + 1), true)[0];
                a.Text = odgovori[i];
            }
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
                e.Graphics.DrawRectangle(okvir, gornjiLevi.X, gornjiLevi.Y, duzina, visina);
            }
        }
        public void BojenjeOdgovora(int indexTacnog)
        {
            for (int i = 0; i < 4; i++)
            {
                Label a = (Label)this.Controls.Find("lbl" + "Odg" + (i + 1), true)[0];
                if (indexTacnog == i)
                    a.BackColor = Color.Green;
                else
                    a.BackColor = Color.Red;
            }
        }
        private void frmKvizNivo_Paint(object sender, PaintEventArgs e)
        {
            VelicinaLokacijaSvega();
            OkviriOdgovora(e);
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

        private void lblOdg1_Click(object sender, EventArgs e)
        {
            BojenjeOdgovora(indexTacnog);
            if (indexTacnog == 0)
            {
                if (indexZadatka < 3)
                {
                    ObrisiBoje();
                    indexZadatka++;
                    UcitajZadatak();
                    pocetakZadatka = DateTime.Now;                   
                }
                else
                {
                    tmrKviz.Stop();
                    MessageBox.Show("Cestitamo! Uspesno ste presli nivo.");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Netacan odgovor! Kraj nivoa.");
               this.Close();
            }
        }

        private void lblOdg2_Click(object sender, EventArgs e)
        {
            BojenjeOdgovora(indexTacnog);
            if (indexTacnog == 1)
            {
                if (indexZadatka < 3)
                {                    
                    ObrisiBoje();
                    indexZadatka++;
                    UcitajZadatak();
                    pocetakZadatka = DateTime.Now;
                }
                else
                {
                    tmrKviz.Stop();
                    MessageBox.Show("Cestitamo! Uspesno ste presli nivo.");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Netacan odgovor! Kraj nivoa.");
                this.Close();
            }
        }

        private void lblOdg3_Click(object sender, EventArgs e)
        {
            BojenjeOdgovora(indexTacnog);
            if (indexTacnog == 2)
            {
                if (indexZadatka < 3)
                {                    
                    ObrisiBoje();
                    indexZadatka++;
                    UcitajZadatak();
                    pocetakZadatka = DateTime.Now;                       
                }
                else
                {
                    tmrKviz.Stop();
                    MessageBox.Show("Cestitamo! Uspesno ste presli nivo.");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Netacan odgovor! Kraj nivoa.");
                this.Close();
            }
        }

        private void lblOdg4_Click(object sender, EventArgs e)
        {
            BojenjeOdgovora(indexTacnog);
            if (indexTacnog == 3)
            {
                if (indexZadatka < 3)
                {                   
                    ObrisiBoje();
                    indexZadatka++;
                    UcitajZadatak();
                    pocetakZadatka = DateTime.Now;
                }
                else
                {
                    tmrKviz.Stop();
                    MessageBox.Show("Cestitamo! Uspesno ste presli nivo.");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Netacan odgovor! Kraj nivoa.");
                this.Close();
            }
        }

        private void tmrKviz_Tick(object sender, EventArgs e)
        {
            TimeSpan ostalo = nivo.Zadaci[indexZadatka].VremeZadatak - (DateTime.Now - pocetakZadatka);
            if (ostalo <= new TimeSpan(0, 0, 0))
            {
                tmrKviz.Stop();

            }
            else lblTajmer.Text = $"{ostalo.Minutes}:{ostalo.Seconds}";
        }
    }
}
