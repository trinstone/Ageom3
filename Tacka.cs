using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeomProj
{
    public class Tacka : IElementSZ
    {
        public SlobodanZadatak SlobodanZadatak { get; set; }
        public PointF[] PozicijaEl { get; }
        public string Oznaka {  get; }
        public Tacka(PointF pozicija, string oznaka) 
        {
            PozicijaEl = new PointF[] { pozicija};
            Oznaka = oznaka;
        }

        public void Nacrtaj(Graphics g, Point centar, int strKvad)
        {
            SolidBrush sb = new SolidBrush(Color.Black);
            int r = strKvad / 3;
            Font f = new Font("Arial", r);
            g.DrawString(Oznaka, f, sb, centar.X + PozicijaEl[0].X*strKvad - r, centar.Y - PozicijaEl[0].Y*strKvad - 2*r);
            g.FillEllipse(sb, centar.X + PozicijaEl[0].X * strKvad-r/2, centar.Y - PozicijaEl[0].Y * strKvad-r/2, r, r);
        }
    }
}
