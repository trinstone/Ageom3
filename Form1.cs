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
namespace AgeomProj
{
    public partial class frmUvod : Form
    {
        public Point gornjiLevi;
        public int duzinaStr;
        bool pocetniMeni;
        public Point centar;
        public Form formaSlobZadatak;
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
            SlobodanZadatak joj = new SlobodanZadatak(null, new TimeSpan(0, 0, 0), " ", FormaResenja.broj, " ", new Krug(new Point(2,2), 5), new Krug(new Point(-3, 2), 5));
            SlobodanZadatak[] lele = new SlobodanZadatak[10];
            Nivo<SlobodanZadatak> n = new Nivo<SlobodanZadatak>(0, 0, 0, joj);
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
                a.X = centar.X - 5 * strKvad;
                a.Y = centar.Y - 3 * strKvad;
                b.X = centar.X - 5 * strKvad;
                b.Y = centar.Y + 3 * strKvad;
                Pen trougaoIgraj = new Pen(Color.Black, 5);
                Point[] crtanjeTrougao = { a, b, centar };
                e.Graphics.DrawPolygon(trougaoIgraj, crtanjeTrougao);
            }
            else
            {
                lblIgraj.Visible = false;
                lblIgraj.Enabled = false;
                btnFormule.Visible = false;
                btnFormule.Enabled = false;
            }
            PointF c = new PointF();
            c.X = 0;
            c.Y = 0;
            Krug k = new Krug(c, 5);
            k.Nacrtaj(e.Graphics,centar,strKvad);
            Prava p = new Prava(c, 0, 1);
            p.Nacrtaj(e.Graphics, centar, strKvad);

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
                this.Refresh();
            }
        }

        private void btnFormule_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Analiticka - formule.pdf");
        }
    }
}
