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
        //U OVU STATICKU PROMENLJIVU SE CUVA NAZIV NIVOA KOJI TREBA DA SE UCITA
        //TREBA ONA DA SE AZURIRA PRE NEGO STO SE PRITISNE DUGME ZA ULAZAK U NIVO
        public static string nazivFajlaNivoa;
        private void frmSlobodanNivo_Load(object sender, EventArgs e)
        {
            RadnaPovrsina.IzracunajPolja(this, out gornjiLevi, out centar, out duzinaStr);
        }

        private void frmSlobodanNivo_Paint(object sender, PaintEventArgs e)
        {
            RadnaPovrsina.ucitajPozadinu(e.Graphics, this);
            nivo.Zadaci[indexZadatka].Nacrtaj(e.Graphics, centar, duzinaStr / 20);

        }

        private void frmSlobodanNivo_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                RadnaPovrsina.IzracunajPolja(this, out gornjiLevi, out centar, out duzinaStr);
                this.Refresh();
            }
        }
    }
}
