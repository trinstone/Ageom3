using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace AgeomProj
{
    public partial class frmUvod : Form
    {
        public Point gornjiLevi;
        public int duzinaStr;
        bool pocetniMeni;
        bool meni = false;
        public Point centar;
        public Form formaSlobZadatak;
        public Form formaKvizZadatak;
        Point a;//a je gornja tacka trougla igraj, b je donja
        Point b;
        public frmUvod()
        {
            InitializeComponent();
        }
        private void frmUvod_Load(object sender, EventArgs e)
        {
            RadnaPovrsina.IzracunajPolja(this,out gornjiLevi,out centar,out duzinaStr);
            pocetniMeni = true;

            //ODAVDE TESTIRAJTE NIVOE
            Nivo<SlobodanZadatak> n = new Nivo<SlobodanZadatak>(3, 3, 0, "p1.txt");
            formaSlobZadatak = new frmSlobodanNivo(n);
            formaSlobZadatak.Show();
        }
        public void VeLicinaLokacijaSvega()
        {
            lblIgraj.Font = new Font("Georgia", (int)(duzinaStr/20));
            lblIgraj.Left = centar.X + 5;
            lblIgraj.Top = centar.Y - lblIgraj.Width / 5;
            btnFormule.Width = (int)(3 * duzinaStr / 20);
            btnFormule.Height = (int)(1.5*duzinaStr/20);
            btnFormule.Left = centar.X + duzinaStr/2 - btnFormule.Width;
            btnFormule.Top = centar.Y + (int)(duzinaStr/2.5) - btnFormule.Height;  
            btnFormule.Font = new Font("Georgia", (int)(duzinaStr / 45));
        }
        private void frmUvod_Paint(object sender, PaintEventArgs e)
        {
            int strKvad = duzinaStr / 20;
            VeLicinaLokacijaSvega();
            RadnaPovrsina.ucitajPozadinu(e.Graphics, this);
            if (pocetniMeni)
            {
                lblIgraj.Visible = true;
                lblIgraj.Enabled = true;
                btnFormule.Visible = true;
                btnFormule.Enabled = true;
                lblPrava.Visible = false;
                lblKrug.Visible = false;
                lblElHi.Visible = false;
                lblParabola.Visible = false;
                lblp1.Visible = false;
                lblp2.Visible = false;
                lblp3.Visible = false;

                lblk1.Visible = false;
                lblk2.Visible = false;
                lblk3.Visible = false;

                lbleh1.Visible = false;
                lbleh2.Visible = false;
                lbleh3.Visible = false;

                lblpa1.Visible = false;
                lblpa2.Visible = false;
                lblpa3.Visible = false;

                lblpKviz.Visible = false;
                lblkKviz.Visible = false;
                lblehKviz.Visible = false;
                lblpaKviz.Visible = false;
                a.X = centar.X - 5 * strKvad;
                a.Y = centar.Y - 3 * strKvad;
                b.X = centar.X - 5 * strKvad;
                b.Y = centar.Y + 3 * strKvad;
                Pen trougaoIgraj = new Pen(Color.Black, 5);
                Point[] crtanjeTrougao = { a, b, centar };
                e.Graphics.DrawPolygon(trougaoIgraj, crtanjeTrougao);
            }

            else if (meni)
            {
                lblIgraj.Visible = false;
                lblIgraj.Enabled = false;
                btnFormule.Visible = false;
                btnFormule.Enabled = false;
                lblPrava.Visible = true;
                lblKrug.Visible = true;
                lblElHi.Visible = true;
                lblParabola.Visible = true;
                lblp1.Visible = true;
                lblp2.Visible = true;
                lblp3.Visible = true;

                lblk1.Visible = true;
                lblk2.Visible = true;
                lblk3.Visible = true;

                lbleh1.Visible = true;
                lbleh2.Visible = true;
                lbleh3.Visible = true;

                lblpa1.Visible = true;
                lblpa2.Visible = true;
                lblpa3.Visible = true;

                lblpKviz.Visible = true;
                lblkKviz.Visible = true;
                lblehKviz.Visible = true;
                lblpaKviz.Visible = true;
                lblPrava.Font= new Font("Georgia", (int)(duzinaStr / 25));
                lblKrug.Font = new Font("Georgia", (int)(duzinaStr / 25));
                lblElHi.Font = new Font("Georgia", (int)(duzinaStr / 25));
                lblParabola.Font = new Font("Georgia", (int)(duzinaStr / 25));
                lblPrava.Location = new Point(gornjiLevi.X + strKvad, strKvad - 10);
                lblKrug.Location = new Point(gornjiLevi.X + strKvad, 6 * strKvad - 10);
                lblElHi.Location = new Point(gornjiLevi.X + strKvad, 11 * strKvad - 10);
                lblParabola.Location = new Point(gornjiLevi.X + strKvad,16 * strKvad - 10);

                lblp1.Font = new Font("Georgia", (int)(duzinaStr / 35));
                lblp2.Font = new Font("Georgia", (int)(duzinaStr / 35));
                lblp3.Font = new Font("Georgia", (int)(duzinaStr / 35));

                lblk1.Font = new Font("Georgia", (int)(duzinaStr / 35));
                lblk2.Font = new Font("Georgia", (int)(duzinaStr / 35));
                lblk3.Font = new Font("Georgia", (int)(duzinaStr / 35));

                lblpa1.Font = new Font("Georgia", (int)(duzinaStr / 35));
                lblpa2.Font = new Font("Georgia", (int)(duzinaStr / 35));
                lblpa3.Font = new Font("Georgia", (int)(duzinaStr / 35));

                lbleh1.Font = new Font("Georgia", (int)(duzinaStr / 35));
                lbleh2.Font = new Font("Georgia", (int)(duzinaStr / 35));
                lbleh3.Font = new Font("Georgia", (int)(duzinaStr / 35));

                lblpKviz.Font = new Font("Georgia", (int)(duzinaStr / 35));
                lblkKviz.Font = new Font("Georgia", (int)(duzinaStr / 35));
                lblehKviz.Font = new Font("Georgia", (int)(duzinaStr / 35));
                lblpaKviz.Font = new Font("Georgia", (int)(duzinaStr / 35));

                lblp1.Location = new Point(gornjiLevi.X + 6 * strKvad, 3 * strKvad);
                lblp2.Location = new Point(gornjiLevi.X + 10 * strKvad, 3 * strKvad);
                lblp3.Location = new Point(gornjiLevi.X + 14 * strKvad, 3 * strKvad);

                lblk1.Location = new Point(gornjiLevi.X + 6 * strKvad, 8 * strKvad);
                lblk2.Location = new Point(gornjiLevi.X + 10 * strKvad, 8 * strKvad);
                lblk3.Location = new Point(gornjiLevi.X + 14 * strKvad, 8 * strKvad);

                lbleh1.Location = new Point(gornjiLevi.X + 6 * strKvad, 13 * strKvad);
                lbleh2.Location = new Point(gornjiLevi.X + 10 * strKvad, 13 * strKvad);
                lbleh3.Location = new Point(gornjiLevi.X + 14 * strKvad, 13 * strKvad);

                lblpa1.Location = new Point(gornjiLevi.X + 6 * strKvad, 18 * strKvad);
                lblpa2.Location = new Point(gornjiLevi.X + 10 * strKvad, 18 * strKvad);
                lblpa3.Location = new Point(gornjiLevi.X + 14 * strKvad, 18 * strKvad);

                lblpKviz.Location = new Point(gornjiLevi.X + strKvad, 3 * strKvad);
                lblkKviz.Location = new Point(gornjiLevi.X + strKvad, 8 * strKvad);
                lblehKviz.Location = new Point(gornjiLevi.X + strKvad, 13 * strKvad);
                lblpaKviz.Location = new Point(gornjiLevi.X + strKvad, 18 * strKvad);

                Pen olovka = new Pen(Color.Black, 5);
                e.Graphics.DrawLine(olovka, gornjiLevi.X, 5 * strKvad, gornjiLevi.X + duzinaStr, 5 * strKvad);
                e.Graphics.DrawLine(olovka, gornjiLevi.X, 10 * strKvad, gornjiLevi.X + duzinaStr, 10 * strKvad);
                e.Graphics.DrawLine(olovka, gornjiLevi.X, 15 * strKvad, gornjiLevi.X + duzinaStr, 15 * strKvad);
            }
            else
            {
                lblIgraj.Visible = false;
                lblIgraj.Enabled = false;
                btnFormule.Visible = false;
                btnFormule.Enabled = false;
            }


            /*TESTIRANJA
            PointF c = new PointF();
            c.X = 1;
            c.Y = 1;
            Krug k = new Krug(c, 5);
            k.Nacrtaj(e.Graphics,centar,strKvad);
            Prava p = new Prava(c, 0, 1);
            p.Nacrtaj(e.Graphics, centar, strKvad);
            Tacka t1 = new Tacka(new PointF(3, 3), "A");
            Tacka t2 = new Tacka(new PointF(2, 7), "B");
            Duz d = new Duz(t1, t2);
            d.Nacrtaj(e.Graphics,centar,strKvad);
            Elipsa el = new Elipsa(c, 4, 2);
            el.Nacrtaj(e.Graphics, centar, strKvad);
            Hiperbola hi = new Hiperbola(5.2f, 3.5f);
            hi.Nacrtaj(e.Graphics, centar, strKvad);
            Parabola pa = new Parabola(1);
            pa.Nacrtaj(e.Graphics, centar, strKvad);*/
        }


        private void frmUvod_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                RadnaPovrsina.IzracunajPolja(this, out gornjiLevi, out centar, out duzinaStr);
                this.Refresh();
            }
        }

        private void lblIgraj_Click(object sender, EventArgs e)
        {
            pocetniMeni = false;
            meni = true;
            this.Refresh();
        }
        public decimal PovrsinaTrougla(Point a, Point b, Point c)
        {
            return Math.Round(Convert.ToDecimal(0.5*Math.Abs(a.X*(b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y))),2);
        }
        private void frmUvod_MouseClick(object sender, MouseEventArgs e)
        {
            int strKvad = duzinaStr / 20;
            int ha = centar.X-a.X;
            int stra = b.Y - a.Y;
            decimal povrsinaGlavnog = Math.Round(Convert.ToDecimal(stra * ha) / 2, 2);
            Point m = new Point();
            m.X = e.X;
            m.Y = e.Y;
            decimal p1 = PovrsinaTrougla(a, b, m);
            decimal p2 = PovrsinaTrougla(a, centar, m);
            decimal p3 = PovrsinaTrougla(centar, b, m);
            if (povrsinaGlavnog == (p1 + p2 + p3))
            {
                pocetniMeni = false;
                meni = true;
                this.Refresh();
            }
        }

        private void btnFormule_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Analiticka - formule.pdf");
        }

        private void lblp1_Click(object sender, EventArgs e)
        {
            Nivo<SlobodanZadatak> n = new Nivo<SlobodanZadatak>(3,3,1);
            n.UnosIzFajla("p1.txt");
            formaSlobZadatak = new frmSlobodanNivo(n);
            formaSlobZadatak.Show();
        }

        private void lblp2_Click(object sender, EventArgs e)
        {
            Nivo<SlobodanZadatak> n = new Nivo<SlobodanZadatak>(3, 3, 2);
            n.UnosIzFajla("p2.txt");
            formaSlobZadatak = new frmSlobodanNivo(n);
            formaSlobZadatak.Show();
        }

        private void lblp3_Click(object sender, EventArgs e)
        {
            Nivo<SlobodanZadatak> n = new Nivo<SlobodanZadatak>(1, 1, 3);
            n.UnosIzFajla("p3.txt");
            formaSlobZadatak = new frmSlobodanNivo(n);
            formaSlobZadatak.Show();
        }

        private void lblk1_Click(object sender, EventArgs e)
        {
            Nivo<SlobodanZadatak> n = new Nivo<SlobodanZadatak>(3, 3, 1);
            n.UnosIzFajla("k1.txt");
            formaSlobZadatak = new frmSlobodanNivo(n);
            formaSlobZadatak.Show();
        }

        private void lblk2_Click(object sender, EventArgs e)
        {
            Nivo<SlobodanZadatak> n = new Nivo<SlobodanZadatak>(3, 3, 2);
            n.UnosIzFajla("k2.txt");
            formaSlobZadatak = new frmSlobodanNivo(n);
            formaSlobZadatak.Show();
        }

        private void lblk3_Click(object sender, EventArgs e)
        {
            Nivo<SlobodanZadatak> n = new Nivo<SlobodanZadatak>(3, 3, 3);
            n.UnosIzFajla("k3.txt");
            formaSlobZadatak = new frmSlobodanNivo(n);
            formaSlobZadatak.Show();
        }

        private void lbleh1_Click(object sender, EventArgs e)
        {
            Nivo<SlobodanZadatak> n = new Nivo<SlobodanZadatak>(3, 3, 1);
            n.UnosIzFajla("eh1.txt");
            formaSlobZadatak = new frmSlobodanNivo(n);
            formaSlobZadatak.Show();
        }

        private void lbleh2_Click(object sender, EventArgs e)
        {
            Nivo<SlobodanZadatak> n = new Nivo<SlobodanZadatak>(3, 3, 2);
            n.UnosIzFajla("eh2.txt");
            formaSlobZadatak = new frmSlobodanNivo(n);
            formaSlobZadatak.Show();
        }

        private void lbleh3_Click(object sender, EventArgs e)
        {
            Nivo<SlobodanZadatak> n = new Nivo<SlobodanZadatak>(3, 3, 3);
            n.UnosIzFajla("eh3.txt");
            formaSlobZadatak = new frmSlobodanNivo(n);
            formaSlobZadatak.Show();
        }

        private void lblpa1_Click(object sender, EventArgs e)
        {
            Nivo<SlobodanZadatak> n = new Nivo<SlobodanZadatak>(3, 3, 1);
            n.UnosIzFajla("pa1.txt");
            formaSlobZadatak = new frmSlobodanNivo(n);
            formaSlobZadatak.Show();
        }

        private void lblpa2_Click(object sender, EventArgs e)
        {
            Nivo<SlobodanZadatak> n = new Nivo<SlobodanZadatak>(3, 3, 2);
            n.UnosIzFajla("pa2.txt");
            formaSlobZadatak = new frmSlobodanNivo(n);
            formaSlobZadatak.Show();
        }

        private void lblpa3_Click(object sender, EventArgs e)
        {
            Nivo<SlobodanZadatak> n = new Nivo<SlobodanZadatak>(3, 3, 3);
            n.UnosIzFajla("pa3.txt");
            formaSlobZadatak = new frmSlobodanNivo(n);
            formaSlobZadatak.Show();
        }

        private void lblpKviz_Click(object sender, EventArgs e)
        {
            Nivo<KvizZadatak> n = new Nivo<KvizZadatak>(3, 3, 2);
            n.UnosIzFajla("pKviz.txt");
            formaKvizZadatak = new frmKvizNivo(n);
            formaKvizZadatak.Show();
        }
    }
}
